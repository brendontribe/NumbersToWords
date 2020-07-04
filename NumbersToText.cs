using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;

namespace NumbersToWords
{
    class NumbersToText
    {
        public string DollarRepresentation(double value)
        {
            if (value == 0) return "zero dollars";

            //TODO: pass through dollars and cents placeholders e.g. pounds and pence etc.

            int dollars = (int)value;
            int cents = Math.Abs((int)(Math.Round(value - dollars, 2) * 100));

            string dollarsWords = dollars != 0 ? IntToText(dollars) + " dollars" : "";
            string centsWords = cents != 0 ? IntToText(cents) + " cents" : "";
            string conjunction = (dollars != 0 && cents != 0) ? " and " : "";

            return String.Format("{0}{1}{2}", dollarsWords, conjunction, centsWords);
        }


        private static string IntToText(int number)
        {
            if (number == 0) return "zero";

            if (number < 0) return "negative " + IntToText(Math.Abs(number));

            StringBuilder words = new StringBuilder();

            if ((number / 1000) > 0)
            {
                words.Append(IntToText(number / 1000) + " thousand ");
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words.Append(IntToText(number / 100) + " hundred ");
                number %= 100;
            }

            if (number > 0)
            {
                if (words.ToString() != "")
                    words.Append("and ");

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words.Append(unitsMap[number]);
                else
                {
                    words.Append(tensMap[number / 10]);
                    if ((number % 10) > 0)
                        words.Append(" " + unitsMap[number % 10]);
                }
            }

            return words.ToString();
        }

        private static string ToTextHumanizr(int number)
        {
            //this is the real way I would solve the problem, but I felt like it wasnt in the spirit of the challenge.

            //TODO: include a regex to strip the '-' characters from "fifty-seven" formatted responses.
            return number.ToWords();
        }
    }
}
