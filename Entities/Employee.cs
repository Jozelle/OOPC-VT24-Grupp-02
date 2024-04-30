using CarService.Entities.Enums;

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
        public Specialization? Specialization { get; set; }
    }

    public class Receptionist : Employee
    {
        public ICollection<Appointment>? CreatedAppointments { get; set; }
    }
}
