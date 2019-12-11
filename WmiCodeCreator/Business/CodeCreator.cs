using System.Collections.Generic;
using System.IO;
using System.Text;
using WmiCodeCreator.DataObject;
using ZimLabs.Utility;

namespace WmiCodeCreator.Business
{
    /// <summary>
    /// Provides the functions to generate the code
    /// </summary>
    internal static class CodeCreator
    {
        /// <summary>
        /// Loads the template
        /// </summary>
        /// <returns>The template</returns>
        private static string LoadTemplate()
        {
            var path = Path.Combine(Global.GetBaseFolder(), "Templates", "CSharpClassTemplate.cs");

            if (!File.Exists(path))
                throw new FileNotFoundException("The C# template file is missing.");

            return File.ReadAllText(path);
        }

        /// <summary>
        /// Creates the csharp code
        /// </summary>
        /// <param name="namespaceItem">The namespace</param>
        /// <param name="classItem">The class</param>
        /// <param name="properties">The selected properties</param>
        /// <returns>The generated code</returns>
        public static string CreateCSharpCode(NamespaceItem namespaceItem, ClassItem classItem,
            List<PropertyItem> properties)
        {
            var template = LoadTemplate();

            if (string.IsNullOrEmpty(template))
                return "";

            // Step 1: Replace the namespace
            template = template.Replace("{NAMESPACE}", namespaceItem.Name.Replace("\\", "\\\\"));
            // Step 2: Replace the query
            template = template.Replace("{QUERY}", $"SELECT * FROM {classItem.Name}");
            // Step 3: Replace the class name
            template = template.Replace("{CLASS}", classItem.Name);
            // Step 4: Create the properties
            template = template.Replace("{PROPERTY}", CreateProperties(properties));

            return template;
        }

        /// <summary>
        /// Creates the properties
        /// </summary>
        /// <param name="properties">The list with the selected properties</param>
        /// <returns>The properties</returns>
        private static string CreateProperties(List<PropertyItem> properties)
        {
            var sb = new StringBuilder();
            var spacer = "".PadRight(5 * 4, ' ');

            var count = 1;
            foreach (var property in properties)
            {
                if (count == properties.Count)
                    sb.Append($"{spacer}Console.WriteLine(\"" + property.Name + ": {0}\", queryObj[\"" + property.Name + "\"]);");
                else
                    sb.AppendLine($"{spacer}Console.WriteLine(\"" + property.Name + ": {0}\", queryObj[\"" + property.Name + "\"]);");

                count++;
            }

            var propertyCode = sb.ToString();
            if (string.IsNullOrEmpty(propertyCode))
                propertyCode = $"{spacer}// Add the properties here: queryObj[\"PROPERTYNAME\"]";

            return propertyCode;
        }
    }
}
