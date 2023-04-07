using System.Data.SQLite;

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
        /// Return true if the value exists in the database, false otherwise
        /// </summary>
        public bool Exists(string table, string column, string value)
        {
            using (SQLiteConnection connection = GetConnection())
            {

            }
            return false;
        }
    }
}
