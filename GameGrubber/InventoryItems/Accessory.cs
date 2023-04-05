namespace GameGrubber.InventoryItems
{
    internal class Accessory : Inventory
    {
        private string? category;
        private const string categoryColumn = "category";

        public Accessory()
        {
            tableName = "accessory";
        }

        public string? Category 
        { 
            get { return category; } 
            set 
            { 
                category = value; 
                UpdateRow(tableName, categoryColumn, value, InventoryID);
            }
        }
    }
}
