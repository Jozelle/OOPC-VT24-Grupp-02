namespace CarService.Entities
{
    public class Customer
    {


        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }


        public ICollection<Appointment>? Appointments { get; set; }


        //Constructor based on customerID, firstname and lastname
        //public Customer(int customerID, string firstname, string lastname, string phonenumber)
        //{
        //    CustomerID = customerID;
        //    FirstName = firstname;
        //    LastName = lastname;
        //    PhoneNumber = phonenumber;

        //}

        public string GetCustomer()
        {
            return $"Customer ID={CustomerID},First name={FirstName}, Last name={LastName}, Phone number ={PhoneNumber},";

        }

        public void UpdateCustomer()

        {

        }

    }
}
