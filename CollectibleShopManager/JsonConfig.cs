﻿using System.Text.Json;

namespace CollectibleShopManager
{
    internal class JsonConfig
    {
        /// <summary>
        /// Instantiate an object of type JsonSerializerOptions. Set WriteIndented property to true 
        /// in order to format any serialized / deserialized JSON data with white spaces.
        /// </summary>
        /// <returns> JsonSerializerOptions object to format a JSON file with white spaces. </returns>
        private JsonSerializerOptions GetSettings()
        {
            JsonSerializerOptions jsonSettings = new JsonSerializerOptions();
            jsonSettings.WriteIndented = true;
            return jsonSettings;
        }

        /// <summary>
        /// Read all JSON text into a string then return the string.
        /// </summary>
        /// <param name="filePath"> file path to JSON file </param>
        /// <returns> String containing JSON file data </returns>
        private string GetJsonAsString(string filePath)
        {
            string jsonFileData = File.ReadAllText(filePath);
            return jsonFileData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="videoGame"></param>
        /// <param name="title"></param>
        public void PrintSingleObject(string filePath, string title)
        {
            string jsonFileData = File.ReadAllText(filePath);
            List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);

            foreach (var game in jsonList)
            {
                if (game.Name.ToUpper() == title.ToUpper())
                {
                    Console.Clear();
                    Console.WriteLine($"Title: {game.Name}");
                    Console.WriteLine($"Platform: {game.Platform}");
                    Console.WriteLine($"Description: {game.Description}");
                    Console.WriteLine($"Cost: {game.Cost}");
                    Console.WriteLine($"Sell price: {game.SellPrice}");
                    Console.WriteLine("\n");
                }
                else Console.WriteLine($"{title} not found");
            }
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }

        public void PrintAllObjects(string filePath)
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

        /// <summary>
        /// Pass the VideoGame object into a new List, serialize it into a string, then write the string 
        /// to a new JSON file.
        /// </summary>
        /// <param name="filePath"> file path for Video Game JSON data </param>
        /// <param name="videoGame"> new VideoGame object to write to JSON file </param>
        public void CreateNewFile(string filePath, VideoGame videoGame)
        {
            List<VideoGame> gameToAdd = new List<VideoGame>() { videoGame };
            string jsonData = JsonSerializer.Serialize<List<VideoGame>>(gameToAdd, this.GetSettings());
            File.WriteAllText(filePath, jsonData);
        }

        /// <summary>
        /// Call GetJsonAsString() to retrieve the JSON file data. Deserialize the string into a 
        /// List of VideoGame objects, append the new VideoGame object to the list. Then, re-serialize
        /// the List and overwrite the JSON file. 
        /// </summary>
        /// <param name="filePath"> path to JSON file </param>
        /// <param name="videoGame"> new VideoGame object to add to the file </param>
        public void WriteToFile(string filePath, VideoGame videoGame)
        {
            string? jsonFileData = GetJsonAsString(filePath);

            List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);
            jsonList.Add(videoGame);

            string serializedList = JsonSerializer.Serialize(jsonList, this.GetSettings());
            File.WriteAllText(filePath, serializedList);
        }
    }
}
