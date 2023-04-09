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
        }

        public override void AddNewRow()
        {
            base.AddNewRow();
            nonQuery.UpdateRow(tableName, publisherColumn, publisher, InventoryID);
            nonQuery.UpdateRow(tableName, isbnColumn, isbn, InventoryID);
        }
    }
}
