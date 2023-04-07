using GameGrubber.Database;

namespace GameGrubber.InventoryItems
{
    internal class VideoGameConsole : Inventory
    {
        private string? regionCode;
        private string? modelNumber;
        private string? brandName;
        private string? color;
        private bool? hasCustomTheme;
        private const string regionCodeColumn = "region_code";
        private const string modelNumberColumn = "model_number";
        private const string brandNameColumn = "brand_name";
        private const string colorColumn = "color";
        private const string hasCustomThemeColumn = "has_custom_theme";
        private DatabaseNonQuery nonQuery;

        public string? RegionCode
        {
            get { return regionCode; }
            set 
            { 
                regionCode = value;
                nonQuery.UpdateRow(tableName, regionCodeColumn, value, InventoryID);
            }
        }

        public string? ModelNumber
        {
            get { return modelNumber; }
            set 
            { 
                modelNumber = value;
                nonQuery.UpdateRow(tableName, modelNumberColumn, value, InventoryID);
            }
        }

        public string? BrandName 
        { 
            get { return brandName; }
            set 
            { 
                brandName = value;
                nonQuery.UpdateRow(tableName, brandNameColumn, value, InventoryID);
            }
        }

        public string? Color
        {
            get { return color; }
            set 
            { 
                color = value;
                nonQuery.UpdateRow(tableName, colorColumn, value, InventoryID);
            }
        }

        public bool? HasCustomTheme
        {
            get { return hasCustomTheme; }
            set 
            { 
                hasCustomTheme= value;
                // Database accepts 0 or 1 as Boolean
                if (value == false) nonQuery.UpdateRow(tableName, hasCustomThemeColumn, 0, InventoryID);
                if (value == true) nonQuery.UpdateRow(tableName, hasCustomThemeColumn, 1, InventoryID);
            }
        }

        public VideoGameConsole()
        {
            tableName = "video_game_console";
            nonQuery = new DatabaseNonQuery();
        }
    }
}

