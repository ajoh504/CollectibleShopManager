namespace CollectibleShopManager
{
    /// <summary>
    /// Defines a Video Game inventory item. This class inherits from the Inventory base class.
    /// </summary>
    internal class VideoGame : Inventory
    {
        private string? title;
        private string? platform;

        public string? Title
        {
            get
            {
                return title;
            }
            set
            {
                if(Title.Length > 50)
                {
                    Console.WriteLine("Invalid title length. Default value set to null");
                    title = null;
                }
                else
                {
                    title = value;
                }
            }
        }
        public string? Platform
        {
            get
            {
                return platform;
            }
            set
            {
                if(Platform.Length > 20)
                {
                    Console.WriteLine("Invalid platform length. Default value set to null");
                    platform = null;
                }
                else
                {
                    platform = value;
                }
            }
        }


        public VideoGame() { }
        public VideoGame(string? title, string? platform, int inventoryID, string? partNumber, string alternatePartNumber, string? desc, decimal cost, decimal sellPrice) 
            : base(inventoryID, partNumber, alternatePartNumber, desc, cost, sellPrice) // Inherited from Inventory class
        {
            Title = title;
            Platform = platform;
        }
    }
}