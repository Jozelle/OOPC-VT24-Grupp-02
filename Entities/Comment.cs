using Microsoft.EntityFrameworkCore;

namespace CarService.Entities
{
    [PrimaryKey(nameof(AuthorEmployeeId), nameof(Time))]
    public class Comment
    {
        public int AuthorEmployeeId { get; set; }
        public Employee Author { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }


    }
}
