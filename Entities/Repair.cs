using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{
    public class Repair
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public Appointment Appointment { get; set; }
        public ICollection<Item>? Items { get; set; }       
        public ICollection<Employee> RepairedBy { get; set; }
    }
}
