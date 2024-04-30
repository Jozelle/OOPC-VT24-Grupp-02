using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public decimal TotalAmount { get; set; }
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }
        public Receptionist CreatedBy { get; set; }
        public int CreatedById { get; set; }
    }
}
