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
        /// Provides an implementation for the inventory.json file to be deserialized to.
        /// </summary>
        /// <remarks>
        /// File structure: a Dictionary with string keys that represent each inventory subclass.
        /// The keys contain a List of that particular subclass. The list contains each instance 
        /// of the specified subclass.
        /// 
        /// Example:
        /// 
        /// {
        ///     "InventoryType1": 
        ///         [{first instance}, {second instance}],
        ///     "InventoryType2": 
        ///         [{first instance}, {second instance}]
        /// }
        /// </remarks>
        private class InventoryJsonFile
        {
            private Dictionary<string, List<Inventory>> inventoryJsonFile = new Dictionary<string, List<Inventory>>();
        }

        /// <summary>
        /// File path to inventory.json, stored in the user's home directory.
        /// </summary>
        public static readonly string jsonFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\inventory.json";

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
        public List<VideoGame> GetDeserializedList()
        {
            string jsonFileData = File.ReadAllText(jsonFilePath);
            List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);
            return jsonList;
        }

        /// <summary>
        /// Create the inventory.json file. Pass the Inventory object into a new List, serialize it into a string, 
        /// then write the string to a new JSON file.
        /// </summary>
        /// <param name="filePath"> File path to create the new JSON file </param>
        /// <param name="inventory"> New Inventory object to write to JSON file </param>
        public void CreateNewFile(VideoGame videoGame)
        {
            List<VideoGame> gameToAdd = new List<VideoGame>() { videoGame };
            string jsonData = JsonSerializer.Serialize(gameToAdd, this.GetWhiteSpaceFormatting());
            File.WriteAllText(jsonFilePath, jsonData);
        }

        /// <summary>
        /// Write a new Inventory object to inventory.json. First call GetJsonAsString() to retrieve the JSON file data. 
        /// Deserialize the string into a List of Inventory objects, append the new Inventory object to the list. Then, 
        /// re-serialize the List and save over the inventory.json file. 
        /// </summary>
        /// <param name="filePath"> File path to inventory.json </param>
        /// <param name="inventory"> New Inventory object to add to the file </param>
        public void WriteToFile(VideoGame videoGame)
        {
            List<VideoGame> jsonList = GetDeserializedList();
            jsonList.Add(videoGame);

            string serializedList = JsonSerializer.Serialize(jsonList, this.GetWhiteSpaceFormatting());
            File.WriteAllText(jsonFilePath, serializedList);
        }
    }
}
