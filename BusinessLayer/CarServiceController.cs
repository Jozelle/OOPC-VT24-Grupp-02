using Microsoft.EntityFrameworkCore;
using CarService.Entities;
using DataLayer;
using CarService.DataLayer.Context;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class CarServiceController
    {
        public CarServiceController() { }

        CarServiceContext csc = new CarServiceContext();

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

        public Appointment handleAppointment(string regNo) 
        {
            using (UnitOfWork uow = new UnitOfWork(csc))
            {
                Appointment app = uow.Appointments.GetByRegNo(regNo);
                return app;
            }

        }

        public void enterItem(Appointment app, int itemId, int quantity)
        {
            using (UnitOfWork uow = new UnitOfWork(csc))
            {
                Item pryl = uow.Items.Get(itemId);
                uow.Appointments.AddItem(app, pryl, quantity);
            }

            
        }
    }
}
