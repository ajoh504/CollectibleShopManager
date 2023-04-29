using GameGrubber.ConsoleMenu;
using GameGrubber.Database;

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
                DatabaseBuilder builder = new DatabaseBuilder();
                builder.Execute();
            }
            MainMenu mainMenu = new MainMenu();
            mainMenu.Execute();
        }
    }
}     