using System.Collections.Generic;

namespace WmiCodeCreator.DataObject
{
    /// <summary>
    /// Represents a WMI class
    /// </summary>
    internal class ClassItem
    {
        /// <summary>
        /// Gets the name of the class
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the description of the class
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the properties of the class
        /// </summary>
        public List<PropertyItem> Properties { get; set; }

        /// <summary>
        /// Gets or sets the list with the methods
        /// </summary>
        public List<MethodItem> Methods { get; set; }

        /// <summary>
        /// Gets or sets the list with the qualifiers
        /// </summary>
        public List<string> Qualifiers { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ClassItem"/>
        /// </summary>
        /// <param name="name">The name of the class</param>
        public ClassItem(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Returns the name of the class
        /// </summary>
        /// <returns>The name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
