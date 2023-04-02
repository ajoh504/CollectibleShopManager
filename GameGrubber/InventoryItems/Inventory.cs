﻿using GameGrubber.Database;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Diagnostics;
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
    internal class Inventory : BaseTable
    {
        /// <summary>
        /// Defines all private fields
        /// </summary>
        
        private readonly string tableName;
        private int inventoryId;
        private string? partNumber;
        private string? alternatePartNumber;
        private string? description;
        private decimal cost;
        private decimal sellPrice;
        private const string partNumColumn = "part_number";
        private const string altPartNumColumn = "alt_part_number";
        private const string descriptionColumn = "description";
        private const string costColumn = "cost";
        private const string sellPriceColumn = "sell_price";

        public Inventory()
        {
            this.tableName = "inventory";
            inventoryId = GetNextAvailableID(tableName);
            NewRow(tableName, inventoryId);
        }

        public void PrintAllData()
        {
            List<string> list = SelectAll(tableName);
            foreach(object item in list)
            {
                Debug.WriteLine(item);
            }
        }

        public int InventoryID
        {
            get { return inventoryId; }
        }

        public string? PartNumber
        {
            get { return partNumber; }
            set
            {
                if (value == null)
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
                    UpdateRow(tableName, partNumColumn, value, inventoryId);
                }
            }
        }

        public string? AlternatePartNumber
        {
            get { return alternatePartNumber; }
            set
            {
                if (value == null)
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
                    UpdateRow(tableName, altPartNumColumn, value, inventoryId);
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
                    UpdateRow(tableName, descriptionColumn, value, inventoryId);
                }
            }
        }

        public decimal Cost
        {
            get { return cost; }
            set 
            { 
                cost = value;
                UpdateRow(tableName, costColumn, value , inventoryId);
            }
        }

        public decimal SellPrice
        {
            get { return sellPrice; }
            set 
            { 
                sellPrice = value;
                UpdateRow(tableName, sellPriceColumn, value, inventoryId);
            }
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
