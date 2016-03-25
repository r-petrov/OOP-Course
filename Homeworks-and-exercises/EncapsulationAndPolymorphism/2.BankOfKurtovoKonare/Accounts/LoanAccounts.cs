using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.BankOfKurtovoKonare
{
    public class LoanAccounts : Accounts
    {
        private const int PromoMonthsForIndividuals = 3;
        private const int PromoMonthsForCompanies = 2;
        public LoanAccounts(Customers customer, decimal balance, decimal interestRate, int months) : base(customer, balance, interestRate, months)
        {
        }

        public override Decimal CalculateInterest(decimal rate, int months)
        {
            decimal balanceWithInterest = this.Balance;
            if (this.Customer == Customers.individuals && this.Months > PromoMonthsForIndividuals)
            {
                balanceWithInterest = this.Balance * (1 + rate*(months - PromoMonthsForIndividuals));
            }
            else if (this.Customer == Customers.companies && this.Months > PromoMonthsForCompanies)
            {
                balanceWithInterest = this.Balance * (1 + rate*(months - PromoMonthsForCompanies));
            }
            return balanceWithInterest;
        }
    }
}
