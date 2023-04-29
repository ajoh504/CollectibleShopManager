namespace GameGrubber.ConsoleMenu
{
    internal class MainMenu
    {
        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@"
____________________________________

Game Grubber 
____________________________________

Point of Sale ................... 1
Inventory ....................... 2
Quit to Desktop ................. Q
");

                string choice = Console.ReadLine();
                if (choice == "1") 
                {
                    PointOfSaleSelectionMenu posMenu = new PointOfSaleSelectionMenu();
                    posMenu.Execute(); 
                }
                else if (choice == "2")
                {
                    InventorySelectionMenu inventoryMenu = new InventorySelectionMenu();
                    inventoryMenu.Execute();
                }
                else if (choice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
