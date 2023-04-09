using GameGrubber.Database;

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
        private DatabaseNonQuery nonQuery;

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

        public string ConnectionType
        {
            get { return connectionType; }
            set 
            { 
                connectionType = value;
            }
        }

        public bool? HasCustomTheme
        {
            get { return hasCustomTheme; }
            set 
            {
                hasCustomTheme = value;
            }
        }

        public Controller()
        {
            tableName = "controller";
            nonQuery = new DatabaseNonQuery();
        }

        public override void AddNewRow()
        {
            base.AddNewRow();
            nonQuery.UpdateRow(tableName, modelNumberColumn, modelNumber, InventoryID);
            nonQuery.UpdateRow(tableName, brandNameColumn, brandName, InventoryID);
            nonQuery.UpdateRow(tableName, colorColumn, color, InventoryID);
            nonQuery.UpdateRow(tableName, connectionTypeColumn, connectionType, InventoryID);
            // Database accepts 0 or 1 as Boolean
            if (hasCustomTheme == true) nonQuery.UpdateRow(tableName, hasCustomThemeColumn, 1, InventoryID);
            else nonQuery.UpdateRow(tableName, hasCustomThemeColumn, 0, InventoryID);
        }
    }
}

