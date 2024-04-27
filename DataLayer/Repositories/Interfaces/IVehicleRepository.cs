using CarService.DataLayer.Repositories.Base;
using CarService.Entities;

namespace CarService.DataLayer.Repositories.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        //Unika metoder för fordon.

        Vehicle GetByRegistrationNo(string regNo);
        List<Appointment> GetJournal(string regNo);

    }
}
