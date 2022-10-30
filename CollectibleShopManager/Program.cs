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

                string mainChoice = Console.ReadLine();

                if (mainChoice == "1")
                {
                    VideoGameMenu videoGameMenu = new VideoGameMenu();
                    videoGameMenu.Execute();
                }
                else if (mainChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}