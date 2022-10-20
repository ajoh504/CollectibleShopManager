namespace CollectibleShopManager
{
    internal class Coin : Inventory
    {
        public int Year { get; private set; }

        public Coin() { }

        public Coin(int year, string name, string desc, decimal cost, decimal sellPrice) 
            : base(name, desc, cost, sellPrice) // Inherited from Inventory class
        {

        }
    }
}
