using GameGrubber.Database;
using GameGrubber.Items;

namespace GameGrubber.ConsoleMenu
{
    internal class CheckoutMenu
    {
        private Invoice invoice;
        private DatabaseValueSearch databaseValueSearch;
        private List<string> itemsToSell;
        private Subtotal subtotal;

        public CheckoutMenu() 
        { 
            invoice = new Invoice();
            databaseValueSearch = new DatabaseValueSearch();
            itemsToSell = new List<string>();  
            subtotal = new Subtotal();
        }

        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@$"
____________________________________

Checkout
____________________________________

Complete the sale ................. C
Go back ........................... B

{FormatItems(itemsToSell)}
Subtotal: {subtotal}
");

                string item = Console.ReadLine();
                if (item.ToUpper().Equals("B")) return;
                else if (item.ToUpper().Equals("C"))
                {
                    invoice.ItemsSold = itemsToSell;
                    invoice.Price = subtotal.Tally;
                    invoice.AddNewRow();
                }
                else if (databaseValueSearch.ItemCodeExists(item)) 
                {
                    itemsToSell.Add(item);
                } 
                else Console.Write("Item code not found. Press enter to continue.");
            }
        }

        /// <summary>
        /// Format the itemsToSell list as a string to print to the console
        /// </summary>
        private string FormatItems(List<string> itemToSell)
        {
            if (itemsToSell.Count == 0) return "";
            else return String.Join("\n", itemsToSell);
        }
    }
}
