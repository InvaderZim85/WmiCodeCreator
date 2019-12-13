using System.Management;

namespace WmiCodeCreator.DataObject
{
    /// <summary>
    /// Represents a method of a WMI class
    /// </summary>
    internal class MethodItem : BaseItem
    {
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

        /// <summary>
        /// Converts the given <see cref="WmiDataItem"/> object into a <see cref="MethodItem"/> object
        /// </summary>
        /// <param name="data">The original object</param>
        public static explicit operator MethodItem(WmiDataItem data)
        {
            return new MethodItem(data.Name);
        }
    }
}
