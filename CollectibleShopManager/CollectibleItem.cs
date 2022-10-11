using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectibleShopManager
{
    internal abstract class CollectibleItem
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Cost { get; private set; }
        public decimal SellPrice { get; private set; }

        public CollectibleItem() { }
        public CollectibleItem(string name, string desc, decimal cost, decimal sellPrice)
        {
            Name = name;
            Description = desc;
            Cost = cost;
            SellPrice = sellPrice;
        }
    }
}
