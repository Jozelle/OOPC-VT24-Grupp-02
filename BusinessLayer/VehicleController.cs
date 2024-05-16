using CarService.Entities;
using DataLayer;
using System.Collections.Generic;

namespace CarService.BusinessLayer
{
    public class VehicleController
    {
        public VehicleController() { }
        public Vehicle GetVehicle(string regNo)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Vehicles.GetByRegistrationNo(regNo);
            }
        }
        public List<Appointment> GetJournal(string regNo)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Vehicles.GetJournal(regNo);
            }
        }

        public int SaveVehicle(Vehicle vehicle)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Vehicle vehicleFromDB = uow.Vehicles.GetByRegistrationNo(vehicle.RegistrationNumber);
                if (vehicleFromDB == null)
                {
                    uow.Vehicles.Add(vehicle);
                    return uow.Complete();
                }
                else
                {
                    return -1;
                }
            }
        }
        public int UpdateVehicle(Vehicle vehicle)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Vehicle vehicleFromDB = uow.Vehicles.GetByRegistrationNo(vehicle.RegistrationNumber);
                if (vehicleFromDB != null)
                {
                    uow.Vehicles.Update(vehicleFromDB, vehicle);
                    return uow.Complete();
                }
                else
                {
                    return -1;
                }
            }
        }
        public List<Vehicle> GetVehiclesByCustomer(Customer customer)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<string> regNumbers = uow.Customers.GetVehicleByCustomer(customer);

                return uow.Vehicles.GetRange(regNumbers);
            }
        }
     }
}
