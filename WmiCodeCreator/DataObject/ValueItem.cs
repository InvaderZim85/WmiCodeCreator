
namespace WmiCodeCreator.DataObject
{
    /// <summary>
    /// Represents a value entry of a WMI class property
    /// </summary>
    internal class ValueItem
    {
        /// <summary>
        /// Gets the name of the instance
        /// </summary>
        public string Instance { get; }

        /// <summary>
        /// Gets the name of the property
        /// </summary>
        public string Property { get; }

        /// <summary>
        /// Gets the value
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="ValueItem"/>
        /// </summary>
        /// <param name="instance">The name of the instance</param>
        /// <param name="property">The name of the property</param>
        /// <param name="value">The value</param>
        public ValueItem(string instance, string property, object value)
        {
            Instance = instance;
            Property = property;
            Value = value?.ToString() ?? "";
        }
    }
}
