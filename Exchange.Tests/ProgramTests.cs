using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exchange.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow(new[] { "" })]
        public void GenerateResult_WithWrongParameters_ShouldReturnUsageMessage(string[] args)
        {
            var result = Program.GenerateResult(args);

            Assert.AreEqual("Usage: Exchange <currency pair> <amount to exchange>", result);
        }

        [TestMethod]
        public void GenerateResult_WithIncorrectAmount_ShouldReturnInformationMessage()
        {
            var result = Program.GenerateResult(new[] { "eur/dkk", "not_amount" });

            Assert.AreEqual("Incorrect amount provided", result);
        }

        [TestMethod]
        public void GenerateResult_WithFirstCurrencyUnknown_ShouldReturnInformationMessage()
        {
            var result = Program.GenerateResult(new[] { "aaa/dkk", "1" });

            Assert.AreEqual("Unknown currency provided: aaa/dkk", result);
        }

        [TestMethod]
        public void GenerateResult_WithSecondCurrencyUnknown_ShouldReturnInformationMessage()
        {
            var result = Program.GenerateResult(new[] { "eur/aaa", "1" });

            Assert.AreEqual("Unknown currency provided: eur/aaa", result);
        }

        [TestMethod]
        [DataRow(Currency.EUR, Currency.DKK, "7,4394")]
        [DataRow(Currency.USD, Currency.DKK, "6,6311")]
        [DataRow(Currency.EUR, Currency.USD, "1,1219")]
        [DataRow(Currency.EUR, Currency.GBP, "0,8723")]
        [DataRow(Currency.EUR, Currency.SEK, "9,7758")]
        [DataRow(Currency.EUR, Currency.NOK, "9,4890")]
        [DataRow(Currency.EUR, Currency.CHF, "1,0883")]
        [DataRow(Currency.EUR, Currency.JPY, "124,5296")]
        public void GenerateResult_WithCorrectCurrencyPair_ShouldCalculateAmount(Currency mainCurrency, Currency moneyCurrency, string expectedAmount)
        {
            var result = Program.GenerateResult(new[] { mainCurrency.ToString() + "/" + moneyCurrency.ToString(), "1" });

            Assert.AreEqual(expectedAmount, result);
        }
    }
}
