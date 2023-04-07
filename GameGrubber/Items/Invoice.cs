using GameGrubber.Database;

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

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public decimal Price 
        {
            get { return price; }
            set { price = value; } 
        }

        public List<string> ItemsSold 
        {
            get { return itemsSold; }
            set { itemsSold = value; }
        }

        public Invoice()
        {
            this.tableName = "invoice";
            itemsSold = new List<string>();
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
