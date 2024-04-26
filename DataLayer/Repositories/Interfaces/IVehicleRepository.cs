using CarService.DataLayer.Repositories.Base;
using CarService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataLayer.Repositories.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        //Unika metoder för fordon.

        Vehicle GetByRegistrationNo(string regNo);
        IEnumerable<Appointment> GetJournal(string regNo);

    }
}
