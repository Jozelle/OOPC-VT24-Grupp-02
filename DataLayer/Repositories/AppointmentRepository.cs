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
                .Where(c => c.SubmissionDate == DateTime.Today)
                .ToList();
            return result;

        }

        public CarServiceContext CarServiceContext 
        { 
            get { return CarServiceContext as CarServiceContext; }
        }
    }
}
