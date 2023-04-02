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
        /// Insert an decimal value into the specified table and column
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
