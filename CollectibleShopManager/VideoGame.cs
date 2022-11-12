namespace CollectibleShopManager
{
    /// <summary>
    /// Defines a Video Game inventory item. This class inherits from the Inventory base class.
    /// </summary>
    internal class VideoGame : Inventory
    {
        public string? Title { get; set; }
        public string? Platform { get; set; }
        public VideoGame() { }
        public VideoGame(string? title, string? platform, int inventoryID, string? partNumber, int upc, string? desc, decimal cost, decimal sellPrice) 
            : base(inventoryID, partNumber, upc, desc, cost, sellPrice) // Inherited from Inventory class
        {
            Title = title;
            Platform = platform;
        }
    }
}