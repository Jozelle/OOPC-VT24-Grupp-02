using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Verkstad.Entities
{
    internal class Customer
    {
       

        public int CustomerID {  get; set; }
        public string Firstname {  get; set; }
        public  string Lastname { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }

        //Constructor based on customerID, firstname and lastname
        public Customer(int customerID, string firstname, string lastname)
        {
            CustomerID = customerID;
            Firstname = firstname;
            Lastname = lastname;
        }


    }
}
