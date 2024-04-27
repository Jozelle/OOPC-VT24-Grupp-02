using CarService.Entities;
using DataLayer;

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
                    uow.Vehicles.Update(vehicleFromDB, vehicle);
                    return uow.Complete();
                }
            } 
        }
    }
}
