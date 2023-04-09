using GameGrubber.Database;

namespace GameGrubber.InventoryItems
{
    internal class Accessory : Inventory
    {
        private string? category;
        private const string categoryColumn = "category";

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
            nonQuery.NewRow(tableName, inventoryId);
            nonQuery.UpdateRow(tableName, itemCodeColumn, itemCode, inventoryId);
            nonQuery.UpdateRow(tableName, descriptionColumn, description, inventoryId);
            nonQuery.UpdateRow(tableName, costColumn, cost, inventoryId);
            nonQuery.UpdateRow(tableName, sellPriceColumn, sellPrice, inventoryId);
            nonQuery.UpdateRow(tableName, categoryColumn, category, inventoryId);
            inventoryId = valueSearch.GetNextAvailableID(tableName);
        }
    }
}
