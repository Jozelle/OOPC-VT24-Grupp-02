using Microsoft.EntityFrameworkCore;

namespace CarService.Entities
{
    [PrimaryKey(nameof(AppointmentId), nameof(ItemId))]
    public class UsedItem
    {
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }

    }
}
