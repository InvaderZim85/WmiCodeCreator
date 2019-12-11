using System.Collections.Generic;

namespace WmiCodeCreator.DataObject
{
    /// <summary>
    /// Represents a WMI namespace
    /// </summary>
    internal class NamespaceItem
    {
        /// <summary>
        /// Gets the name of the namespace
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the classes of the namespace
        /// </summary>
        public List<ClassItem> Classes { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="NamespaceItem"/>
        /// </summary>
        /// <param name="name">The namespace</param>
        public NamespaceItem(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Returns the name of the entry
        /// </summary>
        /// <returns>The name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
