using GameGrubber.Database;

namespace GameGrubber.InventoryItems
{
    internal class Accessory : Inventory
    {
        private int inventoryId;
        private string? category;
        private const string categoryColumn = "category";
        private DatabaseNonQuery nonQuery;
        private DatabaseValueSearch valueSearch;

        public int InventoryID
        {
            get { return inventoryId; }
        }

        public string? Category 
        { 
            get { return category; } 
            set 
            { 
                category = value;
            }
        }

        public Accessory()
        {
            tableName = "accessory";
            nonQuery = new DatabaseNonQuery();
            valueSearch = new DatabaseValueSearch();
            inventoryId = valueSearch.GetNextAvailableID(tableName);
        }

        public override void AddNewRow()
        {
            base.AddNewRow();
            nonQuery.UpdateRow(tableName, categoryColumn, category, inventoryId);
        }
    }
}
