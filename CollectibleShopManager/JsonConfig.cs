using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CollectibleShopManager
{
    internal static class JsonConfig
    {
        private static JsonSerializerOptions GetSettings()
        {
            /// <summary>
            /// Returns JSON settings to format a JSON file with white spaces
            /// </summary>
            JsonSerializerOptions jsonSettings = new JsonSerializerOptions();
            jsonSettings.WriteIndented = true;
            return jsonSettings;
        }

        private static string GetJsonAsString(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON data not found. Add new object to file then try again");
                return "";
            }
            else
            {
                string jsonFileData = File.ReadAllText(filePath);
                return jsonFileData;
            }
        }

        private static void WriteToFile(string filePath, VideoGame videoGame)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON data not found. Add new object to file then try again");
            }
            else
            {
                string jsonFileData = File.ReadAllText(filePath);
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
                Console.WriteLine("Press enter to return to the main menu");
                Console.ReadLine();
            }
        }
    }
}
