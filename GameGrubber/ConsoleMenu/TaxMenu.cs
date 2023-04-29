using GameGrubber.Items;

namespace GameGrubber.ConsoleMenu
{
    internal class TaxMenu
    {
        public static void Execute()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@"
____________________________________

Point of sale selection menu
____________________________________

Enter tax  ...................... 
Go back ......................... B
");

                string posMenuChoice = Console.ReadLine();
                if (posMenuChoice.ToUpper() == "B") return;
                else
                {
                    if (Decimal.TryParse(posMenuChoice, out decimal parsed))
                    {
                        while (true)
                        {
                            Console.Write($"Add a {parsed}% tax? Y/N\n");
                            string yesOrNo = Console.ReadLine();
                            if (yesOrNo.ToUpper().Equals("N")) break;
                            else if (yesOrNo.ToUpper().Equals("Y"))
                            {
                                Tax tax = new Tax();
                                tax.UpdateTax(parsed);
                                break;
                            }
                            else continue;
                        }
                    }
                    else Console.WriteLine("Invalid tax. Please try again.");
                }
            }
        }
    }
}
