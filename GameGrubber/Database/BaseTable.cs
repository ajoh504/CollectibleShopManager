using System.Collections.Specialized;
using System.Data.SQLite;
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

        protected void NewRow(string table, int id)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                string cmd = $"INSERT INTO {table} (inventory_id) values ({id})";
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
                string cmd = $"SELECT inventory_id FROM {table}";
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
                string cmd = $"UPDATE {table} SET {column} = '{value}' WHERE inventory_id = {id}";
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
                string cmd = $"UPDATE {table} SET {column} = {value} WHERE inventory_id = {id}";
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
                string cmd = $"UPDATE {table} SET {column} = {value} WHERE inventory_id = {id}";
                using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string> SelectAll(string table)
        {
            List<object> objects = new List<object>();
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
                            sb.Remove(sb.Length - 1, 1);
                            objects.Add(sb.ToString());
                        }
                    }
                }
            }

            foreach (object item in objects)
            {
                values.Add((string)item);
            }
            return values;
        }
    }
}
