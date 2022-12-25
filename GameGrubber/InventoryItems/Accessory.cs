using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGrubber.InventoryItems
{
    internal class Accessory : Inventory
    {
        private string? category;

        public string? Category 
        { 
            get { return category; } 
            set { category = value; }
        }
    }
}
