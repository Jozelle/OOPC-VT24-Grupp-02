using CarService.DataLayer.Repositories.Base;
using CarService.Entities;

namespace CarService.DataLayer.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        //Unika metoder för besök

        IEnumerable<Appointment> GetTodaysAppointments();

        List<Appointment> GetAppointmentsByRegNo(string regNo);

        void AddComment(Appointment app, Employee employee, string comment);
        void AddItem(Appointment app, Item item, int quantity);

        List<Appointment> GetAppointmentsByFullName(string firstName, string lastName);
        List<Appointment> GetAppointmentsByPhoneNo(string phoneNo);
        List<Appointment> GetAppointmentsBySSNo(string ssNo);



    }
}
