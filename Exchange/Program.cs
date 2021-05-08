using System;
using System.Text.RegularExpressions;

namespace Exchange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var result = GenerateResult(args);

            Console.WriteLine(result);
        }

        public static string GenerateResult(string[] args)
        {
            var result = "Usage: Exchange <currency pair> <amount to exchange>";
            var currencyRegex = "([a-zA-Z]{3})/([a-zA-Z]{3})";

            if (args != null && args.Length == 2)
            {
                var currencies = args[0].Trim();
                var amountString = args[1].Trim();
                if (!decimal.TryParse(amountString, out decimal amount))
                {
                    result = "Incorrect amount provided";
                }
                else
                {
                    var match = Regex.Matches(currencies, currencyRegex);

                    var mainCurrencyString = match[0].Groups[1].Value;
                    var mainCurrency = mainCurrencyString.StringToCurrency();

                    if (!mainCurrency.HasValue)
                    {
                        result = "Unknown currency provided: " + mainCurrencyString;
                    }

                    var moneyCurrencyString = match[0].Groups[2].Value;
                    var moneyCurrency = moneyCurrencyString.StringToCurrency();

                    if (!moneyCurrency.HasValue)
                    {
                        result = "Unknown currency provided: " + moneyCurrencyString;
                    }
                }
            }

            return result;
        }
        
    }
}
