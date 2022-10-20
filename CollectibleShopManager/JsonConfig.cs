using System.Runtime.CompilerServices;
using System.Text.Json;

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
        /// If JSON file does not exist, pass the VideoGame object into a new List, serialize it,
        /// then write it to a new JSON file.
        /// </summary>
        /// <param name="filePath"> file path for Video Game JSON data </param>
        /// <param name="videoGame"> new VideoGame object to write to JSON file </param>
        public void CreateNewFile(string filePath, VideoGame videoGame)
        {
            List<VideoGame> gameToAdd = new List<VideoGame>() { videoGame };
            string jsonData = JsonSerializer.Serialize<List<VideoGame>>(gameToAdd, this.GetSettings());
            File.WriteAllText(filePath, jsonData);
        }

        public void WriteToFile(string filePath, VideoGame videoGame)
        {
            string? jsonFileData = GetJsonAsString(filePath);
            if (jsonFileData is null)
            {

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
