using CarService.DataLayer.Repositories.Base;
using CarService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataLayer.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        //Unika metoder för besök
        
        IEnumerable<Appointment> GetTodaysAppointments();

        List<Appointment> GetAppointmentsByRegNo(string regNo);
    }
}
