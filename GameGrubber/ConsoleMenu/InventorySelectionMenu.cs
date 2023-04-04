using GameGrubber.InventoryItems;

namespace GameGrubber.ConsoleMenu
{
    internal static class InventorySelectionMenu
    {
        public static void Execute()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
____________________________________________________

Inventory Selection Menu
Please select one of the following:
____________________________________________________");

                Console.Write(@"
Generic item menu screen ........ 1
Video game menu screen .......... 2
Gaming console menu screen ...... 3
Strategy guide menu screen ...... 4
Controller menu screen .......... 5
Accessory menu screen ........... 6
Go back ......................... B
Quit to desktop ................. Q
");

                string mainMenuChoice = Console.ReadLine();
                if (mainMenuChoice == "1")
                {
                    Inventory inventory = new Inventory();
                    InventoryEditorMenu<Inventory> inventoryMenu = new InventoryEditorMenu<Inventory>(ref inventory, "generic item");
                    inventoryMenu.Execute();
                }
                else if (mainMenuChoice == "2")
                {
                    VideoGame videoGame = new VideoGame();
                    InventoryEditorMenu<VideoGame> videoGameMenu = new InventoryEditorMenu<VideoGame>(ref videoGame, "video game");
                    videoGameMenu.Execute();
                }
                else if (mainMenuChoice == "3")
                {
                    VideoGameConsole gamingConsole = new VideoGameConsole();
                    InventoryEditorMenu<VideoGameConsole> gamingConsoleMenu = new InventoryEditorMenu<VideoGameConsole>(ref gamingConsole, "gaming console");
                    gamingConsoleMenu.Execute();
                }
                else if (mainMenuChoice == "4")
                {
                    StrategyGuide strategyGuide = new StrategyGuide();
                    InventoryEditorMenu<StrategyGuide> strategyGuideMenu = new InventoryEditorMenu<StrategyGuide>(ref strategyGuide, "strategy guide");
                    strategyGuideMenu.Execute();
                }
                else if (mainMenuChoice == "5")
                {
                    Controller controller= new Controller();
                    InventoryEditorMenu<Controller> controllerMenu = new InventoryEditorMenu<Controller>(ref controller, "controller");
                    controllerMenu.Execute();
                }
                else if (mainMenuChoice == "6")
                {
                    Accessory accessory= new Accessory();
                    InventoryEditorMenu<Accessory> accessoryMenu = new InventoryEditorMenu<Accessory>(ref accessory, "accessory");
                    accessoryMenu.Execute();
                }
                else if (mainMenuChoice.ToUpper() == "B") return;
                else if (mainMenuChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
