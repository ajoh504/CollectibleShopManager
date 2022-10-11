using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectibleShopManager
{
    internal class VideoGame : CollectibleItem
    {
        public string? Platform { get; private set; }
        public VideoGame() { }
        public VideoGame(string? name, string? platform, string desc, decimal cost, decimal sellPrice) 
            : base(name, desc, cost, sellPrice)
        {
            Platform = platform;
        }
    }
}