using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _2.BankOfKurtovoKonare.Interfaces;

namespace _2.BankOfKurtovoKonare
{
    public class DepositAccounts : Accounts, IWithdrawMoney
    {
        private const decimal MinimalBalance = 1000m;
        public DepositAccounts(Customers customer, decimal balance, decimal interestRate, int months)
            : base(customer, balance, interestRate, months)
        {
        }
        public override Decimal CalculateInterest(decimal rate, int months)
        {
            decimal balanceWithInterest = this.Balance;
            if (this.Balance >= MinimalBalance)
            {
                balanceWithInterest =  base.CalculateInterest(rate, months);
            }
            return balanceWithInterest;
        }

        public void WithdrawMoney(decimal sum)
        {
            this.Balance -= sum;
        }
    }
}
