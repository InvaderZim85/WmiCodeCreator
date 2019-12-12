
namespace WmiCodeCreator.DataObject
{
    /// <summary>
    /// Represents a value entry of a WMI class property
    /// </summary>
    internal class ValueItem
    {
        /// <summary>
        /// Gets the id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the text of the object
        /// </summary>
        public string Text { get; }

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
        /// <param name="id">The id</param>
        /// <param name="text">The text of the instance</param>
        /// <param name="property">The name of the property</param>
        /// <param name="value">The value</param>
        public ValueItem(int id, string text, string property, object value)
        {
            Id = id;
            Text = text;
            Property = property;
            Value = value?.ToString() ?? "";
        }

        /// <summary>
        /// Returns the value of the item
        /// </summary>
        /// <returns>The values</returns>
        public override string ToString()
        {
            return $"{Id,2} - {Property}: {Value}";
        }
    }
}
