using System.Management;

namespace WmiCodeCreator.DataObject
{
    /// <summary>
    /// Represents a property of a WMI class
    /// </summary>
    internal class PropertyItem
    {
        /// <summary>
        /// Gets the name of the property
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the type of the property
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets or sets the description of the property
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="PropertyItem"/>
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="type">The type of the property</param>
        public PropertyItem(string name, CimType type)
        {
            Name = name;
            Type = GetType(type);
        }

        /// <summary>
        /// Gets the according C# type
        /// </summary>
        /// <param name="type">The original type</param>
        /// <returns>The C# type</returns>
        private string GetType(CimType type)
        {
            switch (type)
            {
                case CimType.Char16:
                    return "char";
                case CimType.Real64:
                    return "double";
                case CimType.Real32:
                    return "Single";
                case CimType.SInt8:
                    return "sbyte";
                case CimType.SInt16:
                    return "short";
                case CimType.SInt32:
                    return "int";
                case CimType.SInt64:
                    return "long";
                case CimType.UInt8:
                    return "byte";
                default:
                    return type.ToString();
            }
        }

        /// <summary>
        /// Returns the name of the property
        /// </summary>
        /// <returns>The name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
