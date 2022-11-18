using System.Text.Json;

namespace CollectibleShopManager
{
    /// <summary>
    /// Defines all methods for reading from and writing to the inventory.json file. This file is stored in the 
    /// user's home directory.
    /// </summary>
    internal class JsonFileConfiguration<T>
    {
        public T ObjectType { get { return ObjectType; } set { ObjectType = value; } }
        public string jsonFilePath;

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
        /// Create the inventory.json file. 
        /// </summary>
        private void CreateNewFile<ObjectType>()
        {
            List<ObjectType> emptyFile = new List<ObjectType>();
            string jsonData = JsonSerializer.Serialize(emptyFile, this.GetWhiteSpaceFormatting());
            File.WriteAllText(jsonFilePath, jsonData);
        }

        /// <summary>
        /// Read all JSON text into a string. Deserialize the string, then return the List as specified by the user
        /// </summary>
        /// <returns> List of Inventory objects from inventory.json </returns>
        public List<ObjectType> GetDeserializedList<ObjectType>()
        {
            string jsonFileData = File.ReadAllText(jsonFilePath);
            List<ObjectType> jsonList = JsonSerializer.Deserialize<List<ObjectType>>(jsonFileData);
            return jsonList;
        }

        /// <summary>
        /// Write a new Inventory object to inventory.json. First call GetJsonAsString() to retrieve the JSON file data. 
        /// Deserialize the string into a List of Inventory objects, append the new Inventory object to the list. Then, 
        /// re-serialize the List and save over the inventory.json file. 
        /// </summary>
        public void WriteToFile<ObjectType>(ObjectType inventory)
        {
            if (!File.Exists(jsonFilePath))
            {
                CreateNewFile<ObjectType>();
            }

            List<ObjectType > jsonList = GetDeserializedList<ObjectType>();   
            jsonList.Add(inventory);

            string serializedList = JsonSerializer.Serialize(jsonList, this.GetWhiteSpaceFormatting());
            File.WriteAllText(jsonFilePath, serializedList);
        }
    }
}
