﻿using System.Text.Json;


namespace CollectibleShopManager
{
    /// <summary>
    /// Defines the logic for the main program execution flow.
    /// </summary>
    internal class ExecutionFlow
    {
        static string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        /// <summary>
        /// Defines the main menu execution flow
        /// </summary>
        public void MainMenuFlow()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("This utility can be used to store your collectibles.");
                Console.Write("Press 1 for video games or Q to quit\n");
                string mainChoice = Console.ReadLine();

                if (mainChoice == "1") VideoGameSelectionScreen();
                else if (mainChoice.ToUpper() == "Q") return;
            }
        }

        /// <summary>
        /// Defines the video game selection screen. User may add new games
        /// or view existing games.
        /// </summary>
        private void VideoGameSelectionScreen()
        {
            JsonConfig jsonConfig = new JsonConfig();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Selection: Video Games");
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
                    /// Construct a VideoGame object with all the arguments supplied by the user. First, check to see 
                    /// if the JSON file exists in the user's home directory. If it does not exist, create it, add
                    /// the VideoGame object to a new list, then write the list to the JSON file. If the file does 
                    /// exist, open it, append the new VideoGame object to the list, then save over the previous
                    /// file. 
                    /// </summary>
                    VideoGame videoGame = new VideoGame(gameTitle, gamePlatform,
                        gameDesc, gameCostAsDecimal, gamePriceAsDecimal);

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
                    if (!File.Exists($"{homeDirectory}\\collectibles.json"))
                    {
                        Console.WriteLine("JSON data not found. Add a new Video Game then try again");
                    }
                    else
                    {
                        jsonConfig.PrintAllObjects($"{homeDirectory}\\videogames.json");
                    }
                }
                else if (videoGameScreenChoice.ToUpper() == "B") continue;
                else if (videoGameScreenChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
