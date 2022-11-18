namespace CollectibleShopManager
{
    internal class Coin : Inventory
    {
        public int Year { get; set; }

        public Coin() { }

        public Coin(int year, int inventoryID, string partNumber, int upc, string desc, decimal cost, decimal sellPrice) 
            : base(inventoryID, partNumber, upc, desc, cost, sellPrice) // Inherited from Inventory class
        {
            Year = year;
        }
    }
}
