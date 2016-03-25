namespace _2.InterestCalculator
{
    using System;

    internal class Program
    {
        public static void Main(string[] args)
        {
            // CalculateInterest compound = GetCompoundInterest;
            // CalculateInterest simple = GetSimpleInterest;
            InterestCalculator compoundCalculator = new InterestCalculator(500m, 5.6m, 10, GetCompoundInterest);
            InterestCalculator simpleCalculator = new InterestCalculator(2500m, 7.2m, 15, GetSimpleInterest);

            Console.WriteLine(compoundCalculator);
            Console.WriteLine(simpleCalculator);
        }

        public static decimal GetSimpleInterest(decimal sumOfMoney, decimal interest, int years)
        {
            decimal interestAmount = sumOfMoney * (1 + ((interest / 100) * years));
            decimal roundedInterestAmount = Math.Round(interestAmount, 4);

            return roundedInterestAmount;
        }

        public static decimal GetCompoundInterest(decimal sumOfMoney, decimal interest, int years)
        {
            const int NumberOfInterestCompoundsPerYear = 12;

            int numberOfInterestCompounds = years * NumberOfInterestCompoundsPerYear;
            decimal interestPerCompound = 1 + ((interest / 100) / NumberOfInterestCompoundsPerYear);
            decimal compoundInterest = DecimalPower(interestPerCompound, numberOfInterestCompounds);
            decimal compoundInterestAmount = sumOfMoney * compoundInterest;

            decimal roundedCompoundInterestAmount = Math.Round(compoundInterestAmount, 4);

            return roundedCompoundInterestAmount;
        }

        private static decimal DecimalPower(decimal decimalNumber, decimal decimalPower)
        {
            double doubleNumber = (double)decimalNumber;
            double doublePower = (double)decimalPower;

            return (decimal)Math.Pow(doubleNumber, doublePower);
        }
    }
}
