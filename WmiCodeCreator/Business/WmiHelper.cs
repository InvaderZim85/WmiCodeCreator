using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading;
using WmiCodeCreator.DataObject;
using ZimLabs.Utility.Extensions;

namespace WmiCodeCreator.Business
{
    /// <summary>
    /// Provides the interaction logic with the WMI
    /// </summary>
    internal static class WmiHelper
    {
        /// <summary>
        /// The delegate for the <see cref="WmiHelper.InfoEvent"/>
        /// </summary>
        /// <param name="message">The message</param>
        public delegate void InfoEventHandler(string message);

        /// <summary>
        /// Provides information
        /// </summary>
        public static event InfoEventHandler InfoEvent;

        /// <summary>
        /// Contains the list with the namespaces
        /// </summary>
        private static readonly List<NamespaceItem> NamespaceList = new List<NamespaceItem>();

        /// <summary>
        /// Gets the list with the namespaces
        /// </summary>
        public static List<NamespaceItem> Namespaces => NamespaceList.OrderBy(o => o.Name).ToList();

        /// <summary>
        /// Creates the <see cref="ManagementClass"/> object for the search
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The name of the class</param>
        /// <param name="withTimeout">true to create it with a timeout, otherwise false</param>
        /// <returns></returns>
        private static ManagementClass CreateManagementClass(string namespaceName, string className, bool withTimeout)
        {
            if (string.IsNullOrEmpty(namespaceName))
                throw new ArgumentNullException(nameof(namespaceName));

            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException(className);

            var objectOptions = withTimeout ? new ObjectGetOptions(null, TimeSpan.MaxValue, true) : new ObjectGetOptions();

            var mClass = new ManagementClass(namespaceName, className, objectOptions)
            {
                Options = { UseAmendedQualifiers = true }
            };

            return mClass;
        }

        /// <summary>
        /// Collects the qualifier data
        /// </summary>
        /// <param name="collection">The qualifier collection</param>
        /// <returns>The lists with the data</returns>
        private static (List<string> DescriptionList, List<string> QualifierList) GetQualifierData(
            QualifierDataCollection collection)
        {
            var descriptionList = new List<string>
            {
                "Description:"
            };
            var qualifierList = new List<string>()
            {
                "Qualifiers:"
            };

            foreach (var entry in collection)
            {
                qualifierList.Add(entry.Name);

                if (entry.Name.EqualsIgnoreCase("description"))
                {
                    descriptionList.Add(entry.Value.ToString());
                }
            }

            return (descriptionList, qualifierList);
        }

        /// <summary>
        /// Loads the namespaces
        /// </summary>
        public static void LoadNamespaces()
        {
            LoadNamespaces("root");
        }

        /// <summary>
        /// Loads the available namespaces starting from the root namespace passed into the root parameter
        /// </summary>
        /// <exception cref="ManagementException">Will be thrown when an error occured while loading the namespaces</exception>
        private static void LoadNamespaces(string root)
        {
            try
            {
                var nsClass =
                    new ManagementClass(new ManagementScope(root), new ManagementPath("__namespace"), null);

                foreach (var ns in nsClass.GetInstances())
                {
                    var nsName = $"{root}\\{ns["Name"]}";
                    InfoEvent?.Invoke($"Current namespace: {nsName} ({NamespaceList.Count} namespaces found)");

                    NamespaceList.Add(new NamespaceItem(nsName));

                    LoadNamespaces(nsName);
                }
            }
            catch (ManagementException)
            {
                // Skip the error. It was fired because of insufficient permissions
            }
        }

        /// <summary>
        /// Loads all classes according to the given namespace
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="browseTab">true to load all classes, false to load only dynamic and static classes</param>
        /// <returns>The list with the classes</returns>
        /// <exception cref="ArgumentNullException">Will be thrown when the namespace name is null or empty</exception>
        /// <exception cref="ManagementException">Will be thrown when an error occured in the management object searcher</exception>
        public static List<ClassItem> LoadClasses(string namespaceName, bool browseTab)
        {
            if (string.IsNullOrEmpty(namespaceName))
                throw new ArgumentNullException(nameof(namespaceName));

            var searcher = new ManagementObjectSearcher(new ManagementScope(namespaceName),
                new WqlObjectQuery("SELECT * FROM meta_class"), null);

            var result = new List<ClassItem>();
            foreach (var wmiClass in searcher.Get())
            {
                var name = wmiClass["__CLASS"].ToString();
                InfoEvent?.Invoke($"{result.Count,4} - current class: {name}");
                if (browseTab)
                {
                    var classItem = new ClassItem(name);
                    classItem.Description = LoadClassDescription(namespaceName, classItem.Name);
                    result.Add(classItem);
                }
                else
                {
                    foreach (var qualifier in wmiClass.Qualifiers)
                    {
                        if (qualifier.Name.EqualsIgnoreCase("dynamic") || qualifier.Name.EqualsIgnoreCase("static"))
                        {
                            var classItem = new ClassItem(name);
                            result.Add(classItem);
                        }
                    }
                }
            }

            return result.OrderBy(o => o.Name).ToList();
        }

