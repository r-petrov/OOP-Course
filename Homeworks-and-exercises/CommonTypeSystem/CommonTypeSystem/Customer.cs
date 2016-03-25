namespace CommonTypeSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Customer : ICloneable, IComparable<Customer>
    {
        private const int IDLength = 10;

        private readonly IList<Payment> payments;
        private string firstName;
        private string middleName;
        private string lastName;
        private long id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;

        public Customer(
            string firstName,
            string middleName,
            string lastName,
            long id,
            string permanentAddress,
            string mobilePhone,
            string email)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.payments = new List<Payment>();
            this.Type = this.SetType();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Customer's first name can not be null, empty or white space!");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Customer's middle name can not be null, empty or white space!");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Customer's last name can not be null, empty or white space!");
                }

                this.lastName = value;
            }
        }

        public long ID
        {
            get
            {
                return this.id;
            }

            set
            {
                string idString = value.ToString();
                if (idString.Length != IDLength)
                {
                    throw new ArgumentException("The count of ID symbols should be 10!");
                }

                this.id = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Customer's permanent address can not be null, empty or white space!");
                }

                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Customer's mobile phone can not be null, empty or white space!");
                }

                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Customer's email can not be null, empty or white space!");
                }

                this.email = value;
            }
        }

        public CustomerTypes Type { get; private set; }

        public IEnumerable<Payment> Payments
        {
            get
            {
                return this.payments;
            }
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            if (object.Equals(customer1, null) || object.Equals(customer2, null))
            {
                return false;
            }

            var areEqual = Customer.Equals(customer1, customer2);
            return areEqual;
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1 == customer2);
        }

        public override bool Equals(object other)
        {
            var otherCustomer = other as Customer;
            if (object.Equals(otherCustomer, null))
            {
                return false;
            }

            var fullName = string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            var otherFullName = string.Format("{0} {1} {2}", otherCustomer.FirstName, otherCustomer.MiddleName, otherCustomer.LastName);
            var areEqual = this.ID.Equals(otherCustomer.ID) && fullName.Equals(otherFullName);

            return areEqual;
        }

        public override int GetHashCode()
        {
            var hashCode = this.LastName.GetHashCode() ^ this.ID.GetHashCode();
            return hashCode;
        }

        public object Clone()
        {
            var clonedCustomer = new Customer(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.ID,
                this.PermanentAddress,
                this.MobilePhone,
                this.Email);
            return clonedCustomer;
        }

        public int CompareTo(Customer other)
        {
            if (object.Equals(other, null))
            {
                throw new ArgumentNullException("The customer is empty!");
            }

            var fullName = string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            var otherFullName = string.Format("{0} {1} {2}", other.FirstName, other.MiddleName, other.LastName);
            if (fullName.Equals(otherFullName))
            {
                return this.ID.CompareTo(other.ID);
            }

            return string.CompareOrdinal(fullName, otherFullName);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(
                "First name: {0}, " +
                "Middle name: {1}, " +
                "Last name: {2}\n" +
                "ID: {3}\n" +
                "Permanent address: {4}\n" +
                "Mobile phone: {5}\n" +
                "Email: {6}\n" +
                "Customer type: {7}\n" +
                "{8} payments\n",
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.ID,
                this.PermanentAddress,
                this.MobilePhone,
                this.Email,
                this.Type,
                this.payments.Count);

            if (this.payments.Count > 0)
            {
                output.AppendLine(string.Join("\n", this.Payments));
            }

            return output.ToString();
        }

        public void AddPayment(Payment payment)
        {
            this.payments.Add(payment);
            this.Type = this.SetType();
        }

        private CustomerTypes SetType()
        {
            if (this.payments.Count <= 1)
            {
                 return CustomerTypes.OneTime;
            }
            else if (this.payments.Count > 1 && this.payments.Count <= 50)
            {
                return CustomerTypes.Regular;
            }
            else if (this.payments.Count > 30 && this.payments.Count <= 100)
            {
                return CustomerTypes.Golden;
            }
            else
            {
                return CustomerTypes.Diamond;
            }
        }
    }
}
