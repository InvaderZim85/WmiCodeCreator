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
        /// Gets the list with the namespaces
        /// </summary>
        public static List<NamespaceItem> Namespaces { get; private set; }

        /// <summary>
        /// Loads the available namespaces starting from the root namespace passed into the root parameter
        /// </summary>
        /// <exception cref="ManagementException">Will be thrown when an error occured while loading the namespaces</exception>
        public static void LoadNamespaces()
        {
            const string root = "root";
            var nsClass =
                new ManagementClass(new ManagementScope(root), new ManagementPath("__namespace"), null);

            var result = new List<NamespaceItem>();
            foreach (var ns in nsClass.GetInstances())
            {
                var nsName = $"{root}\\{ns["Name"]}";

                result.Add(new NamespaceItem(nsName));
            }

            Namespaces = result.OrderBy(o => o.Name).ToList();
        }

        /// <summary>
        /// Loads all classes according to the given namespace
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <returns>The list with the classes</returns>
        /// <exception cref="ArgumentNullException">Will be thrown when the namespace name is null or empty</exception>
        /// <exception cref="ManagementException">Will be thrown when an error occured in the management object searcher</exception>
        public static List<ClassItem> LoadClasses(string namespaceName)
        {
            if (string.IsNullOrEmpty(namespaceName))
                throw new ArgumentNullException(nameof(namespaceName));

            var searcher = new ManagementObjectSearcher(new ManagementScope(namespaceName),
                new WqlObjectQuery("SELECT * FROM meta_class"), null);

            var result = new List<ClassItem>();
            foreach (var wmiClass in searcher.Get())
            {
                foreach (var qualifier in wmiClass.Qualifiers)
                {
                    if (qualifier.Name.EqualsIgnoreCase("dynamic") || qualifier.Name.EqualsIgnoreCase("static"))
                    {
                        result.Add(new ClassItem(wmiClass["__CLASS"].ToString()));
                    }
                }
            }

            return result.OrderBy(o => o.Name).ToList();
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
            if (string.IsNullOrEmpty(namespaceName))
                throw new ArgumentNullException(nameof(namespaceName));

            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException(className);

            var objectOptions = new ObjectGetOptions(null, TimeSpan.MaxValue, true);

            var mClass = new ManagementClass(namespaceName, className, objectOptions)
            {
                Options = {UseAmendedQualifiers = true}
            };

            var result = new List<PropertyItem>();

            foreach (var property in mClass.Properties)
            {
                result.Add(new PropertyItem(property.Name, property.Type));
            }

            return result.OrderBy(o => o.Name).ToList();
        }

        /// <summary>
        /// Loads the values according to the give namespace, class and properties
        /// </summary>
        /// <param name="namespaceName">The name of the namespace</param>
        /// <param name="className">The name of the class</param>
        /// <param name="properties">The list with the selected properties</param>
        /// <param name="token">The token to cancel the action</param>
        /// <returns>The list with the values</returns>
        /// <exception cref="ArgumentNullException">Will be thrown when the namespace name or the class name is null or empty</exception>
        /// <exception cref="ManagementException">Will be thrown when an error occured in the management class</exception>
        public static List<ValueItem> LoadValues(string namespaceName, string className, List<string> properties, CancellationToken token)
        {
            if (string.IsNullOrEmpty(namespaceName))
                throw new ArgumentNullException(nameof(namespaceName));

            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException(className);

            if (properties == null || !properties.Any())
                throw new ArgumentNullException(nameof(properties));

            var query = $"SELECT * FROM {className}";
            var searcher =
                new ManagementObjectSearcher(new ManagementScope(namespaceName), new WqlObjectQuery(query), null);

            var result = new List<ValueItem>();
            var count = 1;
            foreach (var wmiObject in searcher.Get())
            {
                // NOTE: Currently only 'TextFormat.Mof' is supported by the 'GetText' method!
                result.AddRange(from property in properties
                    where !wmiObject.Properties[property].IsArray
                    select new ValueItem(count, wmiObject.GetText(TextFormat.Mof), property,
                        wmiObject.GetPropertyValue(property)));

                foreach (var property in properties)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();

                    if (!wmiObject.Properties[property].IsArray)
                    {
                        if (token.IsCancellationRequested)
                            token.ThrowIfCancellationRequested();

                        result.Add(new ValueItem(count, wmiObject.GetText(TextFormat.Mof), property,
                            wmiObject.GetPropertyValue(property)));
                    }
                }

                count++;
            }

            return result;
        }
    }
}
