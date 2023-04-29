﻿using GameGrubber.Database;
using GameGrubber.Items;

namespace GameGrubber.ConsoleMenu
{
    internal class CheckoutMenu
    {
        private Invoice invoice;
        private DatabaseValueSearch databaseValueSearch;

        public CheckoutMenu() 
        { 
            invoice = new Invoice();
            databaseValueSearch = new DatabaseValueSearch();
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

Add item code .....................
Complete the sale ................. C
Go back ........................... B

{invoice.ItemsToSell}
Tax: ${invoice.Tax}
Subtotal: ${invoice.SubTotal}
");

                string item = Console.ReadLine();
                if (item.ToUpper().Equals("B")) return;
                else if (item.ToUpper().Equals("C"))
                {
                    invoice.AddNewRow();
                }
                else if (databaseValueSearch.ItemCodeExists(item, out string tableName)) 
                {
                    invoice.AddItemToSell(item, tableName);
                } 
                else
                {
                    Console.Write("Item code not found. Press enter to continue.");
                    Console.ReadLine();
                }
                
            }
        }
    }
}
