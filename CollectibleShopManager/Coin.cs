namespace CollectibleShopManager
{
    internal class Coin : Inventory
    {
        public int Year { get; private set; }

        public Coin() { }

        public Coin(int year, string partNumber, int upc, string desc, decimal cost, decimal sellPrice) 
            : base(partNumber, upc, desc, cost, sellPrice) // Inherited from Inventory class
        {
            Year = year;
        }
    }
}
