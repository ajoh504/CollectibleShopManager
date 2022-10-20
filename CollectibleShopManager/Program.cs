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
                Console.WriteLine("This utility can be used to store your collectibles.");
                Console.Write("Press 1 for video games or Q to quit\n");
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