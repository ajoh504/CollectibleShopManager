using GameGrubber.Database;

namespace GameGrubber.Items
{
    internal class Tax
    {
        private string tableName;
        private const string taxSchemeColumn = "tax_scheme";
        private DatabaseNonQuery nonQuery;
        private DatabaseValueSearch valueSearch;

        public Tax()
        {
            tableName = "tax";
            nonQuery = new DatabaseNonQuery();
            valueSearch = new DatabaseValueSearch();
        }

        public void UpdateTax(decimal tax)
        {
            if (valueSearch.TableIsEmpty(tableName))
            {
                Console.WriteLine(true);
            }
            else Console.WriteLine(false);

            nonQuery.UpdateRow(tableName, taxSchemeColumn, tax, 0);
        }
    }
}
