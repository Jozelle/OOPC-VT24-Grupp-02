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
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialization? Specialization { get; set; }
        public string Password { get; set; }

       
    }

    public class Mechanic : Employee
    {
        public int MechanicId { get; set; }
        public ICollection<Repair>? HandledRepairs { get; set; }
    }

    public class Receptionist : Employee
    {
        public int ReceptionistId { get; set; }
        public ICollection<Appointment>? CreatedAppointments { get; set; }
    }
}
