using GameGrubber.InventoryItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
Standard Item Menu Screen ....... 1
Video Game Menu Screen .......... 2
Go Back ......................... B
Quit to Desktop ................. Q
");

                string mainMenuChoice = Console.ReadLine();
                if (mainMenuChoice == "1")
                {
                    JsonFile<Inventory> jsonFile = new JsonFile<Inventory>();
                    jsonFile.JsonFilePath = $"{Program.mainDir}\\inventory.json";
                    if (!File.Exists(jsonFile.JsonFilePath))
                    {
                        jsonFile.CreateNewFile<Inventory>();
                    }

                    Inventory inventory = new Inventory();
                    InventoryEditorMenu<Inventory> inventoryMenu = new InventoryEditorMenu<Inventory>(ref jsonFile, ref inventory, "Standard Item");
                    inventoryMenu.Execute();
                }
                else if (mainMenuChoice == "2")
                {
                    JsonFile<VideoGame> jsonFile = new JsonFile<VideoGame>();
                    jsonFile.JsonFilePath = $"{Program.mainDir}\\videogames.json";
                    if (!File.Exists(jsonFile.JsonFilePath))
                    {
                        jsonFile.CreateNewFile<VideoGame>();
                    }

                    VideoGame videoGame = new VideoGame();
                    InventoryEditorMenu<VideoGame> videoGameMenu = new InventoryEditorMenu<VideoGame>(ref jsonFile, ref videoGame, "Video Game");
                    videoGameMenu.Execute();
                }
                else if (mainMenuChoice.ToUpper() == "B") return;
                else if (mainMenuChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
