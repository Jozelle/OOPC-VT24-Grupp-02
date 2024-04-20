using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
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
            IEnumerable<Appointment> result = Context.Set<Appointment>()
                .Where(c => c.SubmissionDate.Date == DateTime.Today)
                .Include(c => c.Vehicle)
                .Include(c => c.UsedItems)
                .ThenInclude(c => c.Item)
                .ToList();

            return result;
        }

        public List<Appointment> GetAppointmentsByRegNo(string regNo)
        {
            List<Appointment> currentAppointment = Context.Set<Appointment>()
                .Where(r => r.Vehicle.RegistrationNumber == regNo)
                .Include(c => c.Vehicle)
                .Include(c => c.UsedItems)
                .ThenInclude(c => c.Item)
                .ToList();
            return currentAppointment;
        }

        public void AddItem(Appointment app, Item item, int quantity)
        {
            UsedItem usedItem = new UsedItem() {Appointment = app, Item = item, Quantity=quantity };
            app.UsedItems.Add(usedItem);
        }

        public CarServiceContext CarServiceContext
        {
            get { return CarServiceContext as CarServiceContext; }
        }
    }
}
 