namespace CollectibleShopManager
{
    internal class VideoGame : Inventory
    {
        public string? Platform { get; private set; }
        public VideoGame() { }
        public VideoGame(string? name, string? platform, string desc, decimal cost, decimal sellPrice) 
            : base(name, desc, cost, sellPrice) // Inherited from Inventory class
        {
            Platform = platform;
        }
    }
}