namespace GameGrubber.InventoryItems
{
    /// <summary>
    /// Defines a Video Game inventory item. This class inherits from the Inventory base class.
    /// </summary>
    internal class VideoGame : Inventory
    {
        private string? title;
        private string? platform;
        private const string titleColumn = "title";
        private const string platformColumn = "platform";

        public VideoGame()
        {
            tableName = "video_game";
        }

        public string? Title
        {
            get { return title; }
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
                    UpdateRow(tableName, titleColumn, "", InventoryID);
                }
                else
                {
                    title = value;
                    UpdateRow(tableName, titleColumn, value, InventoryID);
                }
            }
        }
        public string? Platform
        {
            get { return platform; }
            set
            {
                if (value == null)
                {
                    platform = null;
                }
                else if (value.Length > 20)
                {
                    Console.WriteLine("Invalid platform length. Default value set to null");
                    platform = null;
                    UpdateRow(tableName, platformColumn, "", InventoryID);
                }
                else
                {
                    platform = value;
                    UpdateRow(tableName, platformColumn, value, InventoryID);
                }
            }
        }

    }
}