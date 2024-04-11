using CarService.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialisation { get; set; }
        public string Password { get; set; }

        public ICollection<Repair>? HandledRepairs { get; set; }
        public Role Role { get; set; }
        public ICollection<Appointment>? CreatedAppointments { get; set; }
    }
}
