namespace GameGrubber.Items
{
    internal class Invoice
    {
        private int invoiceId;
        private string tableName;
        private DateTime date;
        private decimal price;
        private List<string> itemsSold;

        public Invoice()
        {
            this.tableName = "invoice";
        }
    }
}
