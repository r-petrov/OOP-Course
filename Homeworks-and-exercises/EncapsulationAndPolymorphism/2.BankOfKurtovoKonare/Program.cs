using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankOfKurtovoKonare
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Accounts[] accounts =
                {
                    new DepositAccounts(Customers.individuals, 680m, 0.25m/12, 10),
                    new DepositAccounts(Customers.individuals, 1250m, 0.25m/12, 10),
                    new DepositAccounts(Customers.companies, 980m, 0.25m/12, 10),
                    new DepositAccounts(Customers.individuals, 5000m, 0.25m/11, 10),
                    new LoanAccounts(Customers.individuals, 5000m, 0.11m/12, 13),
                    new LoanAccounts(Customers.companies, 25000m, 0.13m/12, 23),
                    new Mortgage(Customers.individuals, 10000m, 0.10m/12, 5),
                    new Mortgage(Customers.individuals, 10000m, 0.10m/12, 15),
                    new Mortgage(Customers.companies, 10000m, 0.15m/12, 12),
                    new Mortgage(Customers.companies, 10000m, 0.15m/12, 15),
                };

                foreach (var account in accounts)
                {
                    Console.WriteLine(account);
                }
            }
            catch (ArgumentNullException ae)
            {
                Console.Error.WriteLine(ae.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
