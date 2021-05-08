using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exchange.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow(new[] { "" })]
        public void Main_WithWrongParameters_ShouldReturnUsageMessage(string[] args)
        {
            var result = Program.GenerateResult(args);

            Assert.AreEqual("Usage: Exchange <currency pair> <amount to exchange>", result);
        }        
    }
}
