using GameGrubber.Database;
using GameGrubber.InventoryItems;

namespace GameGrubber.Items
{
    internal class Invoice : BaseTable

    {
        private int invoiceId;
        private string tableName;
        private DateTime date;
        private decimal price;
        private List<string> itemsSold;
        private const string dateColumn = "date";
        private const string priceColumn = "price";
        private const string itemsSoldColumn = "items_sold";

        public Invoice()
        {
            this.tableName = "invoice";
        }

        /// <summary>
        /// Add a new row to the database column
        /// </summary>
        public void AddNewRow()
        {
            string row = SelectSingleRow(tableName, invoiceId);
            if (row != "")
            {
                string[] _ = row.Split(",");
                string stringId = _[0];
                int currentId = Int32.Parse(stringId);
                if (currentId == invoiceId)
                {
                    invoiceId = GetNextAvailableID(tableName);
                    NewRow(tableName, invoiceId);
                    return;
                }
            }
            NewRow(tableName, invoiceId);
        }   
    }
}
