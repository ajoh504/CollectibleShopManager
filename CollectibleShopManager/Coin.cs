namespace CollectibleShopManager
{
    internal class Coin : Inventory
    {
        private int? year;
        public int? Year
        {
            get
            {
                return year;
            }
            set
            {
                if (Year.ToString().Length != 4)
                {
                    Console.WriteLine("Invalid year. Default value set to null");
                    year = null;
                }
                else
                {
                    year = value;
                }
            }
        }
    }
}
