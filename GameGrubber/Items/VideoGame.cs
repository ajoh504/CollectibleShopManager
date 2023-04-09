using GameGrubber.Database;

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

        public string? Title
        {
            get { return title; }
            set
            {
                if (value == null)
                {
                    platform = null;
                }
                else
                {
                    title = value;
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
                else
                {
                    platform = value;
                }
            }
        }

        public VideoGame()
        {
            tableName = "video_game";
            nonQuery = new DatabaseNonQuery();
            valueSearch = new DatabaseValueSearch();
            inventoryId = valueSearch.GetNextAvailableID(tableName);
        }

        public override void AddNewRow()
        {
            nonQuery.NewRow(tableName, inventoryId);
            nonQuery.UpdateRow(tableName, itemCodeColumn, itemCode, inventoryId);
            nonQuery.UpdateRow(tableName, descriptionColumn, description, inventoryId);
            nonQuery.UpdateRow(tableName, costColumn, cost, inventoryId);
            nonQuery.UpdateRow(tableName, sellPriceColumn, sellPrice, inventoryId);
            nonQuery.UpdateRow(tableName, platformColumn, platform, InventoryID);
            nonQuery.UpdateRow(tableName, titleColumn, title, InventoryID);
            inventoryId = valueSearch.GetNextAvailableID(tableName);
        }
    }
}