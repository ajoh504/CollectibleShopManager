using System.Diagnostics;
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
        /// <summary>
        /// Defines all private fields
        /// </summary>
        private int inventoryId;
        private string? partNumber;
        private string? alternatePartNumber;
        private string? description;
        private decimal cost;
        private decimal sellPrice;

        /// <summary>
        /// Defines all property setters. 
        /// </summary>
        public int InventoryID
        {
            get
            {
                return inventoryId;
            }
            set
            {
                inventoryId = value;
            }
        }

        public string? PartNumber
        {
            get
            {
                return partNumber;
            }
            set
            {
                if(PartNumber.Length > 10)
                {
                    Console.WriteLine("Invalid part number length. Default value set to null");
                    partNumber = null;
                }
                else
                {
                    partNumber = value;
                }
            }
        }

        public string? AlternatePartNumber
        {
            get
            {
                return alternatePartNumber;
            }
            set
            {
                if(AlternatePartNumber.Length > 14)
                {
                    Console.WriteLine("Invalid alternate part number length. Default value set to null");
                    alternatePartNumber = null;
                }
                else
                {
                    alternatePartNumber = value;
                }
            }
        }

        public string? Description
        {
            get
            {
                return description;
            }
            set
            {
                if(Description.Length > 50)
                {
                    Console.WriteLine("Invalid description length. Default value set to null");
                    description = null;
                }
                else
                {
                    description = value;
                }
            }
        }

        public decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
        public decimal SellPrice
        {
            get
            {
                return sellPrice;
            }
            set
            {
                sellPrice = value;
            }
        }

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



        /// <summary>
        /// Defines the class constructors
        /// </summary>
        public Inventory() { }
        public Inventory(int inventoryID, string partNumber, string alternatePartNumber, string desc, decimal cost, decimal sellPrice)
        {
            InventoryID = inventoryID;
            PartNumber = partNumber;
            AlternatePartNumber = alternatePartNumber;
            Description = desc;
            Cost = cost;
            SellPrice = sellPrice;
        }
    }
}
