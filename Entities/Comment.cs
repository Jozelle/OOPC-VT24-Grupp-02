using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{
    [PrimaryKey(nameof(AuthorEmployeeId), nameof(Time))]
    public class Comment
    {
        public int AuthorEmployeeId { get; set; }
        public Employee Author { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public Appointment Appointment { get; set; }


    }
}
