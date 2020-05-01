using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCottage
{
    public class Customer
    {
        private int customerID;
        private string postal;
        private string forename;
        private string surname;
        private string address;
        private string email;
        private string phone;

        public Customer()
        {
        }

        public Customer(int customerID, string postal, string forename, string surname, string address, string email, string phone)
        {
            this.customerID = customerID;
            this.postal = postal;
            this.forename = forename;
            this.surname = surname;
            this.address = address;
            this.email = email;
            this.phone = phone;
        }

        public int CustomerID { get => customerID; set => customerID = value; }
        public string Postal { get => postal; set => postal = value; }
        public string Forename { get => forename; set => forename = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
