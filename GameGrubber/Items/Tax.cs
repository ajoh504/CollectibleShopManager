using GameGrubber.Database;

namespace GameGrubber.Items
{
    internal class Tax
    {
        private string tableName;
        private const string taxSchemeColumn = "tax_scheme";
        private decimal taxValue;
        private DatabaseNonQuery nonQuery;
        private DatabaseValueSearch valueSearch;

        public decimal Value
        {
            get { return taxValue; }
        }

        public Tax()
        {
            tableName = "tax";
            nonQuery = new DatabaseNonQuery();
            valueSearch = new DatabaseValueSearch();
            if (!valueSearch.TableIsEmpty(tableName))
                taxValue = Decimal.Parse(valueSearch.SelectValueById(taxSchemeColumn, tableName, 0));
            else taxValue = 0M;
        }

        /// <summary>
        /// Sets a new tax scheme
        /// </summary>
        public void UpdateTax(decimal tax)
        {
            if (valueSearch.TableIsEmpty(tableName))
            {
                nonQuery.NewRow(tableName, 0);
                nonQuery.UpdateRow(tableName, taxSchemeColumn, tax, 0);
            }
            else Console.WriteLine(false);
            nonQuery.UpdateRow(tableName, taxSchemeColumn, tax, 0);
        }
    }
}
