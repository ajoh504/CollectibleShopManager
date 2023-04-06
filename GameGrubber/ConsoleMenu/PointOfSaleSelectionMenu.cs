using GameGrubber.Items;

namespace GameGrubber.ConsoleMenu
{
    internal class PointOfSaleSelectionMenu
    {
        public static void Execute()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
____________________________________________________

Point of Sale Selection Menu
Please select one of the following:
____________________________________________________");

                Console.Write(@"
Make a sale ..................... 1
Go back ......................... B
Quit to desktop ................. Q
");

                string posMenuChoice = Console.ReadLine();
                if (posMenuChoice == "1")
                {
                    Invoice invoice = new Invoice();
                    invoice.AddNewRow();
                }
                else if (posMenuChoice.ToUpper() == "B") return;
                else if (posMenuChoice.ToUpper() == "Q") Environment.Exit(0);
            }
        }
    }
}
