using System.Text.Json;

namespace CollectibleShopManager
{
    /// <summary>
    /// Defines all methods for reading from and writing to the JSON program files in the user's home directory.
    /// </summary>
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
        /// Read all JSON text into a string. Deserialize the string into a List of VideoGame objects, then
        /// return the List.
        /// </summary>
        /// <param name="videoGameFilePath"> File path to videogames.json </param>
        /// <returns> List of VideoGame objects from videogames.json </returns>
        public List<VideoGame> GetDeserializedList(string videoGameFilePath)
        {
            string jsonFileData = File.ReadAllText(videoGameFilePath);
            List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);
            return jsonList;
        }

        /// <summary>
        /// Create the file videogames.json. Pass the VideoGame object into a new List, serialize it into a string, 
        /// then write the string to a new JSON file.
        /// </summary>
        /// <param name="filePath"> File path to create the new JSON file </param>
        /// <param name="videoGame"> New VideoGame object to write to JSON file </param>
        public void CreateNewFile(string videoGameFilePath, VideoGame videoGame)
        {
            List<VideoGame> gameToAdd = new List<VideoGame>() { videoGame };
            string jsonData = JsonSerializer.Serialize(gameToAdd, this.GetSettings());
            File.WriteAllText(videoGameFilePath, jsonData);
        }

        /// <summary>
        /// Write a new VideoGame object to videogames.json. First call GetJsonAsString() to retrieve the JSON file data. 
        /// Deserialize the string into a List of VideoGame objects, append the new VideoGame object to the list. Then, 
        /// re-serialize the List and save over the file videogames.json. 
        /// </summary>
        /// <param name="videoGameFilePath"> File path to videogames.json </param>
        /// <param name="videoGame"> New VideoGame object to add to the file </param>
        public void WriteToFile(string videoGameFilePath, VideoGame videoGame)
        {
            List<VideoGame> jsonList = GetDeserializedList(videoGameFilePath);
            jsonList.Add(videoGame);

            string serializedList = JsonSerializer.Serialize(jsonList, this.GetSettings());
            File.WriteAllText(videoGameFilePath, serializedList);
        }
    }
}
