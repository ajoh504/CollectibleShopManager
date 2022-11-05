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
                Console.WriteLine(@"
This utility can be used to store your collectibles. 
Please select one of the following:");

                Console.Write(@"
Video Game Menu Screen .... 1 
TEST: get object properties 2
Quit to Desktop ........... Q
");

                string mainChoice = Console.ReadLine();

                if (mainChoice == "1")
                {
                    MenuSelectionScreen videoGameMenu = new MenuSelectionScreen();
                    videoGameMenu.Execute();
                }
                else if(mainChoice == "2") /// TEST: get object properties
                {
                    string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    JsonFileConfiguration jsonConfig = new JsonFileConfiguration();
                    List<VideoGame> gamesList = jsonConfig.GetDeserializedList($"{homeDirectory}\\videogames.json");

                    foreach (var game in gamesList)
                    {
                        PropertyInfo[] videoGameProperties = game.GetPropertyInfo();
                        Object[] videoGamePropertyValues = game.GetPropertyValues();

                        for (int i = 0; i < videoGameProperties.Length; i++)
                        {
                            Console.WriteLine($"{videoGameProperties[i].Name}: {videoGamePropertyValues[i]}");
                        }
                        Console.WriteLine("\n");
                    }
                    Console.ReadLine();
                }
                else if (mainChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}