using System.Reflection;

namespace CollectibleShopManager
{
    /// <summary>
    /// Defines a generic inventory item with no special properties. 
    /// </summary>
    /// <remarks>
    /// Provides a base class to inherit from. Any inventory item with unique or special properties
    /// cam inherit from the Inventory class. 
    /// </remarks>
    internal class Inventory
    {
        public string? PartNumber { get; set; }
        public int UPC { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public decimal SellPrice { get; set; }

        public bool IsPropertyFound(Inventory inventory, string property)
        {
            return false;
        }

        public bool IsPropertyFound(Inventory inventory, decimal property)
        {
            return false;
        }

        /// <summary>
        /// Given an object as an argument, get an array of its properties as PropertyInfo 
        /// objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> An array of PropertyInfo[] objects. </returns>
        public PropertyInfo[] GetObjectProperties(Object obj)
        {
            Type t = obj.GetType();
            PropertyInfo[] properties = t.GetProperties();
            return properties;
        }

        /// <summary>
        /// Given an array of PropertyInfo objects, return an array that contains the values of 
        /// each property.
        /// </summary>
        /// <param name="properties"></param>
        /// <returns> Object[] containing all property values. </returns>
        public Object[] GetPropertyValues(PropertyInfo[] properties)
        {
            Object[] propertyValues = new object[properties.Length];
            for (int i = 0; i < propertyValues.Length; i++)
            {
                propertyValues[i] = properties[i].GetValue();
            }
        } 

        public Inventory() { }
        public Inventory(string partNumber, int upc, string desc, decimal cost, decimal sellPrice)
        {

            PartNumber = partNumber;
            UPC = upc;
            Description = desc;
            Cost = cost;
            SellPrice = sellPrice;
        }
    }
}
