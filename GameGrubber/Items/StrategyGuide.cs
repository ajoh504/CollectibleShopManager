using GameGrubber.Database;

namespace GameGrubber.InventoryItems
{
    internal class StrategyGuide : Inventory
    {
        private int inventoryId;
        private string? publisher;
        private int isbn;
        private const string publisherColumn = "publisher";
        private const string isbnColumn = "isbn";
        private DatabaseNonQuery nonQuery;
        private DatabaseValueSearch valueSearch;

        public int InventoryID
        {
            get { return inventoryId; }
        }

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
            base.AddNewRow();
            nonQuery.UpdateRow(tableName, publisherColumn, publisher, InventoryID);
            nonQuery.UpdateRow(tableName, isbnColumn, isbn, InventoryID);
        }
    }
}
