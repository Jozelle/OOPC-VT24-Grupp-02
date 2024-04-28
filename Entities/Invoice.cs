using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public decimal TotalAmount { get; set; }

        public int AppontmentId { get; set; }
        public Appointment Appointment { get; set; }
        
    }
}
