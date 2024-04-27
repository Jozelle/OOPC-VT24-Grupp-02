using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal TotalAmount { get; set; }


        public Appointment Appointment { get; set; }
        [ForeignKey("Appointment")]
        public int AppontmentID { get; set; }
    }
}
