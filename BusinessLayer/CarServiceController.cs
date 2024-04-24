using CarService.Entities;
using CarService.Entities.Enums;
using DataLayer;

namespace BusinessLayer
{
    public class CarServiceController
    {

        
        public CarServiceController() { }


        public Customer GetCustomerBySSN(string id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Customers.GetBySocialSecurityNo(id);
            }
        }

        public Customer GetCustomerByPhone(string number)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Customers.GetByPhoneNo(number);
            }
        }

        public Customer GetCustomerByFullName(string fName, string lName)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Customers.GetByFullName(fName, lName);
            }
        }

        public Vehicle GetVehicle(string id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Vehicles.GetByRegistrationNo(id);
            }
            
        }

        public Appointment createAppointment(DateTime time, Customer customer, Vehicle vehicle, string purpose, Receptionist receptionist)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Appointment appointment = new Appointment()
                {
                    SubmissionDate = time,
                    DeliveryDate = time + TimeSpan.FromHours(2),
                    Purpose = purpose,
                    VehicleRegistrationNumber = vehicle.RegistrationNumber,
                    CustomerId = customer.CustomerID,
                    CreatedById = receptionist.ReceptionistId,
                    Status = AppointmentStatus.Booked

                };

                uow.Appointments.Add(appointment);
                uow.Complete();
                return appointment;
            }
        }
        public Receptionist GetReceptionist(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Receptionists.Get(id);

            }
        }
    }
}
