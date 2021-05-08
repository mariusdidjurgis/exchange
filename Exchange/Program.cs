using System;

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

            return result;
        }
    }
}
