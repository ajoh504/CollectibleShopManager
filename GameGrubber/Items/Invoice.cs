using GameGrubber.Database;

namespace GameGrubber.Items
{
    internal class Invoice
    {
        private int invoiceId;
        private string tableName;
        private DateTime date;
        private decimal price;
        private decimal subTotal;
        private List<string> itemsToSell;
        private List<string> itemsSold;
        private const string dateColumn = "date";
        private const string priceColumn = "price";
        private const string itemsSoldColumn = "items_sold";
        private DatabaseNonQuery nonQuery;
        private DatabaseValueSearch valueSearch;

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

        public decimal SubTotal
        {
            get { return subTotal; }
        }

        public Invoice()
        {
            this.tableName = "invoice";
            itemsSold = new List<string>();
            itemsToSell = new List<string>();
            nonQuery = new DatabaseNonQuery();
            valueSearch = new DatabaseValueSearch();
        }

        /// <summary>
        /// Add a new row to the database column
        /// </summary>
        public void AddNewRow()
        {
            nonQuery.NewRow(tableName, invoiceId);
            nonQuery.UpdateRow(tableName, dateColumn, date, invoiceId);
            nonQuery.UpdateRow(tableName, priceColumn, price, invoiceId);
            nonQuery.UpdateRow(tableName, itemsSoldColumn, Format(itemsSold), invoiceId);
        }

        /// <summary>
        /// Add an item to sell to update the subtotal
        /// </summary>
        public void AddItemToSell(string item, string tableName)
        {
            itemsToSell.Add(item);
            subTotal += GetPrice(item, tableName);
        }

        /// <summary>
        /// Add a comma delimiter to the items sold on this invoice, and convert the list to a 
        /// string value
        /// </summary>
        /// <param name="items"> String List to format </param>
        /// <returns> Formatted string to store in the database </returns>
        private string Format(List<string> items) => String.Join(',', items);

        private decimal GetPrice(string itemCode, string tableName)
        {
            string result = valueSearch.SelectSingleValue("sell_price", tableName, "item_code", itemCode);
            if (Decimal.TryParse(result, out decimal price))
            {
                return price;
            }
            else return 0;
        }
    }
}
