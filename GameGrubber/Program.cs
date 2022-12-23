using System.Reflection;
using GameGrubber.ConsoleMenu;
using GameGrubber.InventoryItems;

namespace GameGrubber
{
    internal class Program
    {
        public static string mainDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\GameGrubber";
        /// <summary>
        /// Defines the main menu execution flow
        /// </summary>
        static void Main(string[] args)
        {
            // Create the main program directory in the user's home directory.
            Directory.CreateDirectory(mainDir);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
____________________________________

Game Grubber - Main Menu
____________________________________");

                Console.Write(@"
Point of Sale ................... 1
Inventory ....................... 2
Quit to Desktop ................. Q
");

                string choice = Console.ReadLine();
                if (choice == "1") PointOfSaleSelectionMenu.Execute(); 
                else if (choice == "2") InventorySelectionMenu.Execute();
                else if (choice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}