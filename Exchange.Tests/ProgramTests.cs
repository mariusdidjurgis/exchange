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
    }
}
