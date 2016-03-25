using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.BankOfKurtovoKonare
{
    public class Mortgage : Accounts
    {
        private const int PromoMonthsForIndividuals = 6;
        private const int PromoMonthsForCompanies = 12;
        public Mortgage(Customers customer, decimal balance, decimal interestRate, int months) : base(customer, balance, interestRate, months)
        {
        }

        public override Decimal CalculateInterest(decimal rate, int months)
        {
            decimal balanceWithInterest = this.Balance;
            if (this.Customer == Customers.individuals)
            {
                if (this.Months >= PromoMonthsForIndividuals)
                {
                    balanceWithInterest = base.CalculateInterest(rate, months - PromoMonthsForIndividuals);
                }
            }
            else
            {
                if (months <= PromoMonthsForCompanies)
                {
                    balanceWithInterest = this.Balance * (1 + rate * months / 2);
                }
                else
                {
                    balanceWithInterest = base.CalculateInterest(rate, months - PromoMonthsForCompanies);
                }
            }
            return balanceWithInterest;
        }
    }
}
