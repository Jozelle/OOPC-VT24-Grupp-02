using CarService.BusinessLayer;
using CarService.Entities;
using CarService.PresentationLayer.WPF.MVVM.Commands;
using CarService.PresentationLayer.WPF.MVVM.Stores;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class CreateAppViewModel : ViewModelBase
    {
        private VehicleController vehicleController = null!;
        private CustomerController customerController = null!;
        private AppointmentController appointmentController = null!;

        private string registrationNumber = "Registration number";
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        private Vehicle currentVehicle = null!;
        public Vehicle CurrentVehicle
        {
            get { return currentVehicle; }
            set
            {
                currentVehicle = value;
                OnPropertyChanged();
            }
        }

        private string searchCustomerString;
        public string SearchCustomerString
        {
            get { return searchCustomerString; }
            set { searchCustomerString = value; }
        }

        private int searchTypeIndex = 0;
        public int SearchTypeIndex
        {
            get { return searchTypeIndex; }
            set { searchTypeIndex = value; }
        }

        private Customer? currentCustomer = null!;
        public Customer? CurrentCustomer
        {
            get { return currentCustomer; }
            set
            {
                currentCustomer = value;
                OnPropertyChanged();
            }
        }

        private string errorDescription;
        public string ErrorDescription
        {
            get { return errorDescription; }
            set 
            { 
                errorDescription = value;
                OnPropertyChanged();
            }
        }
        private DateTime choosenDateTime = DateTime.Now;
        public DateTime ChoosenDateTime
        {
            get { return choosenDateTime; }
            set
            {
                choosenDateTime = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Vehicle> customerVehicles;
        public ObservableCollection<Vehicle> CustomerVehicles
        {
            get { return customerVehicles; }
            set
            {
                customerVehicles = value;
                OnPropertyChanged();
            }
        }

        private string confirmationText = string.Empty;
        public string ConfirmationText
        {
            get { return confirmationText; }
            set
            {
                confirmationText = value;
                OnPropertyChanged();
            }
        }
        public CreateAppViewModel()
        {
            vehicleController = new VehicleController();
            customerController = new CustomerController();
            appointmentController = new AppointmentController();
        }


        
        private ICommand searchVehicleCommand = null!;
        public ICommand SearchVehicleCommand => searchVehicleCommand ??= searchVehicleCommand = new RelayCommand(() =>
        {
            if (RegistrationNumber != "Registration number")
            {
                CurrentVehicle = vehicleController.GetVehicle(RegistrationNumber);
                if (CurrentVehicle == null)
                {
                    MessageBox.Show("No vehicle could be found, please try again.");
                }
            }
        });

        private ICommand saveVehicleCommand = null!;
        public ICommand SaveVehicleCommand => saveVehicleCommand ??= saveVehicleCommand = new RelayCommand(() =>
        {
            if (CurrentVehicle == null)
            {
                MessageBox.Show("Please search for a vehicle before you try making changes.");
            }
            else if (CurrentVehicle.RegistrationNumber.ToUpper() != RegistrationNumber.ToUpper())
            {
                MessageBox.Show("Are you sure you want to save? Type the vehicles registration number in the search box and press the save-button again to confirm.");
            }
            else
            {
                int rowsChanged = vehicleController.UpdateVehicle(CurrentVehicle);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"The changes has been saved! {rowsChanged}");
                }
                else if (rowsChanged == -1)
                {
                    MessageBox.Show("Something went wrong, please try again!");
                }
                else
                {
                    MessageBox.Show("No changes was made.");
                }
            }
        });
        private ICommand searchCustomerCommand = null!;
        public ICommand SearchCustomerCommand => searchCustomerCommand ??= searchCustomerCommand = new RelayCommand(() =>
        {
            if (SearchTypeIndex == 0)
            {
                CurrentCustomer = customerController.GetCustomerBySSN(SearchCustomerString);
            }
            else if (SearchTypeIndex == 1)
            {
                CurrentCustomer = customerController.GetCustomerByPhone(SearchCustomerString);
            }
            else if (SearchTypeIndex == 2)
            {
                string[] splitString = SearchCustomerString.Split(" ", StringSplitOptions.TrimEntries);
                CurrentCustomer = customerController.GetCustomerByFullName(splitString[0], splitString[1]);
            }
            else if (SearchTypeIndex == -1)
            {
                MessageBox.Show("Please choose what to search by in the drop down menu.");
                return;
            }

            if (CurrentCustomer == null)
            {
                MessageBox.Show("Nothing was found!");
            }
            else
            {
                CustomerVehicles = new ObservableCollection<Vehicle>(vehicleController.GetVehiclesByCustomer(CurrentCustomer));
            }
        });

        private ICommand saveCustomerCommand = null!;
        public ICommand SaveCustomerCommand => saveCustomerCommand ??= saveCustomerCommand = new RelayCommand(() =>
        {
            if (currentCustomer != null)
            {
                int rowsChanged = customerController.UpdateCustomer(currentCustomer);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"The changes has been saved! {rowsChanged}");
                }
                else if (rowsChanged == -1)
                {
                    MessageBox.Show("Something went wrong, please try again!");
                }
                else
                {
                    MessageBox.Show("No changes was made.");
                }
            }
        });

        private ICommand saveAppointmentCommand = null!;
        public ICommand SaveAppointmentCommand => saveAppointmentCommand ??= saveAppointmentCommand = new RelayCommand(() =>
        {
            if (CurrentVehicle == null)
            {
                MessageBox.Show("Please select a vehicle.");
            }
            else if (CurrentCustomer == null)
            {
                MessageBox.Show("Please select a customer.");
            }
            else if (ChoosenDateTime < DateTime.Today)
            {
                MessageBox.Show("The date has passed, select another date.");
            }
            else
            {
                Appointment appointment = new Appointment();
                {
                    appointment.SubmissionDate = ChoosenDateTime;
                    appointment.DeliveryDate = ChoosenDateTime.AddDays(1);
                    appointment.Status = Entities.Enums.AppointmentStatus.Booked;
                    appointment.Purpose = ErrorDescription;
                    appointment.VehicleRegistrationNumber = CurrentVehicle.RegistrationNumber;
                    appointment.CreatedById = UserSessionStore.UserId;
                    appointment.CustomerId = CurrentCustomer.CustomerID;
                }
                int rowsChanged = appointmentController.CreateAppointment(appointment);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"Appointment was saved! {rowsChanged}");
                    //Print bekräftelse

                    ConfirmationText = new string($"Hello {CurrentCustomer.FirstName} {CurrentCustomer.LastName}!" + 
                    $"\n\nWe have created a booking for your car {appointment.VehicleRegistrationNumber}. " +
                    $"\nError descirption: {appointment.Purpose}" +
                    $"\nSubmission: {appointment.SubmissionDate}");

                }
            }
        });

        private ICommand confirmationCommand = null!;
        public ICommand ConfirmationCommand => confirmationCommand ??= confirmationCommand = new RelayCommand(() =>
        {
            if (ConfirmationText != string.Empty)
            {
                MessageBox.Show("Mail sent! (not..)");
            }
        });
    }

}
