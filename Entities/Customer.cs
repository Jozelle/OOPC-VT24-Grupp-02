using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{
    internal class Customer
    {
       

        public int CustomerID {  get; set; }
        public string FirstName {  get; set; }
        public  string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //Constructor based on customerID, firstname and lastname
        public Customer(int customerID, string firstname, string lastname, string phonenumber)
        {
            CustomerID = customerID;
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = phonenumber;

        }

        public void DisplayInfo() 
        { 
        }

    }
}
