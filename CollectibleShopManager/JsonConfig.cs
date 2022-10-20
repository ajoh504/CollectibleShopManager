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
        /// <summary>
        /// Instantiate an object of type JsonSerializerOptions. Set WriteIndented property
        /// to true in order to format any serialized / deserialized JSON data with white
        /// spaces.
        /// </summary>
        /// <returns>
        /// JsonSerializerOptions object to format a JSON file with white spaces.
        /// </returns>
        private static JsonSerializerOptions GetSettings()
        {
            JsonSerializerOptions jsonSettings = new JsonSerializerOptions();
            jsonSettings.WriteIndented = true;
            return jsonSettings;
        }

        /// <summary>
        /// If JSON file exists, read all text into a string then return the string. If file
        /// path does not exists, print a warning message to the console and return null.
        /// </summary>
        /// <param name="filePath">file path to JSON file</param>
        /// <returns>
        /// String containing JSON file data, or null if file path does not exist
        /// </returns>
        private static string GetJsonAsString(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON data not found. Add new object to file then try again");
                return null;
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
