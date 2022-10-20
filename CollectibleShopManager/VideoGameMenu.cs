﻿namespace CollectibleShopManager
{
    /// <summary>
    /// Defines the video game selection screen. User may add new games or view existing games.
    /// </summary>
    internal class VideoGameMenu
    {
        /// <summary>
        /// Get the user's home directory. Video game data will be stored at homeDirectory\\videogames.json
        /// </summary>
        static string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        /// <summary>
        /// Main execution logic for the Video Game menu screen
        /// </summary>
        public void Execute()
        {
            JsonConfig jsonConfig = new JsonConfig();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Selection: Video Game Menu Screen");
                Console.Write("Press 1 to add a new game, 2 to view a single game, 3 to view all games, B to go back, or Q to quit\n");
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
                    /// Construct a VideoGame object with all the arguments supplied by the user. 
                    /// </summary>
                    VideoGame videoGame = new VideoGame(gameTitle, gamePlatform,
                        gameDesc, gameCostAsDecimal, gamePriceAsDecimal);

                    /// <summary>
                    /// Check to see if the JSON file exists in the user's home directory. If it does not exist, 
                    /// call jsonConfig.CreateNewFile() to create it. If it does exist, call jsonConfig.WriteToFile()
                    /// to write the new VideoGame object to the JSON file. 
                    /// </summary>
                    if (!File.Exists($"{homeDirectory}\\videogames.json"))
                    {
                        jsonConfig.CreateNewFile($"{homeDirectory}\\videogames.json", videoGame);
                    }
                    else
                    {
                        jsonConfig.WriteToFile($"{homeDirectory}\\videogames.json", videoGame);
                    }
                }

                /// <summary>
                /// View a single game
                /// </summary>
                else if (videoGameScreenChoice == "2")
                {
                    Console.Write("Enter the title of the game that you wish to view:\n");
                    string title = Console.ReadLine();

                    if (!File.Exists($"{homeDirectory}\\videogames.json"))
                    {
                        Console.WriteLine("JSON data not found. Add a new Video Game then try again");
                    }
                    else
                    {
                        jsonConfig.PrintSingleObject($"{homeDirectory}\\videogames.json", title);
                    }
                }

                /// <summary>
                /// View all existing games
                /// </summary>
                else if (videoGameScreenChoice == "3")
                {
                    if (!File.Exists($"{homeDirectory}\\videogames.json"))
                    {
                        Console.WriteLine("JSON data not found. Add a new Video Game then try again");
                    }
                    else
                    {
                        jsonConfig.PrintAllObjects($"{homeDirectory}\\videogames.json");
                    }
                }
                else if (videoGameScreenChoice.ToUpper() == "B") return;
                else if (videoGameScreenChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
