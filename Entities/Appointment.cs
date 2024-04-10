using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verkstad.Entities
{
    internal class Appointment
    {

        public string AppointmentNr { get; set; }

        public DateTime SubmissionDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Purpose { get; set; }

    }


}
