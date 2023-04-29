using System.Data.SQLite;
using System.Runtime.InteropServices;

namespace GameGrubber.Database
{
    /// <summary>
    /// Defines a class for creating all data tables
    /// </summary>
    internal class DatabaseBuilder
    {
        private readonly string[] commands = new string[]
        {
            @"
CREATE TABLE inventory (
    id INTEGER PRIMARY KEY,
    item_code VARCHAR(14), 
    description VARCHAR(50),
    cost NUMERIC(10, 2),
    sell_price NUMERIC(10, 2)
)",
            @"
CREATE TABLE accessory (
    id INTEGER PRIMARY KEY,
    item_code VARCHAR(14), 
    description VARCHAR(50),
    cost NUMERIC(10, 2),
    sell_price NUMERIC(10, 2),
    category VARCHAR(20)
)",
            @"
CREATE TABLE controller (
    id INTEGER PRIMARY KEY,
    item_code VARCHAR(14), 
    description VARCHAR(50),
    cost NUMERIC(10, 2),
    sell_price NUMERIC(10, 2),
    model_number VARCHAR(10),
    brand_name VARCHAR(25),
    color VARCHAR(10),
    connection_type VARCHAR(10),
    has_custom_theme BOOLEAN
)",
            @"
CREATE TABLE strategy_guide (
    id INTEGER PRIMARY KEY,
    item_code VARCHAR(14), 
    description VARCHAR(50),
    cost NUMERIC(10, 2),
    sell_price NUMERIC(10, 2),
    publisher VARCHAR(20),
    isbn INT(13)
)",
            @"
CREATE TABLE video_game (
    id INTEGER PRIMARY KEY,
    item_code VARCHAR(14), 
    description VARCHAR(50),
    cost NUMERIC(10, 2),
    sell_price NUMERIC(10, 2),
    title VARCHAR(50),
    platform VARCHAR(20)
)",
            @"
CREATE TABLE video_game_console (
    id INTEGER PRIMARY KEY,
    item_code VARCHAR(14), 
    description VARCHAR(50),
    cost NUMERIC(10, 2),
    sell_price NUMERIC(10, 2),
    region_code VARCHAR(6),
    model_number VARCHAR(10),
    brand_name VARCHAR(25),
    color VARCHAR(10),
    has_custom_theme BOOLEAN
)",
            @"
CREATE TABLE invoice (
    id INTEGER PRIMARY KEY,
    price NUMERIC(10, 2),
    date DATETIME,
    items_sold VARCHAR(200)
)",
            @"
CREATE TABLE tax (
    id INTEGER PRIMARY KEY,
    tax_scheme NUMERIC(10)
)",

            @"
CREATE UNIQUE INDEX one_row_index ON tax (id)"
        };

        /// <summary>
        /// Return an opened database connection object
        /// </summary>
        private SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection($"Data Source={Program.databasePath};Version=3;");
            connection.Open();
            return connection;
        }

        public void Execute()
        {
            SQLiteConnection.CreateFile(Program.databasePath);
            using (SQLiteConnection connection = GetConnection())
            {
                foreach(string cmd in commands)
                {
                    using (SQLiteCommand command = new SQLiteCommand(cmd, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }                
            }
        }
    }
}
