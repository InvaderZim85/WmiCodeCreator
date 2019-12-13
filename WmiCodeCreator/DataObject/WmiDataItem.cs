using System.Management;

namespace WmiCodeCreator.DataObject
{
    /// <summary>
    /// Represents a WMI Data item
    /// </summary>
    internal class WmiDataItem
    {
        /// <summary>
        /// The different data types
        /// </summary>
        public enum DataTypes
        {
            Property,
            Method
        }

        /// <summary>
        /// Gets or sets the name of the item
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the CIM type
        /// </summary>
        public CimType Type { get; }
        
        /// <summary>
        /// Gets or sets the qualifiers
        /// </summary>
        public QualifierDataCollection Qualifiers { get; }

        /// <summary>
        /// Gets the data type
        /// </summary>
        public DataTypes DataType { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="WmiDataItem"/>
        /// </summary>
        /// <param name="property">The property data</param>
        private WmiDataItem(PropertyData property)
        {
            Name = property.Name;
            Type = property.Type;
            Qualifiers = property.Qualifiers;
            DataType = DataTypes.Property;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="WmiDataItem"/>
        /// </summary>
        /// <param name="method">The method data</param>
        private WmiDataItem(MethodData method)
        {
            Name = method.Name;
            Qualifiers = method.Qualifiers;
            DataType = DataTypes.Method;
        }

        /// <summary>
        /// Converts a <see cref="PropertyData"/> object into a <see cref="WmiDataItem"/>
        /// </summary>
        /// <param name="property">The property data</param>
        public static explicit operator WmiDataItem(PropertyData property)
        {
            return new WmiDataItem(property);
        }

        /// <summary>
        /// Converts a <see cref="MethodData"/> object into a <see cref="WmiDataItem"/>
        /// </summary>
        /// <param name="method">The method data</param>
        public static explicit operator WmiDataItem(MethodData method)
        {
            return new WmiDataItem(method);
        }
    }
}
