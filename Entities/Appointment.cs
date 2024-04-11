using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{
    public class Appointment
    {

        public int AppointmentId { get; set; }

        public DateTime SubmissionDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Purpose { get; set; }

        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        public Employee CreatedBy { get; set; }


        public ICollection<Repair> Repairs { get; set; }

    }


}
