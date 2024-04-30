namespace CarService.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        //Konstruktor
        public Customer(string firstName, string lastName, string phoneNumber, string socialSecurityNumber, string? address, string? postalCode, string? city, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            Address = address;
            PostalCode = postalCode;
            City = city;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
