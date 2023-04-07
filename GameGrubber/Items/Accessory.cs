using GameGrubber.Database;

namespace GameGrubber.InventoryItems
{
    internal class Accessory : Inventory
    {
        private string? category;
        private const string categoryColumn = "category";
        private DatabaseNonQuery nonQuery;

        public Accessory()
        {
            tableName = "accessory";
            nonQuery = new DatabaseNonQuery();
        }

        public string? Category 
        { 
            get { return category; } 
            set 
            { 
                category = value;
                nonQuery.UpdateRow(tableName, categoryColumn, value, InventoryID);
            }
        }
    }
}
