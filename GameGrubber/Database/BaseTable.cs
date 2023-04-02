using System.Data.SQLite;

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
        protected void Insert(string table, string column, string value) 
        {
            using(SQLiteConnection connection = GetConnection())
            {
                string cmd = $"INSERT INTO {table} ({column}) values ({value})";
                using(SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Insert an integer value into the specified table and column
        /// </summary>
        protected void Insert(string table, string column, int value)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                string cmd = $"INSERT INTO {table} ({column}) values ({value})";
                using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Insert a decimal value into the specified table and column
        /// </summary>
        protected void Insert(string table, string column, decimal value)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                string cmd = $"INSERT INTO {table} ({column}) values ({value})";
                using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
