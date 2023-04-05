namespace GameGrubber.InventoryItems
{
    internal class Controller : Inventory
    {
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
            tableName = "controller";
        }


        public string? ModelNumber
        {
            get { return modelNumber; }
            set 
            { 
                modelNumber = value;
                UpdateRow(tableName, modelNumberColumn, value, InventoryID);
            }
        }

        public string? BrandName
        {
            get { return brandName; }
            set 
            { 
                brandName = value;
                UpdateRow(tableName, brandNameColumn, value, InventoryID);
            }
        }

        public string? Color
        {
            get { return color; }
            set 
            { 
                color = value;
                UpdateRow(tableName, colorColumn, value, InventoryID);
            }
        }

        public string ConnectionType
        {
            get { return connectionType; }
            set 
            { 
                connectionType = value;
                UpdateRow(tableName, connectionTypeColumn, value, InventoryID);
            }
        }

        public bool? HasCustomTheme
        {
            get { return hasCustomTheme; }
            set 
            {
                hasCustomTheme = value;
                // Database accepts 0 or 1 as Boolean
                if (value == false) UpdateRow(tableName, hasCustomThemeColumn, 0, InventoryID);
                if (value == true) UpdateRow(tableName, hasCustomThemeColumn, 1, InventoryID);
            }
        }
    }
}

