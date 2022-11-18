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
        public int InventoryID { get; set; }
        public string? PartNumber { get; set; }
        public int UPC { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public decimal SellPrice { get; set; }

        /// <summary>
        /// A method that returns a collection of PropertyInfo objects from this instance of 
        /// the Inventory class.
        /// </summary>
        /// <returns> A PropertyInfo[] array with all the properties from this instance. </returns>
        public PropertyInfo[] GetPropertyInfo()
        {
            Type t = this.GetType();
            PropertyInfo[] properties = t.GetProperties();
            return properties;
        }

        /// <summary>
        /// A method that returns a collection of property values from this instance of 
        /// the Inventory class.
        /// </summary>
        /// <returns> An Object[] array containing all property values from this instance. </returns>
        public Object[] GetPropertyValues()
        {
            PropertyInfo[] properties = this.GetPropertyInfo();
            Object[] propertyValues = new object[properties.Length];

            for (int i = 0; i < propertyValues.Length; i++)
            {
                propertyValues[i] = properties[i].GetValue(this);
            }
            return propertyValues;
        } 

        public Inventory() { }
        public Inventory(int inventoryID, string partNumber, int upc, string desc, decimal cost, decimal sellPrice)
        {
            InventoryID = inventoryID;
            PartNumber = partNumber;
            UPC = upc;
            Description = desc;
            Cost = cost;
            SellPrice = sellPrice;
        }
    }
}
