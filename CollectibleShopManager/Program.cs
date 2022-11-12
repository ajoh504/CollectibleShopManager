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
            /// Create the inventory.json file if it does not exist
            JsonFileConfiguration jsonConfig = new JsonFileConfiguration();
            if (!File.Exists(JsonFileConfiguration.jsonFilePath))
            {
                jsonConfig.CreateNewFile();
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"____________________________________________________

This utility can be used to store your collectibles. 
Please select one of the following:
____________________________________________________");

                Console.Write(@"
Video Game Menu Screen .......... 1 
Quit to Desktop ................. Q
");

                string mainMenuChoice = Console.ReadLine();

                if (mainMenuChoice == "1")
                {
                    MenuSelectionScreen videoGameMenu = new MenuSelectionScreen("Video Game", ref jsonConfig);
                    videoGameMenu.Execute();
                }
                else if (mainMenuChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}