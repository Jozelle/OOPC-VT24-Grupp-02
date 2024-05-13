using CarService.BusinessLayer;
using CarService.Entities;
using CarService.PresentationLayer.WPF.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class CreateVehicleViewModel : ViewModelBase
    {
        //Controllers
        private CustomerController customerController = null!;
        private VehicleController vehicleController = null!;

        private string registrationNumber = "Registration number";


        //Properties

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string socialSecurityNumber;
        public string SocialSecurityNumber
        {
            get { return socialSecurityNumber; }
            set { socialSecurityNumber = value; }
        }

       private string streetName;   
        public string StreetName
        {
            get { return streetName; }
            set { streetName = value; }
        }

        private string postalCode;
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        private string city;    
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }



        private Customer customer = null!;
        public Customer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }

        private Vehicle vehicle = null!;
        public Vehicle Vehicle
        {
            get { return vehicle; }
            set
            {
                vehicle = value;
                OnPropertyChanged();
            }
        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        public CreateVehicleViewModel()
        {
            customerController = new CustomerController();
            vehicleController = new VehicleController();

           
        }


        //Commands

        private ICommand addCustomerCommand = null!;
        public ICommand AddCustomerCommand => addCustomerCommand ??= addCustomerCommand = new RelayCommand(() =>
        {

            Customer addCustomer = new Customer(FirstName, LastName, PhoneNumber, SocialSecurityNumber, StreetName, PostalCode, City, Email);
            if (addCustomer.Email == "")
            {
                addCustomer.Email = null;
            }

            if (addCustomer.Address == "")
            {
                addCustomer.Address = null;
            }

            if (addCustomer.PostalCode == "")
            {
                addCustomer.PostalCode = null;
            }

            if (addCustomer.City == "")
            {
                addCustomer.City = null;
            }
            
            int rowsAffected = customerController.SaveCustomer(addCustomer);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Customer was added!");
            }

            else if (rowsAffected == -1)
            {
                MessageBox.Show("Customer already exists!");
            }

            else
            {
                MessageBox.Show("Could not add customer!");
            }   
                
        });

        private ICommand addVehicleCommand = null!;
        public ICommand AddVehicleCommand => addVehicleCommand ??= addVehicleCommand = new RelayCommand(() =>
        {

        });

    }
}
