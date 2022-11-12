using System.Reflection;

namespace CollectibleShopManager
{
    internal class MenuSelectionScreen /// Defines the Inventory Selection Screen
    {
        /// <summary>
        /// Specifies the inventory item for this instance of the menu screen. Use this property
        /// to print the appropriate questions to the console. For example, InventoryItem = "Video Game"
        /// will prompt the user to enter the appropriate information for that item.
        /// </summary>
        public string InventoryItem { get; private set; }
        private JsonFileConfiguration JsonConfig { get;  set; }

        public MenuSelectionScreen(string inventoryItem, ref JsonFileConfiguration jsonConfig)
        {
            InventoryItem = inventoryItem;
            JsonConfig = jsonConfig;
        }

        /// <summary>
        /// Prints a single Inventory object to the console as specified by the user.
        /// </summary>
        /// <param name="name"> Title of the Inventory object to print </param>
        private void PrintSingleInventoryObject(int ID)
        {
            List<VideoGame> jsonList = JsonConfig.GetDeserializedList();

            foreach (var inventoryObject in jsonList)
            {
                if (inventoryObject.InventoryID == ID)
                {
                    PropertyInfo[] inventoryPropertyInfo = inventoryObject.GetPropertyInfo();
                    Object[] inventoryPropertyValues = inventoryObject.GetPropertyValues();
                    for (int i = 0; i < inventoryPropertyValues.Length; i++)
                    {
                        Console.WriteLine($"{inventoryPropertyInfo[i].Name}: {inventoryPropertyValues[i]}");
                    }
                    Console.WriteLine('\n');
                    goto returnToMainMenu;
                }
            }
            Console.WriteLine($"{ID} is not associate with an {InventoryItem}");

        returnToMainMenu:
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }
        //private void PrintSingleInventoryObject(string name)
        //{
        //    List<VideoGame> jsonList = JsonConfig.GetDeserializedList();

        //    foreach (var inventoryObject in jsonList)
        //    {
        //        if (inventoryObject.Title.ToUpper() == name.ToUpper())
        //        {
        //            PropertyInfo[] inventoryPropertyInfo = inventoryObject.GetPropertyInfo();
        //            Object[] inventoryPropertyValues = inventoryObject.GetPropertyValues();
        //            for (int i = 0; i < inventoryPropertyValues.Length; i++)
        //            {
        //                Console.WriteLine($"{inventoryPropertyInfo[i].Name}: {inventoryPropertyValues[i]}");
        //            }
        //            Console.WriteLine('\n');
        //            goto returnToMainMenu;
        //        }
        //    }
        //    Console.WriteLine($"{name} was not found as a stored {InventoryItem}");

        //returnToMainMenu:
        //    Console.WriteLine("Press enter to return to the main menu");
        //    Console.ReadLine();
        //}

        /// <summary>
        /// Print all Inventory objects and their properties to the console.
        /// </summary>
        /// <param name="filePath"> File path to videogames.json </param>
        private void PrintAllInventoryObjects()
        {
            List<VideoGame> jsonList = JsonConfig.GetDeserializedList();

            foreach (var inventoryObject in jsonList)
            {
                PropertyInfo[] inventoryPropertyInfo = inventoryObject.GetPropertyInfo();
                Object[] inventoryPropertyValues = inventoryObject.GetPropertyValues();
                for (int i = 0; i < inventoryPropertyValues.Length; i++)
                {
                    Console.WriteLine($"{inventoryPropertyInfo[i].Name}: {inventoryPropertyValues[i]}");
                }
                Console.WriteLine('\n');
            }
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }

        /// <summary>
        /// Construct an Inventory object from the information supplied by the user.
        /// </summary>
        private VideoGame GetNewInventoryObject()
        {
            Console.Write("Add a title for the game or press Enter to skip\n");
            string gameTitle = Console.ReadLine().ToUpper();

            Console.Write("Add a platform for the game or press Enter to skip\n");
            string gamePlatform = Console.ReadLine().ToUpper();

            Console.WriteLine("Add an ID for the game or press Enter to skip. ID must be an integer");
            string gameID = Console.ReadLine();

            if (int.TryParse(gameID, out int gameIDAsInteger)) { }
            else
            {
                Console.WriteLine("Invalid ID. Please try again.");
            }

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

            return new VideoGame(gameTitle, gamePlatform, gameIDAsInteger, gamePartNumber, gameUpcAsInteger,
                gameDesc, gameCostAsDecimal, gamePriceAsDecimal);
        }

        public void Execute() /// Defines all logic for the menu execution flow
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($@"___________________________________

Selection: {InventoryItem} Menu Screen
Please select one of the following:
___________________________________");

                string lineOne = $"Add a new {InventoryItem }";
                string lineTwo = $"View a single  {InventoryItem}";
                string lineThree = $"View all {InventoryItem}s";
                string lineFour = "Go Back";
                string lineFive = "Quit to Desktop";

                Console.Write($@"
{lineOne.PadRight(32, '.')} 1
{lineTwo.PadRight(32, '.')} 2
{lineThree.PadRight(32, '.')} 3
{lineFour.PadRight(32, '.')} B
{lineFive.PadRight(32, '.')} Q
___________________________________
");

                string menuScreenChoice = Console.ReadLine();
                if (menuScreenChoice == "1") /// Add a new inventory object
                {
                    VideoGame inventoryObject = GetNewInventoryObject();
                    JsonConfig.WriteToFile(inventoryObject);
                }

                else if (menuScreenChoice == "2") /// View a single game
                {
                    Console.Write("Enter the ID of the game that you wish to view:\n");
                    string ID = Console.ReadLine();
                    if (int.TryParse(ID, out int IDAsInt))
                    {
                        Console.WriteLine("\n");
                        PrintSingleInventoryObject(IDAsInt);
                    }
                    else Console.WriteLine($"{ID} is invalid");
                }

                else if (menuScreenChoice == "3") /// View all existing games
                {
                    PrintAllInventoryObjects();
                }
                else if (menuScreenChoice.ToUpper() == "B") return;
                else if (menuScreenChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
