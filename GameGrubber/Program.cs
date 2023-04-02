using System.Data.SQLite;
using GameGrubber.ConsoleMenu;

namespace GameGrubber
{
    internal class Program
    {
        public static string mainDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\GameGrubber";
        public static string databasePath = $"{mainDir}\\ggdb.sqlite";

        /// <summary>
        /// Defines the main menu execution flow
        /// </summary>
        static void Main(string[] args)
        {
            // Create the main program directory in the user's home directory.
            Directory.CreateDirectory(mainDir);

            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }
            
            MainMenu.Execute();
        }
    }
}     