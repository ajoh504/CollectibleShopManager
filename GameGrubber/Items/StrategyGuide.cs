using GameGrubber.Database;

namespace GameGrubber.InventoryItems
{
    internal class StrategyGuide : Inventory
    {
        private string? publisher;
        private int isbn;
        private const string publisherColumn = "publisher";
        private const string isbnColumn = "isbn";

        public string? Publisher
        {
            get { return publisher; }
            set 
            { 
                publisher = value;
            }
        }

        public int ISBN
        {
            get { return isbn; }
            set 
            { 
                isbn = value;
            }
        }

        public StrategyGuide()
        {
            tableName = "strategy_guide";
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
            nonQuery.UpdateRow(tableName, publisherColumn, publisher, InventoryID);
            nonQuery.UpdateRow(tableName, isbnColumn, isbn, InventoryID);
            inventoryId = valueSearch.GetNextAvailableID(tableName);
        }
    }
}
