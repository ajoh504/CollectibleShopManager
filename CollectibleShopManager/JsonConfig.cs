using System.Text.Json;

namespace CollectibleShopManager
{
    internal class JsonConfig
    {
        /// <summary>
        /// Instantiate an object of type JsonSerializerOptions. Set WriteIndented property
        /// to true in order to format any serialized / deserialized JSON data with white
        /// spaces.
        /// </summary>
        /// <returns>
        /// JsonSerializerOptions object to format a JSON file with white spaces.
        /// </returns>
        private JsonSerializerOptions GetSettings()
        {
            JsonSerializerOptions jsonSettings = new JsonSerializerOptions();
            jsonSettings.WriteIndented = true;
            return jsonSettings;
        }

        /// <summary>
        /// If JSON file exists, read all text into a string then return the string. If file
        /// path does not exists, return null.
        /// </summary>
        /// <param name="filePath">file path to JSON file</param>
        /// <returns>
        /// String containing JSON file data, or null if file path does not exist
        /// </returns>
        private string GetJsonAsString(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            else
            {
                string jsonFileData = File.ReadAllText(filePath);
                return jsonFileData;
            }
        }

        private void WriteToFile(string filePath, VideoGame videoGame)
        {
            string? jsonFileData = GetJsonAsString(filePath);
            if (jsonFileData is null)
            {
                List<VideoGame> gameToAdd = new List<VideoGame>() { videoGame };
                string jsonData = JsonSerializer.Serialize<List<VideoGame>>(gameToAdd, this.GetSettings());
                File.WriteAllText(filePath, jsonData);
            }
            else
            {
                List<VideoGame> jsonList = JsonSerializer.Deserialize<List<VideoGame>>(jsonFileData);
                jsonList.Add(videoGame);

                string serializedList = JsonSerializer.Serialize(jsonList, this.GetSettings());
                File.WriteAllText(filePath, serializedList);
            }
        }
    }
}
