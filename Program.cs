using System;

namespace NumbersToWords
{
    class Program
    {
        static void k(string[] args)
        {
            NumbersToText _numbersToText = new NumbersToText();
            double n = 12345.78;
            string s = _numbersToText.DollarRepresentation(n);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
