using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGrubber.InventoryItems
{
    internal class StrategyGuide : Inventory
    {
        private string? publisher;
        private int? isbn;

        public string? Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public int? ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
    }
}
