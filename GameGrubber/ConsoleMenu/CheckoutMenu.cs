using GameGrubber.Database;
using GameGrubber.Items;

namespace GameGrubber.ConsoleMenu
{
    internal class CheckoutMenu
    {
        private Invoice invoice;
        private DatabaseValueSearch databaseValueSearch;
        private List<string> itemsToSell;

        public CheckoutMenu() 
        { 
            invoice = new Invoice();
            databaseValueSearch = new DatabaseValueSearch();
            itemsToSell = new List<string>();   
        }

        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@"
____________________________________

Checkout
____________________________________

Complete the sale ................. C
Go back ........................... B
");

                string item = Console.ReadLine();
                if (item.ToUpper().Equals("B")) return;
                if (databaseValueSearch.ItemCodeExists(item)) 
                {
                    itemsToSell.Add(item);
                } 
                else Console.Write("Item code not found. Press enter to continue.");
            }
        }
    }
}
