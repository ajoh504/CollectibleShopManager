using System.Data.SQLite;

namespace GameGrubber.Database
{
    internal class DatabaseNonQuery
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
        /// Add a new row to the specified database table
        /// </summary>
        /// <param name="table"> Table to add a row to </param>
        /// <param name="id"> Number for rowid </param>
        public void NewRow(string table, int id)
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
        /// Insert a string value into the specified table and column
        /// </summary>
        public void UpdateRow(string table, string column, string value, int id) 
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
        public void UpdateRow(string table, string column, int value, int id)
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
        public void UpdateRow(string table, string column, decimal value, int id)
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
    }
}
