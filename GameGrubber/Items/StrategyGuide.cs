using GameGrubber.Database;

namespace GameGrubber.InventoryItems
{
    internal class StrategyGuide : Inventory
    {
        private string? publisher;
        private int isbn;
        private const string publisherColumn = "publisher";
        private const string isbnColumn = "isbn";
        private DatabaseNonQuery nonQuery;

        public StrategyGuide()
        {
            tableName = "strategy_guide";
            nonQuery = new DatabaseNonQuery();
        }

        public string? Publisher
        {
            get { return publisher; }
            set 
            { 
                publisher = value;
                nonQuery.UpdateRow(tableName, publisherColumn, value, InventoryID);
            }
        }

        public int ISBN
        {
            get { return isbn; }
            set 
            { 
                isbn = value;
                nonQuery.UpdateRow(tableName, isbnColumn, value, InventoryID);
            }
        }
    }
}
