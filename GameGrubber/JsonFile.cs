using System.Text.Json;
using GameGrubber.InventoryItems;

namespace GameGrubber
{
    /// <summary>
    /// Defines all methods for reading from and writing to the inventory JSON files. 
    /// </summary>
    /// <remarks>
    /// Each collectible item has its own JSON file. The files are stored in the following location: %USERPROFILE%\GameGrubber
    /// </remarks>
    internal class JsonFile<T> where T : Inventory
    {
        private string jsonFilePath;
        public string JsonFilePath
        {
            get { return jsonFilePath; } 
            set { jsonFilePath = value; }
        }

        private JsonSerializerOptions GetWhiteSpaceFormatting()
        {
            JsonSerializerOptions jsonSettings = new JsonSerializerOptions();
            jsonSettings.WriteIndented = true;
            return jsonSettings;
        }

        /// <summary>
        /// Creates a JSON file for the given inventory type.
        /// </summary>
        /// <typeparam name="T"> Inventory type </typeparam>
        public void CreateNewFile<T>()
        {
            List<T> emptyFile = new List<T>();
            string jsonData = JsonSerializer.Serialize(emptyFile, this.GetWhiteSpaceFormatting());
            File.WriteAllText(jsonFilePath, jsonData);
        }

        /// <summary>
        /// Read all JSON text into a string. Deserialize the string, then return the List as specified by the user
        /// </summary>
        /// <returns> A list of Inventory objects for the given type. </returns>
        public List<T> GetDeserializedList<T>()
        {
            string jsonFileData = File.ReadAllText(jsonFilePath);
            List<T> jsonList = JsonSerializer.Deserialize<List<T>>(jsonFileData);
            return jsonList;
        }

        /// <summary>
        /// Write a new Inventory object (or any class derived from the Inventory class) to a JSON file. 
        /// </summary>
        public void WriteToFile<T>(T inventory)
        {
            List<T> jsonList = GetDeserializedList<T>();   
            jsonList.Add(inventory);
            string serializedList = JsonSerializer.Serialize(jsonList, this.GetWhiteSpaceFormatting());
            File.WriteAllText(jsonFilePath, serializedList);
        }
    }
}
