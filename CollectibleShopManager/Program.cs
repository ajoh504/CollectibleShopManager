using System.Reflection;

namespace CollectibleShopManager
{
    internal class Program
    {
        /// <summary>
        /// Defines the main menu execution flow
        /// </summary>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
This utility can be used to store your collectibles. 
Please select one of the following:");

                Console.Write(@"
Video Game Menu Screen .... 1 
Quit to Desktop ........... Q
");

                string mainMenuChoice = Console.ReadLine();

                if (mainMenuChoice == "1")
                {
                    MenuSelectionScreen videoGameMenu = new MenuSelectionScreen("Video Game");
                    videoGameMenu.Execute();
                }
                else if (mainMenuChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}