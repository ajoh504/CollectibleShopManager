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
                    VideoGameMenu videoGameMenu = new VideoGameMenu();
                    videoGameMenu.Execute();
                }
                else if(mainChoice == "2") /// TEST: get object properties
                {
                    string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    JsonConfig jsonConfig = new JsonConfig();
                    List<VideoGame> gamesList = jsonConfig.GetDeserializedList($"{homeDirectory}\\videogames.json");

                    foreach (var game in gamesList)
                    {
                        // PrintObjectProperties(game);
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

            //static void PrintObjectProperties(Object obj)
            //{
            //    Type t = obj.GetType();
            //    PropertyInfo[] properties = t.GetProperties();
            //    foreach (var prop in properties)
            //    {
            //        Console.WriteLine(prop.GetValue(obj));
            //    }
            //}
        }
    }
}