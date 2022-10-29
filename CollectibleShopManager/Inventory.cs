namespace CollectibleShopManager
{
    /// <summary>
    /// Defines a generic inventory item with no special properties. 
    /// </summary>
    /// <remarks>
    /// Provides a base class to inherit from. Any inventory item with unique or special properties
    /// cam inherit from the Inventory class. 
    /// </remarks>
    internal class Inventory
    {
        public string? PartNumber { get; set; }
        public int UPC { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public decimal SellPrice { get; set; }

        public bool IsPropertyFound(Inventory inventory, string property)
        {
            return false;
        }

        public bool IsPropertyFound(Inventory inventory, decimal property)
        {
            return false;
        }

        public Inventory() { }
        public Inventory(string partNumber, int upc, string desc, decimal cost, decimal sellPrice)
        {

            PartNumber = partNumber;
            UPC = upc;
            Description = desc;
            Cost = cost;
            SellPrice = sellPrice;
        }
    }
}
