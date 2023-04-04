namespace GameGrubber.InventoryItems
{
    internal class Accessory : Inventory
    {
        private readonly string tableName;
        private string? category;
        private const string categoryColumn = "category";

        public Accessory()
        {
            this.tableName = "accessory";
        }

        public string? Category 
        { 
            get { return category; } 
            set { category = value; }
        }
    }
}
