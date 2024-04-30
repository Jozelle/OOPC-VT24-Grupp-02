using CarService.Entities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CarService.Entities
{
    public class Appointment : INotifyPropertyChanged
    {
        //public Appointment(DateTime submissionDate, DateTime deliveryDate, string purpose, string vehicleRegistrationNumber, int customerId, int createdById)
        //{
        //    SubmissionDate = submissionDate;
        //    DeliveryDate = deliveryDate;
        //    Purpose = purpose;
        //    VehicleRegistrationNumber = vehicleRegistrationNumber;
        //    CustomerId = customerId;
        //    CreatedById = createdById;
        //    Status = AppointmentStatus.Booked;
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        public int AppointmentId { get; set; }

        public DateTime SubmissionDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Purpose { get; set; }

        public string VehicleRegistrationNumber { get; set; }
        public Vehicle Vehicle { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CreatedById { get; set; }
        public Receptionist CreatedBy { get; set; }
        public AppointmentStatus Status { get; set; }
        public Invoice? Invoice { get; set; }
        public ICollection<UsedItem>? UsedItems { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;

            foreach (UsedItem usedItem in UsedItems)
            {
                totalCost += usedItem.Item.Price * usedItem.Quantity;
            }

            return totalCost;
        }
        public override string ToString()
        {
            return AppointmentId.ToString();
        }

    }


}
