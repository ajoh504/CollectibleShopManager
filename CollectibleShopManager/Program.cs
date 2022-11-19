using System.Reflection;

namespace CollectibleShopManager
{
    internal class Program
    {
        /// <summary>
        /// Defines the main menu execution flow
        /// </summary>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"____________________________________________________

This utility can be used to store your collectibles. 
Please select one of the following:
____________________________________________________");

                Console.Write(@"
Inventory Menu Screen ........... 1
Video Game Menu Screen .......... 2
Coin Menu Screen ................ 3
Quit to Desktop ................. Q
");

                string mainMenuChoice = Console.ReadLine();
                if(mainMenuChoice == "1")
                {
                    JsonFileConfiguration<Inventory> jsonConfig = new JsonFileConfiguration<Inventory>();
                    jsonConfig.jsonFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\inventory.json";
                    Inventory inventory = new Inventory();
                    MenuSelectionScreen<Inventory> inventoryMenu = new MenuSelectionScreen<Inventory>(ref jsonConfig, ref inventory, "Inventory Item");
                    inventoryMenu.Execute();
                }
                else if (mainMenuChoice == "2")
                {
                    JsonFileConfiguration<VideoGame> jsonConfig = new JsonFileConfiguration<VideoGame>();
                    jsonConfig.jsonFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\videogames.json";
                    VideoGame videoGame = new VideoGame();
                    MenuSelectionScreen<VideoGame> videoGameMenu = new MenuSelectionScreen<VideoGame>(ref jsonConfig, ref videoGame, "Video Game");
                    videoGameMenu.Execute();
                }
                else if(mainMenuChoice == "3")
                {
                    JsonFileConfiguration<Coin> jsonConfig = new JsonFileConfiguration<Coin>();
                    jsonConfig.jsonFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\coins.json";
                    Coin coin = new Coin();
                    MenuSelectionScreen<Coin> coinMenu = new MenuSelectionScreen<Coin>(ref jsonConfig, ref coin, "Coin");
                    coinMenu.Execute();
                }
                else if (mainMenuChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}