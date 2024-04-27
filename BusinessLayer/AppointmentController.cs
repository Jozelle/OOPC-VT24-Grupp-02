using CarService.Entities;
using DataLayer;

namespace CarService.BusinessLayer
{
    public class AppointmentController
    {
        public AppointmentController() { }

        public List<Appointment> GetAppointments(string regNo)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Appointment> app = uow.Appointments.GetAppointmentsByRegNo(regNo);
                return app;
            }
        }

        public List<Appointment> GetTodaysAppointments()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Appointment> app = uow.Appointments.GetTodaysAppointments().ToList();
                return app;
            }
        }
        public int EnterItem(Appointment app, Item item, int quantity)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                UsedItem usedItem = new UsedItem() { AppointmentId = app.AppointmentId, ItemId = item.ItemId, Quantity = quantity };

                uow.UsedItems.Add(usedItem);
                return uow.Complete();
            }
        }
        public int AddCommentToAppointment(Appointment app, string comment, Employee employee)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Comment mc = new Comment() { AppointmentId = app.AppointmentId, Message = comment, AuthorEmployeeId = employee.EmployeeId, Time = DateTime.Now };

                uow.Comments.Add(mc);
                return uow.Complete();
            }
        }
        public int CreateAppointment(Appointment appointment)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Appointments.Add(appointment);
                int rowsAffected = uow.Complete();
                return rowsAffected;
            }
        }
    }
}
