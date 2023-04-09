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

        public string? RegionCode
        {
            get { return regionCode; }
            set 
            { 
                regionCode = value;
            }
        }

        public string? ModelNumber
        {
            get { return modelNumber; }
            set 
            { 
                modelNumber = value;
            }
        }

        public string? BrandName 
        { 
            get { return brandName; }
            set 
            { 
                brandName = value;
            }
        }

        public string? Color
        {
            get { return color; }
            set 
            { 
                color = value;
            }
        }

        public bool? HasCustomTheme
        {
            get { return hasCustomTheme; }
            set 
            { 
                hasCustomTheme= value;
            }
        }

        public VideoGameConsole()
        {
            tableName = "video_game_console";
            nonQuery = new DatabaseNonQuery();
            valueSearch = new DatabaseValueSearch();
            inventoryId = valueSearch.GetNextAvailableID(tableName);
        }

        public override void AddNewRow()
        {
            nonQuery.NewRow(tableName, inventoryId);
            nonQuery.UpdateRow(tableName, itemCodeColumn, itemCode, inventoryId);
            nonQuery.UpdateRow(tableName, descriptionColumn, description, inventoryId);
            nonQuery.UpdateRow(tableName, costColumn, cost, inventoryId);
            nonQuery.UpdateRow(tableName, sellPriceColumn, sellPrice, inventoryId);
            nonQuery.UpdateRow(tableName, regionCodeColumn, regionCode, InventoryID);
            nonQuery.UpdateRow(tableName, modelNumberColumn, modelNumber, InventoryID);
            nonQuery.UpdateRow(tableName, brandNameColumn, brandName, InventoryID);
            nonQuery.UpdateRow(tableName, colorColumn, color, InventoryID);
            // Database accepts 0 or 1 as Boolean
            if (hasCustomTheme == true) nonQuery.UpdateRow(tableName, hasCustomThemeColumn, 1, InventoryID);
            else nonQuery.UpdateRow(tableName, hasCustomThemeColumn, 0, InventoryID);
            inventoryId = valueSearch.GetNextAvailableID(tableName);
        }
    }
}

