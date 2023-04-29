using System.Collections.Specialized;
using System.Data.SQLite;
using System.Text;

namespace GameGrubber.Database
{
    internal class DatabaseValueSearch
    {
        /// <summary>
        /// Return an opened database connection object
        /// </summary>
        private SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection($"Data Source={Program.databasePath};Version=3;");
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Return a SQLiteDataReader object
        /// </summary>
        private SQLiteDataReader GetReader(string query)
        {
            SQLiteConnection connection = GetConnection();
            SQLiteCommand command = new SQLiteCommand(query, connection);
            return command.ExecuteReader();
        }

        /// <summary>
        /// Return true if the string value exists in the database, false otherwise
        /// </summary>
        public bool Exists(string table, string column, string value)
        {
            string query = $"SELECT {column} FROM {table}";
            using(SQLiteDataReader reader = GetReader(query)) 
            {
                while (reader.Read())
                {
                    NameValueCollection collection = reader.GetValues();
                    if (collection.Get(column) == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Return true if the decimal value exists in the database, false otherwise
        /// </summary>
        public bool Exists(string table, string column, decimal value)
        {
            string query = $"SELECT {column} FROM {table}";
            using (SQLiteDataReader reader = GetReader(query))
            {
                while (reader.Read())
                {
                    NameValueCollection collection = reader.GetValues();
                    if (collection.Get(column) == value.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Return true if the integer value exists in the database, false otherwise
        /// </summary>
        public bool Exists(string table, string column, int value)
        {
            string query = $"SELECT {column} FROM {table}";
            using (SQLiteDataReader reader = GetReader(query))
            {
                while (reader.Read())
                {
                    NameValueCollection collection = reader.GetValues();
                    if (collection.Get(column) == value.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns true if the inventory item code exists in the database, false otherwise
        /// </summary>
        /// <param name="value"> Item code to search for </param>
        /// <param name="tableName"> Table name where the item code is stored in the database </param>
        public bool ItemCodeExists(string value, out string tableName)
        {
            string[] tableNames = new string[]
            {
                "accessory", 
                "controller", 
                "inventory",
                "strategy_guide", 
                "video_game", 
                "video_game_console"
            };

            foreach (string table in tableNames)
            {
                if (Exists(table, "item_code", value))
                {
                    tableName = table;
                    return true;
                }
            }
            tableName = "";
            return false;
        }

        /// <summary>
        /// Retrieve the next available rowid from the database table
        /// </summary>
        /// <param name="table"> Table name to search through </param>
        /// <returns> The next available rowid </returns>
        public int GetNextAvailableID(string table)
        {
            List<int> availableIDs = new List<int>();
            string query = $"SELECT id FROM {table}";
            using (SQLiteDataReader reader = GetReader(query))
            {
                while (reader.Read())
                {
                    availableIDs.Add(reader.GetInt32(0));
                }
            }
            if (availableIDs.Count == 0) return 0;
            return availableIDs.Last() + 1;
        }

        /// <summary>
        /// Get a formatted string list of all row values from the specified table, separated by commas
        /// </summary>
        /// <param name="table"> Table to select values from </param>
        /// <returns> A string list of all row values </returns>
        public List<string> SelectAllFormatted(string table)
        {
            List<string> values = new List<string>();
            string query = $"SELECT * FROM {table}";
            using (SQLiteDataReader reader = GetReader(query))
            {
                while (reader.Read())
                {
                    NameValueCollection rowValues = reader.GetValues();
                    StringBuilder sb = new StringBuilder();
                    foreach (string key in rowValues.AllKeys)
                    {
                        sb.Append($"{key.ToUpper()}: {rowValues[key]}");
                        sb.Append(", ");
                    }
                    sb.Remove(sb.Length - 1, 1); // remove final comma
                    values.Add(sb.ToString());
                }
            }
            return values;
        }

        /// <summary>
        /// Get a string of all row values from the specified database column
        /// </summary>
        /// <param name="table"> Table to select from </param>
        /// <param name="id"> id of the row to select from </param>
        /// <returns> A string of all row values, separated by commas </returns>
        public string SelectSingleRow(string table, int id)
        {
            string query = $"SELECT * FROM {table} WHERE id = {id}";
            using (SQLiteDataReader reader = GetReader(query))
            {
                while (reader.Read())
                {
                    NameValueCollection rowValues = reader.GetValues();
                    StringBuilder sb = new StringBuilder();
                    foreach (string key in rowValues.AllKeys)
                    {
                        sb.Append(rowValues[key]);
                        sb.Append(", ");
                    }
                    sb.Remove(sb.Length - 1, 1); // remove final comma
                    return sb.ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// Select a single value from the database where a comparable value is of type VARCHAR
        /// </summary>
        /// <remarks>
        /// Sample query as a formatted string:
        /// $"SELECT {selectableColumn} FROM {table} WHERE {comparableColumn} = '{comparableVarcharValue}'";
        /// </remarks>
        /// <param name="selectableColumn"> Database column to select from </param>
        /// <param name="table"> Database table to query </param>
        /// <param name="comparableColumn"> Database column to compare values </param>
        /// <param name="comparableVarcharValue"> VARCHAR value to compare </param>
        /// <returns> A string value from the selectable column </returns>
        public string SelectSingleValue(string selectableColumn, string table, string comparableColumn, string comparableVarcharValue)
        {
            string query = $"SELECT {selectableColumn} FROM {table} WHERE {comparableColumn} = '{comparableVarcharValue}'";
            using (SQLiteDataReader reader = GetReader(query))
            {
                NameValueCollection rowValues = reader.GetValues();
                return rowValues[selectableColumn];
            }
        }

        /// <summary>
        /// Select a single value from the database by its id
        /// </summary>
        /// <remarks>
        /// Sample query as a formatted string:
        /// $"SELECT {selectableColumn} FROM {table} WHERE {comparableColumn} = '{id}'";
        /// </remarks>
        /// <param name="selectableColumn"> Database column to select from </param>
        /// <param name="table"> Database table to query </param>
        /// <param name="id"> id value </param>
        /// <returns> A string value from the selectable column </returns>
        public string SelectValueById(string selectableColumn, string table, int id)
        {
            string query = $"SELECT {selectableColumn} FROM {table} WHERE id = {id}";
            using (SQLiteDataReader reader = GetReader(query))
            {
                NameValueCollection rowValues = reader.GetValues();
                return rowValues[selectableColumn];
            }
        }

        /// <summary>
        /// Return true if the database table is empty, false otherwise
        /// </summary>
        /// <param name="tableName">Table to check for empty rows</param>
        public bool TableIsEmpty(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            using(SQLiteDataReader reader = GetReader(query))
            {
                NameValueCollection values = reader.GetValues();
                return !reader.HasRows;
            }
        }
    }
}
