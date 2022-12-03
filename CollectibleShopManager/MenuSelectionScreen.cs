using System.Reflection;

namespace CollectibleShopManager
{

    internal class MenuSelectionScreen<T> where T : Inventory /// Defines the Inventory Selection Screen
    {
        private JsonFileConfiguration<T> jsonConfig;
        private T inventoryObject;
        private string inventoryMenuItem;

        /// <summary>
        /// Defines the class constructor
        /// </summary>
        /// <param name="jsonConfig"> An object to read from and write to any inventory JSON files </param>
        /// <param name="inventoryObject"> The inventory type that defines this instance of the menu screen </param>
        /// <param name="inventoryMenuItem"> A string that determines what to print to the console for the user's selection </param>
        public MenuSelectionScreen(ref JsonFileConfiguration<T> jsonConfig, ref T inventoryObject, string inventoryMenuItem)
        {
            this.jsonConfig = jsonConfig;
            this.inventoryObject = inventoryObject;
            this.inventoryMenuItem = inventoryMenuItem;
        }

        /// <summary>
        /// Prints a single T inventory object to the console as specified by the user.
        /// </summary>
        /// <param name="ID"> Numeric ID to view a single inventory item. </param>
        private void PrintSingleInventoryObject(int ID)
        {
            List<T> jsonList = jsonConfig.GetDeserializedList<T>();

            foreach (var inventoryObject in jsonList)
            {
                if (inventoryObject.InventoryID == ID)
                {
                    PropertyInfo[] inventoryPropertyInfo = inventoryObject.GetPropertyInfo();
                    Object[] inventoryPropertyValues = inventoryObject.GetPropertyValues();
                    for (int i = 0; i < inventoryPropertyValues.Length; i++)
                    {
                        Console.WriteLine($"{inventoryPropertyInfo[i].Name}: {inventoryPropertyValues[i]}");
                    }
                    Console.WriteLine('\n');
                    goto returnToMainMenu;
                }
            }
            Console.WriteLine($"{ID} is not associated with an {inventoryMenuItem}");

            returnToMainMenu:
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }

        /// <summary>
        /// Print all T inventory objects and their properties to the console.
        /// </summary>
        private void PrintAllInventoryObjects()
        {
            List<T> jsonList = jsonConfig.GetDeserializedList<T>();

            foreach (var inventoryObject in jsonList)
            {
                PropertyInfo[] inventoryPropertyInfo = inventoryObject.GetPropertyInfo();
                Object[] inventoryPropertyValues = inventoryObject.GetPropertyValues();
                for (int i = 0; i < inventoryPropertyValues.Length; i++)
                {
                    Console.WriteLine($"{inventoryPropertyInfo[i].Name}: {inventoryPropertyValues[i]}");
                }
                Console.WriteLine('\n');
            }
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }

        public void Execute() /// Defines all logic for the menu execution flow
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($@"
___________________________________

Selection: {inventoryMenuItem} Menu Screen
Please select one of the following:
___________________________________");

                string lineOne = $"Add a new {inventoryMenuItem }";
                string lineTwo = $"View a single {inventoryMenuItem}";
                string lineThree = $"View all {inventoryMenuItem}s";
                string lineFour = "Go Back";
                string lineFive = "Quit to Desktop";

                Console.Write($@"
{lineOne.PadRight(32, '.')} 1
{lineTwo.PadRight(32, '.')} 2
{lineThree.PadRight(32, '.')} 3
{lineFour.PadRight(32, '.')} B
{lineFive.PadRight(32, '.')} Q
___________________________________
");

                string menuScreenChoice = Console.ReadLine();
                if (menuScreenChoice == "1") /// Add a new inventory object
                {
                    inventoryObject.SetIntPropertyValues(inventoryMenuItem);
                    inventoryObject.SetStringPropertyValues(inventoryMenuItem);
                    inventoryObject.SetDecimalPropertyValues(inventoryMenuItem);
                    jsonConfig.WriteToFile(inventoryObject);
                }

                else if (menuScreenChoice == "2") /// View a single inventory object
                {
                    Console.Write("Enter the ID of the game that you wish to view:\n");
                    string ID = Console.ReadLine();
                    if (int.TryParse(ID, out int IDAsInt))
                    {
                        Console.WriteLine("\n");
                        PrintSingleInventoryObject(IDAsInt);
                    }
                    else Console.WriteLine($"{ID} is invalid");
                }

                else if (menuScreenChoice == "3") /// View all existing inventory object
                {
                    PrintAllInventoryObjects();
                }
                else if (menuScreenChoice.ToUpper() == "B") return;
                else if (menuScreenChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
