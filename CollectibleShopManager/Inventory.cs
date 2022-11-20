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
                if(value == null)
                {
                    partNumber = null;
                }
                else if (value.Length > 10)
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
                if(value == null)
                {
                    alternatePartNumber = null;
                }
                else if (value.Length > 14)
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
                if(value == null)
                {
                    description = null;
                }
                else if (value.Length > 50)
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

        public void SetIntPropertyValues(string item)
        {
            List<PropertyInfo> intProperties = this.GetGenericPropertyInfo<int>();

            foreach (var prop in intProperties)
            {
                Console.WriteLine($"Add a {prop.Name} for the {item} or press enter to skip");
                string value = Console.ReadLine();
                if (int.TryParse(value, out int intValue))
                {
                    prop.SetValue(this, intValue, null);
                }
                else
                {
                    Console.WriteLine("Value set to 0");
                    prop.SetValue(this, 0, null);
                }
            }
        }
        public void SetStringPropertyValues(string item)
        {
            List<PropertyInfo> stringProperties = this.GetGenericPropertyInfo<string>();

            foreach (var prop in stringProperties)
            {
                Console.WriteLine($"Add a {prop.Name} for the {item} or press enter to skip");
                string value = Console.ReadLine();
                prop.SetValue(this, value, null);
            }
        }

        public void SetDecimalPropertyValues(string item)
        {
            List<PropertyInfo> decimalProperties = this.GetGenericPropertyInfo<decimal>();
            
            foreach (var prop in decimalProperties)
            {
                Console.WriteLine($"Add a {prop.Name} for the {item} or press enter to skip");
                string value = Console.ReadLine();
                if(decimal.TryParse(value, out decimal decimalValue))
                {
                    prop.SetValue(this, decimalValue, null);
                }
                else
                {
                    Console.WriteLine("Value set to 0");
                    prop.SetValue(this, 0M, null);
                }
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
        /// A method that returns a collection of PropertyInfo objects of a specified generic type T.
        /// </summary>
        /// <returns> A PropertyInfo[] array of only the specified type T </returns>
        public List<PropertyInfo> GetGenericPropertyInfo<T>()
        {
            PropertyInfo[] properties = this.GetPropertyInfo();
            List<PropertyInfo> genericProperties = new List<PropertyInfo>();

            foreach(var prop in properties)
            {
                if (prop.PropertyType == typeof(T))
                {
                    genericProperties.Add(prop);
                }
            }
            return genericProperties;
        }
    }
}
