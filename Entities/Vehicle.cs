using System.ComponentModel.DataAnnotations;

namespace CarService.Entities
{
    public class Vehicle
    {
        [Key][MaxLength(6)]
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public override string ToString()
        {
            return RegistrationNumber;
        }

    }


}
