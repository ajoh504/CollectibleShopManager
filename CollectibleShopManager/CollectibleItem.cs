using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectibleShopManager
{
    internal abstract class CollectibleItem
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public decimal SellPrice { get; set; }

        public bool IsPropertyFound(CollectibleItem collectibleItem, string property)
        {
            return false;
        }

        public bool IsPropertyFound(CollectibleItem collectibleItem, decimal property)
        {
            return false;
        }

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
