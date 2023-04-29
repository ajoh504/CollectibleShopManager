namespace GameGrubber.ConsoleMenu
{
    internal class PointOfSaleSettingsMenu
    {
        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@"
____________________________________

Point of sale settings menu
____________________________________

Edit tax  ....................... 1
Go back ......................... B
Quit to desktop ................. Q
");

                string posMenuChoice = Console.ReadLine();
                if (posMenuChoice == "1") TaxMenu.Execute();
                else if (posMenuChoice.ToUpper() == "B") return;
                else if (posMenuChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
