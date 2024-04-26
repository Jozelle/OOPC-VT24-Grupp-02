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

        public bool VerifyUser(int id, string password)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Employees.VerifyEmployee(id, password);
            }
        }
        public bool IsReceptionist(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Employees.IsReceptionist(id);

            }
        }
        public Employee GetEmployee(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Employees.Get(id);

            }
        }

        public List<Appointment> GetAppointments(string regNo) 
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Appointment> app = uow.Appointments.GetAppointmentsByRegNo(regNo);
                return app;
            }

        }

        public List<Appointment> GetCurrentAppointments()
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

        public void AddCommentToAppointment(Appointment app, string comment, Employee employee)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Appointments.AddComment(app, employee, comment);
                uow.Complete();
            }
        }

        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Vehicles.Add(vehicle);
                uow.Complete();

            }
            return vehicle;

        }

        public void SaveVehicle(Vehicle vehicle)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Complete();
            }
        }

        public void CreateCustomer(Customer customer)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Customers.Add(customer);
                uow.Complete();

            }
        }

        public void SaveCustomer(Customer customer)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Complete();
            }

        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {

                uow.Appointments.Add(appointment);
                uow.Complete();
                return appointment;
            }
        }

        public Customer GetCustomerBySSN(string id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Customers.GetBySocialSecurityNo(id);
            }
        }

        public Customer GetCustomerByPhone(string number)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Customers.GetByPhoneNo(number);
            }
        }

        public Customer GetCustomerByFullName(string fName, string lName)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Customers.GetByFullName(fName, lName);
            }
        }
        public List<Appointment> ShowJournal(string regNo)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                return uow.Vehicles.GetJournal(regNo).ToList();
            }
        }
    }
}
