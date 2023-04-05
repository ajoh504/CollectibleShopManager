namespace GameGrubber.InventoryItems
{
    internal class VideoGameConsole : Inventory
    {
        private string? regionCode;
        private string? modelNumber;
        private string? brandName;
        private string? color;
        private bool? hasCustomTheme;

        public VideoGameConsole() 
        {
            tableName = "video_game_console";
        }

        public string? RegionCode
        {
            get { return regionCode; }
            set { regionCode = value; }
        }

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

        public bool? HasCustomTheme
        {
            get { return hasCustomTheme; }
            set { hasCustomTheme= value; }
        }
    }
}

