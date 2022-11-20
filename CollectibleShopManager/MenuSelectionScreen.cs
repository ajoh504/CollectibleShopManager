using System.Reflection;

namespace CollectibleShopManager
{

    internal class MenuSelectionScreen<T> where T : Inventory /// Defines the Inventory Selection Screen
    {
        private JsonFileConfiguration<T> JsonConfig { get; set; } 
        private T InventoryObject { get; set; }
        private string InventoryMenuItem;

        /// <summary>
        ///  Class Constructor
        /// </summary>
        /// <param name="jsonConfig"></param>
        public MenuSelectionScreen(ref JsonFileConfiguration<T> jsonConfig, ref T inventoryObject, string inventoryMenuItem)
        {
            JsonConfig = jsonConfig;
            InventoryObject = inventoryObject;
            InventoryMenuItem = inventoryMenuItem;
        }

        /// <summary>
        /// Prints a single Inventory object to the console as specified by the user.
        /// </summary>
        /// <param name="name"> Title of the Inventory object to print </param>
        private void PrintSingleInventoryObject(int ID)
        {
            List<T> jsonList = JsonConfig.GetDeserializedList<T>();

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
            Console.WriteLine($"{ID} is not associate with an {InventoryMenuItem}");

            returnToMainMenu:
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }

        /// <summary>
        /// Print all Inventory objects and their properties to the console.
        /// </summary>
        /// <param name="filePath"> File path to videogames.json </param>
        private void PrintAllInventoryObjects()
        {
            List<T> jsonList = JsonConfig.GetDeserializedList<T>();

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
                Console.WriteLine($@"___________________________________

Selection: {InventoryMenuItem} Menu Screen
Please select one of the following:
___________________________________");

                string lineOne = $"Add a new {InventoryMenuItem }";
                string lineTwo = $"View a single {InventoryMenuItem}";
                string lineThree = $"View all {InventoryMenuItem}s";
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
                    InventoryObject.SetIntPropertyValues(InventoryMenuItem);
                    InventoryObject.SetStringPropertyValues(InventoryMenuItem);
                    InventoryObject.SetDecimalPropertyValues(InventoryMenuItem);
                    JsonConfig.WriteToFile(InventoryObject);
                }

                else if (menuScreenChoice == "2") /// View a single game
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

                else if (menuScreenChoice == "3") /// View all existing games
                {
                    PrintAllInventoryObjects();
                }
                else if (menuScreenChoice.ToUpper() == "B") return;
                else if (menuScreenChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
