using GameGrubber.InventoryItems;
using System.Reflection;

namespace GameGrubber.ConsoleMenu
{
    internal static class SetterHelper<T> where T : Inventory
    {
        private static Dictionary<string, int> LengthConstraints = new Dictionary<string, int>()
        {
            /// Provides length limitations for all data values
            { "ItemCode", 14 },
            { "Description", 50 },
            { "Platform", 20 },
            { "Title", 50 },
            { "Category", 20 },
            { "ModelNumber", 10 },
            { "BrandName", 25 },
            { "Color", 10 },
            { "ConnectionType", 10 },
            { "Publisher", 25 },
            { "RegionCode", 6 },
            { "ItemsSold", 200 }
        };

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
                    while (true)
                    {
                        Console.WriteLine($"Add: {prop.Name} for a new {item} or press enter to skip");
                        string value = Console.ReadLine();
                        if (!IsValidLength(value, prop.Name))
                        {
                            Console.WriteLine($"Length requirement is {LengthConstraints[prop.Name]}. Please try again.");
                            Console.ReadLine();
                        }
                        else
                        {
                            prop.SetValue(inventoryObject, value, null);
                            break;
                        }
                    }
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

        /// <summary>
        /// A method to ensure that each item code is unique
        /// </summary>
        /// <remarks>
        /// Inform the user if the item code already exists in the database. Do not allow empty strings
        /// </remarks>
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

        private static bool IsValidLength(string value, string propertyName)
        {
            return value.Length <= LengthConstraints[propertyName];
        }
    }
}
