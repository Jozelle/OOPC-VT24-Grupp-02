namespace CarService.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }

    public class Mechanic : Employee
    {
<<<<<<< HEAD

=======
        public Specialization? Specialization { get; set; }
>>>>>>> Städjobb-repo-+-test-av-singleton-context
    }

    public class Receptionist : Employee
    {
        public ICollection<Appointment>? CreatedAppointments { get; set; }
    }
}