        /// <summary>
        /// Loads the description for the class
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The selected class</param>
        /// <returns>The description of the class</returns>
        private static string LoadClassDescription(string namespaceName, string className)
        {
            var mClass = CreateManagementClass(namespaceName, className, true);

            foreach (var qualifier in mClass.Qualifiers)
            {
                if (qualifier.Name.EqualsIgnoreCase("description"))
                    return qualifier.Value.ToString();
            }

            var (descriptionList, _) = GetQualifierData(mClass.Qualifiers);

            return string.Join(Environment.NewLine, descriptionList);
        }

        /// <summary>
        /// Loads the properties of the class according to the given class and namespace
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The name of the class</param>
        /// <returns>THe list with the properties</returns>
        /// <exception cref="ArgumentNullException">Will be thrown when the namespace name or the class name is null or empty</exception>
        /// <exception cref="ManagementException">Will be thrown when an error occured in the management class</exception>
        public static List<PropertyItem> LoadProperties(string namespaceName, string className)
        {
            var mClass = CreateManagementClass(namespaceName, className, true);

            var result = new List<PropertyItem>();

            foreach (var entry in mClass.Properties)
            {
                var property = new PropertyItem(entry.Name, entry.Type);

                var (descriptionList, qualifierList) = GetQualifierData(entry.Qualifiers);

                var tmpDescription = string.Join(Environment.NewLine, descriptionList) + Environment.NewLine +
                                     Environment.NewLine + string.Join(Environment.NewLine, qualifierList);

                property.Description = tmpDescription;

                result.Add(property);
            }

            return result.OrderBy(o => o.Name).ToList();
        }

        /// <summary>
        /// Loads the values according to the give namespace, class and properties
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The name of the class</param>
        /// <param name="token">The token to cancel the action</param>
        /// <returns>The list with the values</returns>
        /// <exception cref="ArgumentNullException">Will be thrown when the namespace name or the class name is null or empty</exception>
        /// <exception cref="ManagementException">Will be thrown when an error occured in the management class</exception>
        public static List<string> LoadValues(string namespaceName, string className, CancellationToken token)
        {
            if (string.IsNullOrEmpty(namespaceName))
                throw new ArgumentNullException(nameof(namespaceName));

            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException(className);

            var query = $"SELECT * FROM {className}";
            var searcher =
                new ManagementObjectSearcher(new ManagementScope(namespaceName), new WqlObjectQuery(query), null);

            var result = new List<string>();
            foreach (var wmiObject in searcher.Get())
            {
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();

                // NOTE: Currently only 'TextFormat.Mof' is supported by the 'GetText' method!
                result.Add(wmiObject.GetText(TextFormat.Mof));
            }

            return result;
        }

        /// <summary>
        /// Loads the methods of the class
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The name of the class</param>
        /// <returns>The list with the methods</returns>
        public static List<MethodItem> LoadMethods(string namespaceName, string className)
        {
            var mClass = CreateManagementClass(namespaceName, className, false);

            var result = new List<MethodItem>();
            foreach (var entry in mClass.Methods)
            {
                var method = new MethodItem(entry.Name);

                var (descriptionList, qualifierList) = GetQualifierData(entry.Qualifiers);

                var tmpDescription = string.Join(Environment.NewLine, descriptionList) + Environment.NewLine +
                                     Environment.NewLine + string.Join(Environment.NewLine, qualifierList);

                method.Description = tmpDescription;
                result.Add(method);
            }

            return result;
        }

        /// <summary>
        /// Loads the qualifiers according to the given namespace and class
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The name of the class</param>
        /// <returns>The list with the qualifiers</returns>
        public static List<string> LoadQualifiers(string namespaceName, string className)
        {
            var mClass = CreateManagementClass(namespaceName, className, true);

            var result = new List<string>();
            foreach (var entry in mClass.Qualifiers)
            {
                result.Add(entry.Name);
            }

            return result;
        }
    }
}
