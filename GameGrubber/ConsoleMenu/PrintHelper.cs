using GameGrubber.InventoryItems;

namespace GameGrubber.ConsoleMenu
{
    internal static class PrintHelper<T> where T : Inventory
    {
        /// <summary>
        /// Prints a single T inventory object to the console as specified by the user.
        /// </summary>
        /// <param name="ID"> Numeric ID to view a single inventory item. </param>
        public static void PrintSingleInventoryObject(ref T inventoryObject, int id)
        {
            inventoryObject.PrintSingleRow(id);
        }

        /// <summary>
        /// Print all T inventory objects and their properties to the console.
        /// </summary>
        public static void PrintAllInventoryObjects(ref T inventoryObject)
        {
            inventoryObject.PrintAllData();
        }
    }
}
