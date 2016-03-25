using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2.BankOfKurtovoKonare.Interfaces;

namespace _2.BankOfKurtovoKonare
{
    public abstract class Accounts : IDepositMoney, ICalculateInterest
    {
        private Customers customer;
        private int months;
        private decimal interestRate;
        private decimal interest;

        public Accounts(Customers customer, decimal balance, decimal interestRate, int months)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.Months = months;
        }

        public Customers Customer
        {
            get { return this.customer; }
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("value", "Customer cannot be null , empty or whitespace!");
                }
                this.customer = value;
            }
        }

        public decimal Balance { get; set; }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Interest rate cannot be a negative number!");
                }
                this.interestRate = value;
            }
        }

        public int Months
        {
            get { return this.months; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Months cannot be a negative number!");
                }
                this.months = value;
            }
        }

        public void DepositMoney(decimal sum)
        {
            this.Balance += sum;
        }

        public override string ToString()
        {
            //StringBuilder result = new StringBuilder();
            //result.AppendLine("Type of customer: " + this.Customer);
            //result.AppendLine("Balance of account: " + this.Balance);
            //result.AppendLine("Interest rate: " + this.InterestRate);
            //result.AppendLine("Number of months: " + this.Months);
            //result.AppendLine("Balance with accumulated interest: " + this.CalculateInterest(this.InterestRate, this.Months));

            string resultStr = String.Format("Type of customer: {0}\nBalance of account: {1}\nInterest rate: {2:C2}\nNumber of months:{3}\nBalance with accumulated interest: {4:C2}\n",
                this.Customer, this.Balance, this.InterestRate, this.Months, this.CalculateInterest(this.InterestRate, this.Months)); 
            return resultStr;
        }

        public virtual decimal CalculateInterest(decimal rate, int months)
        {
            decimal balanceWithInterest = 0m;
            balanceWithInterest = this.Balance * (1 + rate * months);
            return balanceWithInterest;
        }
    }
}
