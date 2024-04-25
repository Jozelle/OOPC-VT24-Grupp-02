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


        public Appointment CreateAppointment(Appointment appointment)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {

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



        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Vehicles.Add(vehicle);
                uow.Complete();

            }
            return vehicle;
         
        }

        public void SaveVehicle(Vehicle vehicle)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                 uow.Complete();
            }
        }

        public void CreateCustomer(Customer customer)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Customers.Add(customer);    
                uow.Complete();

            }
        }
    
        public void SaveCustomer (Customer customer)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Complete();
            }

        }
    }
}




 
