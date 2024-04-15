using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{
    [PrimaryKey(nameof(MechanicId), nameof(Time))]
    public class MechanicComment
    {
        public int MechanicId { get; set; }
        public Mechanic RepairedBy { get; set; }
        public DateTime Time { get; set; }
        public string Comment { get; set; }
        public Appointment Appointment { get; set; }
    }
}
