using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{
    public class Vehicle
    {
        [Key] public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }



    }

    //Necessery to create a constructor?

    //Need to create a method of choice

}
