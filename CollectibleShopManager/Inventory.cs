namespace CollectibleShopManager
{
    internal class Inventory
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public decimal SellPrice { get; set; }

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
