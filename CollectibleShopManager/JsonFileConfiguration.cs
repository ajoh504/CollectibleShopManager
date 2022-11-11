using System.Text.Json;

namespace CollectibleShopManager
{
    /// <summary>
    /// Defines all methods for reading from and writing to the inventory.json file. This file is stored in the 
    /// user's home directory.
    /// </summary>
    internal class JsonFileConfiguration
    {
        /// <summary>
        /// Instantiate an object of type JsonSerializerOptions. Set WriteIndented property to true 
        /// in order to format any serialized / deserialized JSON data with white spaces.
        /// </summary>
        /// <returns> JsonSerializerOptions object to format a JSON file with white spaces. </returns>
        private JsonSerializerOptions GetWhiteSpaceFormatting()
        {
            JsonSerializerOptions jsonSettings = new JsonSerializerOptions();
            jsonSettings.WriteIndented = true;
            return jsonSettings;
        }

        /// <summary>
        /// Read all JSON text into a string. Deserialize the string, then return the List as specified by the user
        /// </summary>
        /// <param name="filePath"> File path to inventory.json </param>
        /// <returns> List of Inventory objects from inventory.json </returns>
        public List<VideoGame> GetDeserializedList(string filePath)
        {
            string jsonFileData = File.ReadAllText(filePath);
            List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);
            return jsonList;
        }

        /// <summary>
        /// Create the inventory.json file. Pass the Inventory object into a new List, serialize it into a string, 
        /// then write the string to a new JSON file.
        /// </summary>
        /// <param name="filePath"> File path to create the new JSON file </param>
        /// <param name="inventory"> New Inventory object to write to JSON file </param>
        public void CreateNewFile(string filePath, VideoGame videoGame)
        {
            List<VideoGame> gameToAdd = new List<VideoGame>() { videoGame };
            string jsonData = JsonSerializer.Serialize(gameToAdd, this.GetWhiteSpaceFormatting());
            File.WriteAllText(filePath, jsonData);
        }

        /// <summary>
        /// Write a new Inventory object to inventory.json. First call GetJsonAsString() to retrieve the JSON file data. 
        /// Deserialize the string into a List of Inventory objects, append the new Inventory object to the list. Then, 
        /// re-serialize the List and save over the inventory.json file. 
        /// </summary>
        /// <param name="filePath"> File path to inventory.json </param>
        /// <param name="inventory"> New Inventory object to add to the file </param>
        public void WriteToFile(string filePath, VideoGame videoGame)
        {
            List<VideoGame> jsonList = GetDeserializedList(filePath);
            jsonList.Add(videoGame);

            string serializedList = JsonSerializer.Serialize(jsonList, this.GetWhiteSpaceFormatting());
            File.WriteAllText(filePath, serializedList);
        }
    }
}
