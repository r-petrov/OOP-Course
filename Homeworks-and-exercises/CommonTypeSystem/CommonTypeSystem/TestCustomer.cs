namespace CommonTypeSystem
{
    using System;
    using System.Collections.Generic;

    public class TestCustomer
    {
        public static void Main(string[] args)
        {
            var ivan = new Customer("Ivan", "Petrov", "Dimitrov", 8106057465, "Stara Zagora", "0883 335 893", "ivan@abv.bg");
            var ivan2 = new Customer("Ivan", "Todorov", "Dimitrov", 8106057465, "Stara Zagora", "0878 365 983", "ivan_@mail.bg");
            var pesho = new Customer("Petar", "Petrov", "Dimitrov", 8105087885, "Stara Zagora", "0883 335 893", "pesho@abv.bg");
            
            var clone = ivan.Clone();
            var toshka = clone as Customer;
            toshka.FirstName = "Toska";
            toshka.MiddleName = "Yurukova";
            toshka.LastName = "Ivanova";
            toshka.ID = 8108067965;
            toshka.MobilePhone = "0889965616";
            toshka.Email = "t.ivanova@gmail.com";
            toshka.AddPayment(new Payment("Nokia", 678));
            toshka.AddPayment(new Payment("Konika", 1085));

            var customers = new List<Customer>
            {
                toshka, pesho, ivan, ivan2
            };
            customers.Sort();
            Console.WriteLine(string.Join("\n", customers));
            Console.WriteLine(ivan.Equals(ivan2));
        }
    }
}
