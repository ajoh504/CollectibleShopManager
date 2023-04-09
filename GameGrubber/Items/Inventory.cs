using GameGrubber.Database;
using System.Reflection;

namespace GameGrubber.InventoryItems
{
    /// <summary>
    /// Defines a generic inventory item. 
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
        
        protected string tableName;
        private int inventoryId;
        private string? itemCode;
        private string? description;
        private decimal cost;
        private decimal sellPrice;
        private const string itemCodeColumn = "item_code";
        private const string descriptionColumn = "description";
        private const string costColumn = "cost";
        private const string sellPriceColumn = "sell_price";
        private DatabaseNonQuery nonQuery;
        private DatabaseValueSearch valueSearch;

        public int InventoryID
        {
            get { return inventoryId; }
        }

        public string? ItemCode
        {
            get { return itemCode; }
            set
            {
                if (value == null)
                {
                    itemCode = null;
                }
                else if (value.Length > 10)
                {
                    Console.WriteLine("Invalid part number length. Default value set to null");
                    itemCode = null;
                }
                else
                {
                    itemCode = value;
                    nonQuery.UpdateRow(tableName, itemCodeColumn
                        , value, inventoryId);
                }
            }
        }

        public string? Description
        {
            get { return description; }
            set
            {
                if (value == null)
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
                    nonQuery.UpdateRow(tableName, descriptionColumn, value, inventoryId);
                }
            }
        }

        public decimal Cost
        {
            get { return cost; }
            set 
            { 
                cost = value;
                nonQuery.UpdateRow(tableName, costColumn, value , inventoryId);
            }
        }

        public decimal SellPrice
        {
            get { return sellPrice; }
            set 
            { 
                sellPrice = value;
                nonQuery.UpdateRow(tableName, sellPriceColumn, value, inventoryId);
            }
        }

        public Inventory()
        {
            nonQuery = new DatabaseNonQuery();
            valueSearch = new DatabaseValueSearch();
            this.tableName = "inventory";
            inventoryId = valueSearch.GetNextAvailableID(tableName);
        }

        /// <summary>
        /// Add a new row to the database column
        /// </summary>
        public void AddNewRow()
        {
            string row = valueSearch.SelectSingleRow(tableName, inventoryId);
            if (row != "")
            {
                string[] _ = row.Split(",");
                string stringId = _[0];
                int currentId = Int32.Parse(stringId);
                if (currentId == inventoryId)
                {
                    inventoryId = valueSearch.GetNextAvailableID(tableName);
                    nonQuery.NewRow(tableName, inventoryId);
                    return;
                }
            }
            nonQuery.NewRow(tableName, inventoryId);
        }

        /// <summary>
        /// Prints all rows from this inventory table
        /// </summary>
        public void PrintAllData()
        {
            List<string> list = valueSearch.SelectAllFormatted(tableName);
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Prints a single row from this inventory table
        /// </summary>
        /// <param name="id"> id to search for a specific row</param>
        public void PrintSingleRow(int id)
        {
            Console.WriteLine(valueSearch.SelectSingleRow(tableName, id));
        }

        /// <summary>
        /// A method that returns a collection of PropertyInfo objects from this instance of the Inventory class.
        /// </summary>
        /// <remarks>
        /// This method is used to print object properties to the console so that the user can view information
        /// about their inventory, or add a new inventory item.
        /// </remarks>
        /// <returns> A PropertyInfo[] array with all the properties from this instance. </returns>
        public PropertyInfo[] GetPropertyInfo()
        {
            Type t = GetType();
            PropertyInfo[] properties = t.GetProperties();
            return properties;
        }

        /// <summary>
        /// A method that returns a collection of property values from this instance of the Inventory class.
        /// </summary>
        /// <remarks>
        /// This method is specific to retrieving the property values of a given object. The primary purpose
        /// is to print the current values to the console for the user to see. 
        /// </remarks>
        /// <returns> An Object[] array containing all property values from this instance. </returns>
        public object[] GetPropertyValues()
        {
            PropertyInfo[] properties = GetPropertyInfo();
            object[] propertyValues = new object[properties.Length];

            for (int i = 0; i < propertyValues.Length; i++)
            {
                propertyValues[i] = properties[i].GetValue(this);
            }
            return propertyValues;
        }

        /// <summary>
        /// A method that returns a collection of PropertyInfo objects of a specified generic type T.
        /// </summary>
        /// <remarks>
        /// This helper method allows the user to set inventory properties of varying types.
        /// </remarks>
        /// <returns> A PropertyInfo[] array of only the specified type T </returns>
        public List<PropertyInfo> GetGenericPropertyInfo<T>()
        {
            PropertyInfo[] properties = GetPropertyInfo();
            List<PropertyInfo> genericProperties = new List<PropertyInfo>();

            foreach (var prop in properties)
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
