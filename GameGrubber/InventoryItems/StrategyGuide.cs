namespace GameGrubber.InventoryItems
{
    internal class StrategyGuide : Inventory
    {
        private string? publisher;
        private int? isbn;

        public StrategyGuide()
        {
            tableName = "strategy_guide";
        }

        public string? Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public int? ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
    }
}
