namespace CollectibleShopManager
{
    internal class Inventory
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Cost { get; private set; }
        public decimal SellPrice { get; private set; }

        public bool IsPropertyFound(Inventory inventory, string property)
        {
            return false;
        }

        public bool IsPropertyFound(Inventory inventory, decimal property)
        {
            return false;
        }

        public Inventory() { }
        public Inventory(string name, string desc, decimal cost, decimal sellPrice)
        {
            Name = name;
            Description = desc;
            Cost = cost;
            SellPrice = sellPrice;
        }
    }
}
