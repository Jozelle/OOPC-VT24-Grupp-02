using CarService.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.PresentationLayer.WPF.MVVM.Models;
using CarService.BusinessLayer;
using CarService.PresentationLayer.WPF.MVVM.Commands;
using System.Windows.Input;
using System.Windows;
using System.Windows.Forms.Design;
using CarService.PresentationLayer.WPF.MVVM.Services;
using Microsoft.Identity.Client.NativeInterop;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class MechanicViewModel : ObservableObject
    {
        //Controllers
        private AppointmentController appointmentController;
        private ItemController itemController;
        private VehicleController vehicleController;
        private EmployeeController employeeController;

        private IWindowService windowService;

        //Properties
        private ObservableCollection<Appointment> todaysAppointments = null!;
        public ObservableCollection<Appointment> TodaysAppointments
        {
            get { return todaysAppointments; }
            set { todaysAppointments = value;
                OnPropertyChanged();
            }
        }
        

        private Appointment currentAppointment = null!;
        public Appointment CurrentAppointment
        {
            get { return currentAppointment; }
            set
            {
                currentAppointment = value;
                OnPropertyChanged();
            }
        }

        private Vehicle currentVehicle = null!;
        public Vehicle CurrentVehicle
        {
            get { return currentVehicle; }
            set { currentVehicle = value;
                OnPropertyChanged();
            }
        }

        private Item currentItem = null!;
        public Item CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value;
                OnPropertyChanged();
            }
        }

        private string inputRegNo = "Please type registration number here!";
        public string InputRegNo
        {
            get { return inputRegNo; }
            set
            {
                inputRegNo = value;
                OnPropertyChanged();
            }
        }

        //private int employeeId;

        private bool isNotModified = true;
        public bool IsNotModified { get { return isNotModified; } set { isNotModified = value; OnPropertyChanged(); } }

        private int selectedAppointmentIndex;
        public int SelectedAppointmentIndex
        {
            get { return selectedAppointmentIndex; }
            set
            {
                selectedAppointmentIndex = value;
                OnPropertyChanged();
            }
        }

        private Appointment selectedAppointment = null!;
        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
            set
            {
                selectedAppointment = value;
                OnPropertyChanged();

                if (selectedAppointment != null)
                {
                    CurrentAppointment = selectedAppointment;
                    CurrentVehicle = selectedAppointment.Vehicle;
                }
            }
        }

        private string inputItemId;
        public string InputItemId
        {
            get { return inputItemId; }
            set 
            { 
                inputItemId = value;
            }
        }

        private string itemQuantity;
        public string ItemQuantity { get; set; }
        public MechanicViewModel()
        {
            appointmentController = new AppointmentController();
            itemController = new ItemController();
            vehicleController = new VehicleController();
            employeeController = new EmployeeController();

            windowService = new WindowService();

            TodaysAppointments = new ObservableCollection<Appointment>();

            RefreshCommand.Execute(null);
        }


        //Commands
        private ICommand refreshCommand = null!;
        public ICommand RefreshCommand => refreshCommand ??= refreshCommand = new RelayCommand(() =>
        {
            TodaysAppointments = new ObservableCollection<Appointment>(appointmentController.GetTodaysAppointments());
            //MenusSelectedItem = (Menus.Count > 0) ? Menus[0] : null!;
            IsNotModified = true;
        });

        private ICommand exitCommand = null!;
        public ICommand ExitCommand => exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        private ICommand searchAppointmentByRegNo = null!;
        public ICommand SearchAppointmentByRegNo => searchAppointmentByRegNo ??= searchAppointmentByRegNo = new RelayCommand(() =>
        {
            TodaysAppointments.Clear();
            TodaysAppointments = new ObservableCollection<Appointment>(appointmentController.GetAppointmentsByRegNo(InputRegNo));

            if (TodaysAppointments.Count <= 0)
            {
                MessageBox.Show("No appointments where found related to that registration number, " +
                    "or the registration number where entered incorrectly. Please try again!", "Oops, something went wrong!");
            }
        });

        private ICommand showJournal = null!;
        public ICommand ShowJournal => showJournal ??= showJournal = new RelayCommand(() =>
        {
            JournalViewModel journalViewModel = new JournalViewModel(CurrentVehicle.RegistrationNumber);
            bool result = windowService.ShowDialog(journalViewModel);
        });

        private ICommand getItemsByIdCommand = null!;
        public ICommand GetItemsByIdCommand => getItemsByIdCommand ??= getItemsByIdCommand = new RelayCommand(() =>
        {
            if (int.TryParse(InputItemId, out int id))
            {
                CurrentItem = itemController.GetItem(id);
            }
            else
            {
                MessageBox.Show("Item ID was not entered correctly, please try again!");
            }
        });

        private ICommand addItemCommand = null!;
        public ICommand AddItemCommand => addItemCommand ??= addItemCommand = new RelayCommand(() =>
        {
            if (int.TryParse(ItemQuantity, out int quantity))
            {
                if (quantity>0) 
                {
                    int affectedRows = appointmentController.EnterItem(currentAppointment, currentItem, quantity);
                    MessageBox.Show($"{quantity} piece(s) of the item {currentItem.Description} was added!" +
                        $"\n{affectedRows} were affected!");
                }
            }
            else { MessageBox.Show(quantity.ToString()); };
        });
    }
}
