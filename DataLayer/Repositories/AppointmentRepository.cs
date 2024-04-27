using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
using CarService.Entities.Enums;
using Microsoft.EntityFrameworkCore;

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
                .Include(c => c.Comments).ThenInclude(c => c.Author)
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

<<<<<<< HEAD
        public void AddItem(Appointment app, Item item, int quantity)
        {
            UsedItem usedItem = new UsedItem() { AppointmentId = app.AppointmentId, ItemId = item.ItemId, Quantity = quantity };
            app.UsedItems.Add(usedItem);
        }

        public void AddComment(Appointment app, Employee employee, string comment)
        {
            Comment newComment = new Comment()
            {
                Appointment = app,
                //MechanicId = mechanic.MechanicId,
                AuthorEmployeeId = employee.EmployeeId,
                Message = comment,
                Time = DateTime.Now,
            };

            app.Comments.Add(newComment);
        }

=======
>>>>>>> Städjobb-repo-+-test-av-singleton-context
        public CarServiceContext CarServiceContext
        {
            get { return CarServiceContext as CarServiceContext; }
        }
    }
}
