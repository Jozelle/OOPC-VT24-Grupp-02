using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
using CarService.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataLayer.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(CarServiceContext context) : base(context) 
        { 
        }

        public IEnumerable<Appointment> GetTodaysAppointments()
        {
            IEnumerable<Appointment> result = Table
                .Where(c => c.SubmissionDate.Date <= DateTime.Today && c.Status != AppointmentStatus.Canceled && c.Status != AppointmentStatus.Completed)
                .Include(c => c.Vehicle)
                .Include(c => c.UsedItems)
                .ThenInclude(c => c.Item)
                .Include(c => c.Comments)
                .ToList();

            return result;
        }

        public List<Appointment> GetAppointmentsByRegNo(string regNo)
        {
            List<Appointment> currentAppointment = Table
                .Where(r => r.Vehicle.RegistrationNumber == regNo)
                .Include(c => c.Vehicle)
                .Include(c => c.UsedItems)
                .ThenInclude(c => c.Item)
                .Include(c => c.Comments)
                .ToList();
            return currentAppointment;
        }

        public CarServiceContext CarServiceContext
        {
            get { return CarServiceContext as CarServiceContext; }
        }
    }
}
 