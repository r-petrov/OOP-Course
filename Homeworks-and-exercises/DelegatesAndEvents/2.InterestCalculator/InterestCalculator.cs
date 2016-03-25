namespace _2.InterestCalculator
{
    using System;

    public delegate decimal CalculateInterest(decimal sumOfMoney, decimal interest, int years);

    internal class InterestCalculator
    {
        private readonly CalculateInterest interestCalculator;
        private decimal money;
        private decimal interest;
        private int numberOfYears;
        
        public InterestCalculator(decimal money, decimal interest, int numberOfYears, CalculateInterest interestCalculator)
        {
            this.Money = money;
            this.Interest = interest;
            this.NumberOfYears = numberOfYears;
            this.interestCalculator = interestCalculator;
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The sum of money can not be a negative number!");
                }

                this.money = value;
            }
        }
        
        public decimal Interest
        {
            get
            {
                return this.interest;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value of interest can not be a negative number!");
                }

                this.interest = value;
            }
        }
        
        public int NumberOfYears
        {
            get
            {
                return this.numberOfYears;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of years can not be a negative number!");
                }

                this.numberOfYears = value;
            }
        }

        public decimal TotalMoney
        {
            get
            {
                return this.interestCalculator(this.Money, this.Interest, this.numberOfYears);
            }
        }

        public override string ToString()
        {
            string output = string.Format(
                "Sum of money: {0:F2}\n" +
                "Value of interest: {1:F2}\n" +
                "Number of years: {2}\n" +
                "Total sum of money: {3:F4}\n",
                this.Money, 
                this.Interest, 
                this.NumberOfYears, 
                this.TotalMoney);

            return output;
        }
    }
}
