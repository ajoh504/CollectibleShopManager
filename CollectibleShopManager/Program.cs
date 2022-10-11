using System.Diagnostics;
using System.Text.Json;
using System.IO;

namespace CollectibleShopManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("This utility can be used to store your collectibles.");
                Console.Write("Press 1 for video games or Q to quit\n");
                string mainChoice = Console.ReadLine();

                /// <summary>
                /// Defines the video game selection screen. User may add new games
                /// or view existing games.
                /// </summary>
                if (mainChoice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Selection: Video Games");
                    Console.Write("Press 1 to add a new game, 2 to view a single game, or 3 to view all games\n");
                    string gameChoice = Console.ReadLine();

                    /// <summary>
                    /// Add a new game
                    /// </summary>
                    if (gameChoice == "1")
                    {
                        Console.Write("Add a title for the game or press Enter to skip\n");
                        string gameTitle = Console.ReadLine();

                        Console.Write("Add a platform for the game or press Enter to skip\n");
                        string gamePlatform = Console.ReadLine();

                        Console.Write("Add a description for the game or press Enter to skip\n");
                        string gameDesc = Console.ReadLine();

                        Console.Write("Add a cost for the game or press Enter to skip\n");
                        string gameCost = Console.ReadLine();

                        if (decimal.TryParse(gameCost, out decimal gameCostAsDecimal)) { }
                        else
                        {
                            Console.WriteLine($"{gameCost} is not a valid cost!");
                            gameCostAsDecimal = 0;
                        }

                        Console.Write("Add a sell price for the game or press Enter to skip\n");
                        string gamePrice = Console.ReadLine();

                        if (decimal.TryParse(gamePrice, out decimal gamePriceAsDecimal)) { }
                        else
                        {
                            Console.WriteLine($"{gamePrice} is not a valid sell price!");
                            gamePriceAsDecimal = 0;
                        }

                        VideoGame videoGame = new VideoGame(gameTitle, gamePlatform,
                            gameDesc, gameCostAsDecimal, gamePriceAsDecimal);

                        /// <summary>
                        /// Write video game data to a JSON file stored in the user's home directory. If 
                        /// the JSON file does not exist, create it. If the JSON file does exist, append 
                        /// all new games to the JSON list. 
                        /// </summary>
                        
                        List<VideoGame> gameToAdd = new List<VideoGame>() { videoGame };
                        JsonSerializerOptions jsonSettings = new JsonSerializerOptions();
                        jsonSettings.WriteIndented = true; // Format JSON data

                        string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                        /// Check to see if JSON file already exists
                        if (File.Exists($"{homeDirectory}\\collectibles.json"))
                        {
                            /// If JSON file exists, open it and read its contents into jsonFileData. Deserialize 
                            /// the string into a List of VideoGame objects. Append the new video game object to 
                            /// the List.
                            string jsonFileData = File.ReadAllText($"{homeDirectory}\\collectibles.json");
                            List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);
                            jsonList.Add(gameToAdd[0]);

                            /// Serialize the edited jsonList and overwrite the original JSON file.
                            string serializedList = JsonSerializer.Serialize(jsonList, jsonSettings);
                            File.WriteAllText($"{homeDirectory}\\collectibles.json", serializedList);
                        }
                        else 
                        {
                            /// Create JSON file if it does not already exist, and add the first VideoGame object to it.
                            /// VideoGame objects are stored in a List to allow additional games to be added.
                            string jsonData = JsonSerializer.Serialize<List<VideoGame>>(gameToAdd, jsonSettings);
                            File.WriteAllText($"{homeDirectory}\\collectibles.json", jsonData);
                        }
                        
                    }

                    /// <summary>
                    /// View a single game
                    /// </summary>
                    else if (gameChoice == "2")
                    {

                    }

                    /// <summary>
                    /// View all existing games
                    /// </summary>
                    else if (gameChoice == "3")
                    {

                    }
                }
                else if (mainChoice.ToUpper() == "Q") return;
            }
        }
    }
}