namespace WmiCodeCreator.DataObject
{
    /// <summary>
    /// Represents a method of a WMI class
    /// </summary>
    internal class MethodItem
    {
        /// <summary>
        /// Gets the name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the description of the method
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="MethodItem"/>
        /// </summary>
        /// <param name="name">The name of the method</param>
        public MethodItem(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Returns the name of the method
        /// </summary>
        /// <returns>The name of the method</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
