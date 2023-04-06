using System.Collections.Specialized;
using System.Data.SQLite;
using System.Dynamic;
using System.Text;

namespace GameGrubber.Database
{
    internal abstract class BaseTable
    {
        /// <summary>
        /// Return an opened database connection object
        /// </summary>
        protected SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection($"Data Source={Program.databasePath};Version=3;");
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Add a new row to the specified database table
        /// </summary>
        /// <param name="table"> Table to add a row to </param>
        /// <param name="id"> Number for rowid </param>
        protected void NewRow(string table, int id)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                string cmd = $"INSERT INTO {table} (id) values ({id})";
                using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieve the next available rowid from the database table
        /// </summary>
        /// <param name="table"> Table name to search through </param>
        /// <returns> The next available rowid </returns>
        protected int GetNextAvailableID(string table)
        {
            List<int> availableIDs = new List<int>();
            using (SQLiteConnection connection = GetConnection())
            {
                string cmd = $"SELECT id FROM {table}";
                using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            availableIDs.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            if (availableIDs.Count == 0) return 0;
            int nextAvailableID = availableIDs.Last() + 1;
            while (availableIDs.Contains(nextAvailableID))
            {
                nextAvailableID++;
            }
            return nextAvailableID;
        }

        /// <summary>
        /// Insert a string value into the specified table and column
        /// </summary>
        protected void UpdateRow(string table, string column, string value, int id) 
        {
            using(SQLiteConnection connection = GetConnection())
            {
                string cmd = $"UPDATE {table} SET {column} = '{value}' WHERE id = {id}";
                using(SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Insert an integer value into the specified table and column
        /// </summary>
        protected void UpdateRow(string table, string column, int value, int id)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                string cmd = $"UPDATE {table} SET {column} = {value} WHERE id = {id}";
                using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Insert a decimal value into the specified table and column
        /// </summary>
        protected void UpdateRow(string table, string column, decimal value, int id)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                string cmd = $"UPDATE {table} SET {column} = {value} WHERE id = {id}";
                using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Get a string list of all row values from the specified table, separated by commas
        /// </summary>
        /// <param name="table"> Table to select values from </param>
        /// <returns> A string list of all row values </returns>
        protected List<string> SelectAll(string table)
        {
            List<string> values = new List<string>();
            using (SQLiteConnection connection = GetConnection())
            {
                string cmd = $"SELECT * FROM {table}";
                using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
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
                            values.Add(sb.ToString());
                        }
                    }
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
        protected string SelectSingleRow(string table, int id)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                string cmd = $"SELECT * FROM {table} WHERE id = {id}";
                using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader()) 
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
                }
            }
            return "";
        }
    }
}
