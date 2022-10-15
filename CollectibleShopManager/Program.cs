using System.Diagnostics;
using System.Text.Json;
using System.IO;

namespace CollectibleShopManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonSerializerOptions jsonSettings = new JsonSerializerOptions();
            jsonSettings.WriteIndented = true;
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            
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
                    string videoGameScreenChoice = Console.ReadLine();

                    /// <summary>
                    /// Add a new game
                    /// </summary>
                    if (videoGameScreenChoice == "1")
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

                        /// <summary>
                        /// Construct a VideoGame object with all the arguments supplied by the user. First, check to see 
                        /// if the JSON file exists in the user's home directory. If it does not exist, create it, add
                        /// the VideoGame object to a new list, then write the list to the JSON file. If the file does 
                        /// exist, open it, append the new VideoGame object to the list, then save over the previous
                        /// file. 
                        /// </summary>
                        VideoGame videoGame = new VideoGame(gameTitle, gamePlatform,
                            gameDesc, gameCostAsDecimal, gamePriceAsDecimal);

                        if (!File.Exists($"{homeDirectory}\\collectibles.json"))
                        {
                            List<VideoGame> gameToAdd = new List<VideoGame>() { videoGame };
                            string jsonData = JsonSerializer.Serialize<List<VideoGame>>(gameToAdd, jsonSettings);
                            File.WriteAllText($"{homeDirectory}\\collectibles.json", jsonData);
                        }
                        else 
                        {
                            string jsonFileData = File.ReadAllText($"{homeDirectory}\\collectibles.json");
                            List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);
                            jsonList.Add(videoGame);

                            string serializedList = JsonSerializer.Serialize(jsonList, jsonSettings);
                            File.WriteAllText($"{homeDirectory}\\collectibles.json", serializedList);
                        }
                        
                    }

                    /// <summary>
                    /// View a single game
                    /// </summary>
                    else if (videoGameScreenChoice == "2")
                    {
                        Console.Write("Title:\n");
                        string title = Console.ReadLine();

                        if (!File.Exists($"{homeDirectory}\\collectibles.json"))
                        {
                            Console.WriteLine("JSON data not found. Add new object to file then try again");
                        }
                        else
                        {
                            string jsonFileData = File.ReadAllText($"{homeDirectory}\\collectibles.json");
                            List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);

                            foreach (var game in jsonList)
                            {
                                if (game.Name == title)
                                {
                                    Console.WriteLine($"Title: {game.Name}");
                                    Console.WriteLine($"Platform: {game.Platform}");
                                    Console.WriteLine($"Description: {game.Description}");
                                    Console.WriteLine($"Cost: {game.Cost}");
                                    Console.WriteLine($"Sell price: {game.SellPrice}");
                                    Console.WriteLine("\n");
                                }
                                else Console.WriteLine($"{title} not found");
                            }
                            Console.ReadLine();
                        }
                    }

                    /// <summary>
                    /// View all existing games
                    /// </summary>
                    else if (videoGameScreenChoice == "3")
                    {
                        if (!File.Exists($"{homeDirectory}\\collectibles.json"))
                        {
                            Console.WriteLine("JSON data not found. Add new object to file then try again");
                        }
                        else
                        {
                            string jsonFileData = File.ReadAllText($"{homeDirectory}\\collectibles.json");
                            List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);

                            foreach (var game in jsonList)
                            {
                                Console.WriteLine($"Title: {game.Name}");
                                Console.WriteLine($"Platform: {game.Platform}");
                                Console.WriteLine($"Description: {game.Description}");
                                Console.WriteLine($"Cost: {game.Cost}");
                                Console.WriteLine($"Sell price: {game.SellPrice}");
                                Console.WriteLine("\n"); 
                            }
                            Console.ReadLine();
                        }
                    }
                }
                else if (mainChoice.ToUpper() == "Q") return;
            }
        }
    }
}