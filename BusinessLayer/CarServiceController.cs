using Microsoft.EntityFrameworkCore;
using CarService.Entities;
using DataLayer;
using CarService.DataLayer.Context;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class CarServiceController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public CarServiceController() { }

        public Appointment createAppointment()
        {
            //Byt vy/dialog? 
            //välja tid
            //Sök och välj kund
            //Sök och völj bil

            Appointment appointment = new Appointment()
            {

            };

            return appointment;
        }


        public List<Appointment> getAppointments(string regNo) 
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Appointment> app = uow.Appointments.GetAppointmentsByRegNo(regNo);
                return app;
            }

        }

        public List<Appointment> getCurrentAppointments()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Appointment> app = uow.Appointments.GetTodaysAppointments().ToList();
                return app;
            }

        }

        public Vehicle GetVehicle(string regNo)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Vehicles.GetByRegistrationNo(regNo);
            }
        }
        public Item GetItem(int id) 
        { 
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Items.Get(id);
            }
        }

        public void EnterItem(Appointment app, Item itemId, int quantity)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Appointments.AddItem(app, itemId, quantity);
                uow.Complete();
            }
        }
    }
}
