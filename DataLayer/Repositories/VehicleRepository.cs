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
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CarServiceContext context) : base(context)
        {
        }

        public Vehicle? GetByRegistrationNo(string reg)
        {
            return Context.Set<Vehicle>().Find(reg);
            //return CarServiceContext.Vehicles.Find(reg);
        }

        //public IEnumerable<Repair> GetJournal(Vehicle vehicle)
        //{
        //    var query = from besök in Context.Set<Appointment>()
        //                join reparation in Context.Set<Repair>()
        //                on besök equals reparation.Appointment
        //                where (besök.Vehicle == vehicle)
        //                select reparation;
        //    return query;

        //    //IEnumerable<Repair> repairs = CarServiceContext.Repairs
        //    //    .Join(
        //    //    CarServiceContext.Appointments,
        //    //    r => r.Appointment.AppointmentId,
        //    //    b => b.AppointmentId,
        //    //    (r, b) => new
        //    //    {
        //    //        RepairId = r.RepairId,
        //    //        Description = r.Description,
        //    //        Appointment = r.Appointment,
        //    //        RepairItems = r.RepairItems,
        //    //        RepairedBy = r.RepairedBy,
        //    //        Vehicle = b.Vehicle
        //    //    })
        //    //    .Where(x => x.Vehicle == vehicle)
        //    //    .Select(x => new Repair()
        //    //    {
        //    //        RepairId = x.RepairId,
        //    //        Description = x.Description,
        //    //        Appointment = x.Appointment,
        //    //        RepairItems = x.RepairItems,
        //    //        RepairedBy = x.RepairedBy,
        //    //    });


        //    //return repairs;

        //}



        public CarServiceContext CarServiceContext
        {
            get { return CarServiceContext as CarServiceContext; }
        }
    }
}
