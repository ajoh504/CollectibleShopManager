using GameGrubber.InventoryItems;
using System.Reflection;

namespace GameGrubber.ConsoleMenu
{
    internal static class SetterHelper<T> where T : Inventory
    {
        /// <summary>
        /// A method for setting any inventory properties of type int
        /// </summary>
        /// <param name="item"> A string to print to the console for the user's selection </param>
        public static void SetIntPropertyValues(string item, ref T inventoryObject)
        {
            List<PropertyInfo> intProperties = inventoryObject.GetGenericPropertyInfo<int>();

            foreach (var prop in intProperties)
            {
                if (prop.Name.Equals("InventoryID"))
                {
                    Console.WriteLine($"The {prop.Name} for this {item} will be set to {inventoryObject.InventoryID}");
                }
                else
                {
                    Console.WriteLine($"Add: {prop.Name} for a new {item} or press enter to skip");
                    string value = Console.ReadLine();
                    if (int.TryParse(value, out int intValue))
                    {
                        prop.SetValue(inventoryObject, intValue, null);
                    }
                    else
                    {
                        Console.WriteLine("Value set to 0");
                        prop.SetValue(inventoryObject, 0, null);
                    }
                }
            }
        }

        /// <summary>
        /// A method for setting any inventory properties of type string
        /// </summary>
        /// <param name="item"> A string to print to the console for the user's selection </param>
        public static void SetStringPropertyValues(string item, ref T inventoryObject)
        {
            List<PropertyInfo> stringProperties = inventoryObject.GetGenericPropertyInfo<string>();

            foreach (var prop in stringProperties)
            {
                if (prop.Name.Equals("ItemCode"))
                {
                    VerifyItemCode(item, ref inventoryObject);
                }
                else
                {
                    Console.WriteLine($"Add: {prop.Name} for a new {item} or press enter to skip");
                    string value = Console.ReadLine();
                    prop.SetValue(inventoryObject, value, null);
                }
            }
        }

        /// <summary>
        /// A method for setting any inventory properties of type decimal
        /// </summary>
        /// <param name="item"> A string to print to the console for the user's selection </param>
        public static void SetDecimalPropertyValues(string item, ref T inventoryObject)
        {
            List<PropertyInfo> decimalProperties = inventoryObject.GetGenericPropertyInfo<decimal>();

            foreach (var prop in decimalProperties)
            {
                Console.WriteLine($"Add: {prop.Name} for a new {item} or press enter to skip");
                string value = Console.ReadLine();
                if (decimal.TryParse(value, out decimal decimalValue))
                {
                    prop.SetValue(inventoryObject, decimalValue, null);
                }
                else
                {
                    Console.WriteLine("Value set to 0");
                    prop.SetValue(inventoryObject, 0M, null);
                }
            }
        }

        private static void VerifyItemCode(string item, ref T inventoryObject)
        {
            while (true)
            {
                Console.WriteLine($"Add: A unique ItemCode for a new {item} (required)");
                string itemCode = Console.ReadLine();
                if(itemCode == "")
                {
                    Console.WriteLine("ItemCode is required. Press any key to try again.");
                    Console.ReadLine();
                    continue;
                }
                else if (inventoryObject.ItemCodeExists(itemCode))
                {
                    Console.WriteLine($@"
{itemCode} is already associated with an inventory item.
Press any key to enter a new item code.");
                    Console.ReadLine();
                }
                else
                {
                    inventoryObject.ItemCode = itemCode;
                    return;
                }
            }
        }
    }
}
