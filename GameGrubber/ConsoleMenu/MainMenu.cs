namespace GameGrubber.ConsoleMenu
{
    internal static class MainMenu
    {
        public static void Execute()
        {
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
