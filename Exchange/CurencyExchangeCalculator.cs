using System.Collections.Generic;

namespace Exchange
{
    public class CurencyExchangeCalculator
    {
        public List<KeyValuePair<Currency, decimal>> currencyRates = new List<KeyValuePair<Currency, decimal>>()
                        {
                            new KeyValuePair<Currency, decimal>(Currency.DKK, 1m),
                            new KeyValuePair<Currency, decimal>(Currency.EUR, 7.4394m),
                            new KeyValuePair<Currency, decimal>(Currency.USD, 6.6311m),
                            new KeyValuePair<Currency, decimal>(Currency.GBP, 8.5285m),
                            new KeyValuePair<Currency, decimal>(Currency.SEK, 0.761m),
                            new KeyValuePair<Currency, decimal>(Currency.NOK, 0.784m),
                            new KeyValuePair<Currency, decimal>(Currency.CHF, 6.8358m),
                            new KeyValuePair<Currency, decimal>(Currency.JPY, 0.05974m),
                        };

        private Currency _mainCurrency;
        private Currency _moneyCurrency;

        public CurencyExchangeCalculator(Currency mainCurrency, Currency moneyCurrency)
        {
            _mainCurrency = mainCurrency;
            _moneyCurrency = moneyCurrency;
        }

        public decimal CalculateExchangeAmount(decimal mainCurrencyAmountToBuy)
        {
            var mainCurrencyRate = currencyRates.Find(rate => rate.Key == _mainCurrency);
            var dkkAmountToBuyMainCurrency = mainCurrencyRate.Value * mainCurrencyAmountToBuy;

            var moneyCurrencyRate = currencyRates.Find(rate => rate.Key == _moneyCurrency);

            var moneyCurrencyAmountToBuy = dkkAmountToBuyMainCurrency / moneyCurrencyRate.Value;

            return moneyCurrencyAmountToBuy;
        }
    }
}
