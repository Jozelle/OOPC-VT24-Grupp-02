using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
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
                .ToList();
            return result;
        }

        public Appointment GetByRegNo(string regNo)
        {
            Appointment currentAppointment = Context.Set<Appointment>()
                .Single(r => r.Vehicle.RegistrationNumber == regNo);
            return currentAppointment;
        }

        public void AddItem(Appointment app, Item item, int quantity)
        {
            UsedItem usedItem = new UsedItem() {Item = item, Quantity=quantity };
            app.UsedItems.Add(usedItem);
        }

        public CarServiceContext CarServiceContext 
        { 
            get { return CarServiceContext as CarServiceContext; }
        }
    }
}
 