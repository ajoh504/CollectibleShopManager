namespace GameGrubber.InventoryItems
{
    internal class Controller : Inventory
    {
        private readonly string tableName;
        private string? modelNumber;
        private string? brandName;
        private string? color;
        private string? connectionType;
        private bool? hasCustomTheme;
        private const string modelNumberColumn = "model_number";
        private const string brandNameColumn = "brand_name";
        private const string colorColumn = "color";
        private const string connectionTypeColumn = "connection_type";
        private const string hasCustomThemeColumn = "has_custom_theme";

        public Controller()
        {
            this.tableName = "controller";
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

