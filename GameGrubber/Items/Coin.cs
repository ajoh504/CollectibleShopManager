namespace GameGrubber.Items
{
    internal class Coin : Inventory
    {
        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (Year.ToString().Length != 4)
                {
                    Console.WriteLine("Invalid year. Default value set to 0");
                    year = 0;
                }
                else
                {
                    year = value;
                }
            }
        }
    }
}
