namespace CollectibleShopManager
{
    /// <summary>
    /// Defines a Video Game inventory item. This class inherits from the Inventory base class.
    /// It contains one unique property: Platform, i.e. Sega Dreamcast, PlayStation, etc.
    /// </summary>
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