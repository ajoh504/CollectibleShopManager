using GameGrubber.InventoryItems;

namespace GameGrubber.ConsoleMenu
{

    internal class InventoryEditorMenu<T> where T : Inventory /// Defines the Inventory editor menu screen
    {
        private T inventoryObject;
        private string inventoryMenuItem;

        /// <summary>
        /// Defines the class constructor
        /// </summary>
        /// <param name="inventoryObject"> The inventory type that defines this instance of the menu screen </param>
        /// <param name="inventoryMenuItem"> A string that determines what to print to the console for the user's selection </param>
        public InventoryEditorMenu(ref T inventoryObject, string inventoryMenuItem)
        {
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

Selection: {inventoryMenuItem} menu screen
___________________________________");

                string lineOne = $"Add a new {inventoryMenuItem}";
                string lineTwo = $"View a single {inventoryMenuItem}";
                string lineThree = $"View all {inventoryMenuItem}s";
                string lineFour = "Go back";
                string lineFive = "Quit to desktop";

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
                    inventoryObject.AddNewRow();
                }

                else if (menuScreenChoice == "2") /// View a single T inventory object
                {
                    Console.Write("Enter the ID of the game that you wish to view:\n");
                    string ID = Console.ReadLine();
                    if (ID.ToUpper().Equals("B")) return;
                    else if (int.TryParse(ID, out int IDAsInt))
                    {
                        Console.WriteLine("\n");
                        inventoryObject.PrintSingleRow(IDAsInt);
                        Console.ReadLine();
                    }
                    else Console.WriteLine($"{ID} is invalid");
                }

                else if (menuScreenChoice == "3") /// View all existing T inventory objects
                {
                    inventoryObject.PrintAllData();
                    Console.ReadLine();
                }
                else if (menuScreenChoice.ToUpper() == "B") return;
                else if (menuScreenChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
