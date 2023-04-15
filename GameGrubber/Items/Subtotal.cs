namespace GameGrubber.Items
{
    internal class Subtotal
    {
        private List<string> itemsToSell;
        private int tally;

        public int Tally
        { 
            get { return tally; } 
            private set { tally = GetCurrentSubtotal(); }
        }

        public Subtotal() 
        {
            itemsToSell = new List<string>();
        }

        public void AddItem(string item)
        {
            itemsToSell.Add(item);
            tally = GetCurrentSubtotal();
        }

        private int GetCurrentSubtotal()
        {
            return 0;
        }
    }
}
