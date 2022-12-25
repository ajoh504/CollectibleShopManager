using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGrubber.InventoryItems
{
    internal class Controller : Inventory
    {
        private string? modelNumber;
        private string? brandName;
        private string? color;
        private string? connectionType;
        private bool? hasCustomTheme;


        public string? ModelNumber
        {
            get { return modelNumber; }
            set { modelNumber = value; }
        }

        public string? BrandName
        {
            get { return brandName; }
            set { brandName = value; }
        }

        public string? Color
        {
            get { return color; }
            set { color = value; }
        }

        public string ConnectionType
        {
            get { return connectionType; }
            set { connectionType = value; }
        }

        public bool? HasCustomTheme
        {
            get { return hasCustomTheme; }
            set { hasCustomTheme = value; }
        }
    }
}
}
