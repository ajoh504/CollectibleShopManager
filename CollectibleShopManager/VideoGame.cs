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
                if (value == null)
                {
                    platform = null;
                }
                else if (value.Length > 50)
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
                if(value == null)
                {
                    platform = null;
                }
                else if(value.Length > 20)
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
    }
}