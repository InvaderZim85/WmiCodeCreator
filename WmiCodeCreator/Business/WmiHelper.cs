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
        /// The amount of namespaces which were skipped due to missing permission
        /// </summary>
        private static int _skipCount = 0;

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
                    InfoEvent?.Invoke($"> current namespace: {GetNamespacePath(nsName)}{Environment.NewLine}" +
                                      $"> {NamespaceList.Count} namespaces found / {_skipCount} skipped");

                    NamespaceList.Add(new NamespaceItem(nsName));

                    LoadNamespaces(nsName);
                }
            }
            catch (ManagementException)
            {
                // Skip the error. It was fired because of insufficient permissions
                _skipCount++;
            }
        }

        /// <summary>
        /// Loads all classes according to the given namespace
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="browseTab">true to load all classes, false to load only dynamic and static classes</param>
        /// <param name="cancellationToken">The token to cancel the execution</param>
        /// <returns>The list with the classes</returns>
        /// <exception cref="ArgumentNullException">Will be thrown when the namespace name is null or empty</exception>
        /// <exception cref="ManagementException">Will be thrown when an error occured in the management object searcher</exception>
        public static List<ClassItem> LoadClasses(string namespaceName, bool browseTab, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(namespaceName))
                throw new ArgumentNullException(nameof(namespaceName));

            var searcher = new ManagementObjectSearcher(new ManagementScope(namespaceName),
                new WqlObjectQuery("SELECT * FROM meta_class"), null);

            var result = new List<ClassItem>();
            foreach (var wmiClass in searcher.Get())
            {
                if (cancellationToken.IsCancellationRequested)
                    cancellationToken.ThrowIfCancellationRequested();

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
        /// <param name="cancellationToken">The token to cancel the execution</param>
        /// <returns>THe list with the properties</returns>
        /// <exception cref="ArgumentNullException">Will be thrown when the namespace name or the class name is null or empty</exception>
        /// <exception cref="ManagementException">Will be thrown when an error occured in the management class</exception>
        public static List<PropertyItem> LoadProperties(string namespaceName, string className, CancellationToken cancellationToken)
        {
            var mClass = CreateManagementClass(namespaceName, className, true);

            return GetClassData<PropertyItem>(mClass.Properties, cancellationToken);
        }

        /// <summary>
        /// Loads the methods of the class
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The name of the class</param>
        /// <param name="cancellationToken">The token to cancel the execution</param>
        /// <returns>The list with the methods</returns>
        public static List<MethodItem> LoadMethods(string namespaceName, string className, CancellationToken cancellationToken)
        {
            var mClass = CreateManagementClass(namespaceName, className, false);

            return GetClassData<MethodItem>(mClass.Methods, cancellationToken);
        }

        /// <summary>
        /// Gets the data of the given collection
        /// </summary>
        /// <typeparam name="T">The type of the expected data</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="token">The token to cancel the execution</param>
        /// <returns>The list with the data</returns>
        private static List<T> GetClassData<T>(object collection, CancellationToken token)
        {
            var tmpResult = new List<object>();
            var tempCollection = new List<WmiDataItem>();

            // Get the data from the collections
            if (collection is MethodDataCollection methodCollection)
            {
                foreach (var entry in methodCollection)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();

                    tempCollection.Add((WmiDataItem) entry);
                }
            }
            else if (collection is PropertyDataCollection propertyCollection)
            {
                foreach (var entry in propertyCollection)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();

                    tempCollection.Add((WmiDataItem)entry);
                }
            }

            // Load the descriptions
            foreach (var entry in tempCollection)
            {
                var (description, qualifier) = GetQualifierData(entry.Qualifiers);
                var tmpDescription = string.Join(Environment.NewLine, description) + Environment.NewLine +
                                     Environment.NewLine + string.Join(Environment.NewLine, qualifier);

                if (entry.DataType == WmiDataItem.DataTypes.Method)
                {
                    var item = (MethodItem) entry;
                    item.Description = tmpDescription;
                    tmpResult.Add(item);
                }
                else if (entry.DataType == WmiDataItem.DataTypes.Property)
                {
                    var item = (PropertyItem) entry;
                    item.Description = tmpDescription;
                    tmpResult.Add(item);
                }
            }

            return tmpResult.Select(s => (T) Convert.ChangeType(s, typeof(T))).ToList();
        }

        /// <summary>
        /// Loads the values according to the give namespace, class and properties
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The name of the class</param>
        /// <param name="cancellationToken">The token to cancel the execution</param>
        /// <returns>The list with the values</returns>
        /// <exception cref="ArgumentNullException">Will be thrown when the namespace name or the class name is null or empty</exception>
        /// <exception cref="ManagementException">Will be thrown when an error occured in the management class</exception>
        public static List<string> LoadValues(string namespaceName, string className, CancellationToken cancellationToken)
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
                if (cancellationToken.IsCancellationRequested)
                    cancellationToken.ThrowIfCancellationRequested();

                // NOTE: Currently only 'TextFormat.Mof' is supported by the 'GetText' method!
                result.Add(wmiObject.GetText(TextFormat.Mof));
            }

            return result;
        }

        /// <summary>
        /// Loads the qualifiers according to the given namespace and class
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The name of the class</param>
        /// <param name="cancellationToken">The token to cancel the execution</param>
        /// <returns>The list with the qualifiers</returns>
        public static List<string> LoadQualifiers(string namespaceName, string className, CancellationToken cancellationToken)
        {
            var mClass = CreateManagementClass(namespaceName, className, true);

            var result = new List<string>();
            foreach (var entry in mClass.Qualifiers)
            {
                if (cancellationToken.IsCancellationRequested)
                    cancellationToken.ThrowIfCancellationRequested();

                result.Add(entry.Name);
            }

            return result;
        }

        /// <summary>
        /// Converts the path of the namespace so that is not to long
        /// </summary>
        /// <param name="original">The original namespace path</param>
        /// <returns>The converts path</returns>
        private static string GetNamespacePath(string original)
        {
            if (original.Length <= 45)
                return original;

            var content = original.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

            var result = "";
            for (var i = 0; i < content.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        result = content[i];
                        break;
                    case 1:
                        result += "\\...";
                        break;
                    default:
                        result += $"\\{content[i]}";
                        break;
                }
            }

            return result;
        }
    }
}
