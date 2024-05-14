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

        private string registrationNumber;
        

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
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        public string make;
        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string year;
        public string Year
        {
            get { return year; }
            set { year = value; }
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
                
            Vehicle addVehicle = new Vehicle();

            if (RegistrationNumber.Length == 6)
            {
                addVehicle.RegistrationNumber = RegistrationNumber;
            }
            else
            {
                MessageBox.Show("Registration number must be 6 characters long!");
                return;
            }

            if (Make == "")
            {
                MessageBox.Show("Make cannot be empty!");
                return;
            }
            else
            {
                addVehicle.Make = Make;
            }

            if (Model == "")
            {
                MessageBox.Show("Model cannot be empty!");
                return;
            }
            else
            {
                addVehicle.Model = Model;
            }

            if (Year == "")
            {
                MessageBox.Show("Year cannot be empty!");
                return;
            }
            else
            {
                addVehicle.Year = Year;
            }

            int rowsAffected = vehicleController.SaveVehicle(addVehicle);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Vehicle was added!");
            }

            else if (rowsAffected == -1)
            {
                MessageBox.Show("Vehicle already exists!");
            }

        });

    }
}
