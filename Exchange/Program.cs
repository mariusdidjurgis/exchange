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

            if (args != null && args.Length == 2)
            {
                var currencies = args[0].Trim();
                var amountString = args[1].Trim();
                if (!decimal.TryParse(amountString, out decimal mainCurrencyAmountToBuy))
                {
                    result = "Incorrect amount provided";
                }
                else
                {
                    var match = Regex.Matches(currencies, "([a-zA-Z]{3})/([a-zA-Z]{3})");
                    var mainCurrency= (match[0].Groups[1].Value).StringToCurrency();
                    var moneyCurrency = (match[0].Groups[2].Value).StringToCurrency();

                    if (!mainCurrency.HasValue || !moneyCurrency.HasValue)
                    {
                        result = "Unknown currency provided: " + currencies;
                    }
                    else
                    {
                        var moneyCurrencyRequired = new CurencyExchangeCalculator(mainCurrency.Value, moneyCurrency.Value).CalculateExchangeAmount(mainCurrencyAmountToBuy);
                        result = moneyCurrencyRequired.ToString("0.0000");
                    }
                }
            }

            return result;
        }
    }
}
