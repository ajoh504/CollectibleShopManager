using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollectibleShopManager
{
    internal class Coin : CollectibleItem
    {
        public int Year { get; set; }

        public Coin() { }

        public Coin(int year, string name, string desc, decimal cost, decimal 
            sellPrice) : base(name, desc, cost, sellPrice)
        {

        }
    }
}
