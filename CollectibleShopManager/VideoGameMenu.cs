namespace CollectibleShopManager
{
    internal class VideoGameMenu /// Defines the Video Game Selection Screen
    {
        static string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        static JsonConfig jsonConfig = new JsonConfig();

        public void Execute() /// Defines all logic for the menu execution flow
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
Selection: Video Game Menu Screen
Please select one of the following:
");

                Console.Write(@"
Add a new game ........... 1
View a single game ....... 2
View all games ........... 3
Go back .................. B
Quit to Desktop .......... Q
");

                string videoGameScreenChoice = Console.ReadLine();
                if (videoGameScreenChoice == "1") /// Add a new game
                {
                    /// <summary>
                    /// Check to see if the JSON file exists in the user's home directory. If it does not exist, 
                    /// call jsonConfig.CreateNewFile() to create it. If it does exist, call jsonConfig.WriteToFile()
                    /// to write the new VideoGame object to the JSON file. 
                    /// </summary>
                    VideoGame videoGame = GetNewVideoGame();
                    if (!File.Exists($"{homeDirectory}\\videogames.json"))
                    {
                        jsonConfig.CreateNewFile($"{homeDirectory}\\videogames.json", videoGame);
                    }
                    else
                    {
                        jsonConfig.WriteToFile($"{homeDirectory}\\videogames.json", videoGame);
                    }
                }

                else if (videoGameScreenChoice == "2") /// View a single game
                {
                    Console.Write("Enter the title of the game that you wish to view:\n");
                    string title = Console.ReadLine();

                    if (!File.Exists($"{homeDirectory}\\videogames.json"))
                    {
                        Console.WriteLine("JSON data not found. Add a new Video Game then try again");
                    }
                    else
                    {
                        PrintVideoGame($"{homeDirectory}\\videogames.json", title);
                    }
                }

                else if (videoGameScreenChoice == "3") /// View all existing games
                {
                    if (!File.Exists($"{homeDirectory}\\videogames.json"))
                    {
                        Console.WriteLine("JSON data not found. Add a new Video Game then try again");
                    }
                    else
                    {
                        PrintAllVideoGames($"{homeDirectory}\\videogames.json");
                    }
                }
                else if (videoGameScreenChoice.ToUpper() == "B") return;
                else if (videoGameScreenChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }

        /// <summary>
        /// Prompt to enter information about the Video Game. Construct a VideoGame object from the information supplied by the user.
        /// </summary>
        /// <returns> A new video game object with data supplied by the user </returns>
        private VideoGame GetNewVideoGame()
        {
            Console.Write("Add a title for the game or press Enter to skip\n");
            string gameTitle = Console.ReadLine().ToUpper();

            Console.Write("Add a platform for the game or press Enter to skip\n");
            string gamePlatform = Console.ReadLine().ToUpper();

            Console.Write("Add a part number for the game or press Enter to skip\n");
            string gamePartNumber = Console.ReadLine().ToUpper();

            Console.Write("Add a UPC for the game or press Enter to skip\n");
            string gameUpc = Console.ReadLine();

            if (int.TryParse(gameUpc, out int gameUpcAsInteger)) { }
            else
            {
                Console.WriteLine($"{gameUpc} is not a valid UPC! A default value of 0 will be used.\n");
                gameUpcAsInteger = 0;
            }

            Console.Write("Add a description for the game or press Enter to skip\n");
            string gameDesc = Console.ReadLine().ToUpper();

            Console.Write("Add a cost for the game or press Enter to skip\n");
            string gameCost = Console.ReadLine();

            if (decimal.TryParse(gameCost, out decimal gameCostAsDecimal)) { }
            else
            {
                Console.WriteLine($"{gameCost} is not a valid cost! A default value of 0 will be used.\n");
                gameCostAsDecimal = 0;
            }

            Console.Write("Add a sell price for the game or press Enter to skip\n");
            string gamePrice = Console.ReadLine();

            if (decimal.TryParse(gamePrice, out decimal gamePriceAsDecimal)) { }
            else
            {
                Console.WriteLine($"{gamePrice} is not a valid sell price! A default value of 0 will be used.\n");
                gamePriceAsDecimal = 0;
            }

            return new VideoGame(gameTitle, gamePlatform, gamePartNumber, gameUpcAsInteger,
                gameDesc, gameCostAsDecimal, gamePriceAsDecimal);
        }

        /// <summary>
        /// Prints a single VideoGame object to the console as specified by the user.
        /// </summary>
        /// <param name="videoGameFilePath"> Path to videogames.json </param>
        /// <param name="title"> Title of the game to print </param>
        private void PrintVideoGame(string videoGameFilePath, string title)
        {
            List<VideoGame> jsonList = jsonConfig.GetDeserializedList(videoGameFilePath);

            foreach (var game in jsonList)
            {
                if (game.Title is null)
                {
                    continue;
                }
                else if (game.Title.ToUpper() == title.ToUpper())
                {
                    Console.Clear();
                    Console.WriteLine($"Title: {game.Title}");
                    Console.WriteLine($"Platform: {game.Platform}");
                    Console.WriteLine($"Part Number: {game.PartNumber}");
                    Console.WriteLine($"UPC: {game.UPC}");
                    Console.WriteLine($"Description: {game.Description}");
                    Console.WriteLine($"Cost: {game.Cost}");
                    Console.WriteLine($"Sell price: {game.SellPrice}");
                    Console.WriteLine("\n");
                    goto returnToMainMenu;
                }
            }
            Console.WriteLine($"{title} was not found as a stored Video Game");
        returnToMainMenu:
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }

        /// <summary>
        /// Print all VideoGame objects and their properties to the console.
        /// </summary>
        /// <param name="videoGameFilePath"> File path to videogames.json </param>
        private void PrintAllVideoGames(string videoGameFilePath)
        {
            List<VideoGame> jsonList = jsonConfig.GetDeserializedList(videoGameFilePath);

            foreach (var game in jsonList)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Title: {game.Title}");
                Console.WriteLine($"Platform: {game.Platform}");
                Console.WriteLine($"Part Number: {game.PartNumber}");
                Console.WriteLine($"UPC: {game.UPC}");
                Console.WriteLine($"Description: {game.Description}");
                Console.WriteLine($"Cost: {game.Cost}");
                Console.WriteLine($"Sell price: {game.SellPrice}");
            }
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }
    }
}
