using GameGrubber.InventoryItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameGrubber.ConsoleMenu
{
    internal static class PrintHelper<T> where T : Inventory
    {
        /// <summary>
        /// Prints a single T inventory object to the console as specified by the user.
        /// </summary>
        /// <param name="ID"> Numeric ID to view a single inventory item. </param>
        public static void PrintSingleInventoryObject(int ID, ref JsonFileConfiguration<T> jsonConfig)
        {
            List<T> jsonList = jsonConfig.GetDeserializedList<T>();

            foreach (var inventoryObject in jsonList)
            {
                if (inventoryObject.InventoryID == ID)
                {
                    PropertyInfo[] inventoryPropertyInfo = inventoryObject.GetPropertyInfo();
                    object[] inventoryPropertyValues = inventoryObject.GetPropertyValues();
                    for (int i = 0; i < inventoryPropertyValues.Length; i++)
                    {
                        Console.WriteLine($"{inventoryPropertyInfo[i].Name}: {inventoryPropertyValues[i]}");
                    }
                }
            }
        }

        /// <summary>
        /// Print all T inventory objects and their properties to the console.
        /// </summary>
        public static void PrintAllInventoryObjects(ref JsonFileConfiguration<T> jsonConfig)
        {
            List<T> jsonList = jsonConfig.GetDeserializedList<T>();

            foreach (var inventoryObject in jsonList)
            {
                PropertyInfo[] inventoryPropertyInfo = inventoryObject.GetPropertyInfo();
                object[] inventoryPropertyValues = inventoryObject.GetPropertyValues();
                for (int i = 0; i < inventoryPropertyValues.Length; i++)
                {
                    Console.WriteLine($"{inventoryPropertyInfo[i].Name}: {inventoryPropertyValues[i]}");
                }
            }
        }
    }
}
