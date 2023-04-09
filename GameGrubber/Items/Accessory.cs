using GameGrubber.Database;

namespace GameGrubber.InventoryItems
{
    internal class Accessory : Inventory
    {
        private string? category;
        private const string categoryColumn = "category";
        private DatabaseNonQuery nonQuery;

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
        }

        public override void AddNewRow()
        {
            base.AddNewRow();
            nonQuery.UpdateRow(tableName, categoryColumn, category, InventoryID);
        }
    }
}
