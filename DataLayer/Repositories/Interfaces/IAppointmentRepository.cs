using CarService.DataLayer.Repositories.Base;
using CarService.Entities;

namespace CarService.DataLayer.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        //Unika metoder för besök

        IEnumerable<Appointment> GetTodaysAppointments();

        List<Appointment> GetAppointmentsByRegNo(string regNo);
<<<<<<< HEAD
        void AddComment(Appointment app, Employee employee, string comment);
        void AddItem(Appointment app, Item item, int quantity);
=======
>>>>>>> Städjobb-repo-+-test-av-singleton-context
    }
}
