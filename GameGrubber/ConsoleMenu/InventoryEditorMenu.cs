using System.Reflection;
using GameGrubber.Items;

namespace GameGrubber.ConsoleMenu
{

    internal class InventoryEditorMenu<T> where T : Inventory /// Defines the Inventory editor menu screen
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
        public InventoryEditorMenu(ref JsonFileConfiguration<T> jsonConfig, ref T inventoryObject, string inventoryMenuItem)
        {
            this.jsonConfig = jsonConfig;
            this.inventoryObject = inventoryObject;
            this.inventoryMenuItem = inventoryMenuItem;
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

                string lineOne = $"Add a New {inventoryMenuItem}";
                string lineTwo = $"View a Single {inventoryMenuItem}";
                string lineThree = $"View All {inventoryMenuItem}s";
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
                if (menuScreenChoice == "1") /// Add a new T inventory object
                {
                    SetterHelper<T>.SetIntPropertyValues(inventoryMenuItem, ref inventoryObject);
                    SetterHelper<T>.SetStringPropertyValues(inventoryMenuItem, ref inventoryObject);
                    SetterHelper<T>.SetDecimalPropertyValues(inventoryMenuItem, ref inventoryObject);
                    jsonConfig.WriteToFile(inventoryObject);
                }

                else if (menuScreenChoice == "2") /// View a single T inventory object
                {
                    Console.Write("Enter the ID of the game that you wish to view:\n");
                    string ID = Console.ReadLine();
                    if (int.TryParse(ID, out int IDAsInt))
                    {
                        Console.WriteLine("\n");
                        PrintHelper<T>.PrintSingleInventoryObject(IDAsInt, ref jsonConfig);
                        Console.ReadLine();
                    }
                    else Console.WriteLine($"{ID} is invalid");
                }

                else if (menuScreenChoice == "3") /// View all existing T inventory objects
                {
                    PrintHelper<T>.PrintAllInventoryObjects(ref jsonConfig);
                    Console.ReadLine();
                }
                else if (menuScreenChoice.ToUpper() == "B") return;
                else if (menuScreenChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
