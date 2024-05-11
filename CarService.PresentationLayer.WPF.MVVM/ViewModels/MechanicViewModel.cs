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
using CarService.Entities.Enums;
using CarService.PresentationLayer.WPF.MVVM.Stores;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class MechanicViewModel : ViewModelBase
    {
        //Controllers
        private AppointmentController appointmentController;
        private ItemController itemController;
        private EmployeeController employeeController;

        private int loggedInId;
        public ICommand NavigateJournalCommand { get; }
        private ButtonVisibilityStore buttonVisibilityStore { get; }
        public ICommand ButtonsShowCommand { get; }
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

        private ObservableCollection<Item> currentItems = null!;
        public ObservableCollection<Item> CurrentItems
        {
            get { return currentItems; }
            set
            {
                currentItems = value;
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

        private string inputItemId = null!;
        public string InputItemId
        {
            get { return inputItemId; }
            set 
            { 
                inputItemId = value;
                OnPropertyChanged();
            }
        }

        private string itemQuantity = null!;
        public string ItemQuantity 
        {
            get { return itemQuantity; }
            set
            {
                itemQuantity = value;
                OnPropertyChanged();
            }
        }

        private string inputComment = null!;
        public string InputComment
        {
            get { return inputComment; }
            set
            {
                inputComment = value;
                OnPropertyChanged();
            }
        }

        private List<AppointmentStatus> appointmentStatuses;
        public List<AppointmentStatus> AppointmentStatuses 
        { 
            get { return appointmentStatuses; }
            set
            {
                appointmentStatuses = value;
                OnPropertyChanged();
            }
        }

        private AppointmentStatus appointmentStatus = AppointmentStatus.Booked;
        public AppointmentStatus AppointmentStatus
        {
            get { return appointmentStatus; }
            set
            {
                appointmentStatus = value;
                OnPropertyChanged();
            }
        }

        //Constructor
        //public MechanicViewModel(NavigationStore navigationStore)
        public MechanicViewModel()
        {
            appointmentController = new AppointmentController();
            itemController = new ItemController();
            employeeController = new EmployeeController();

            loggedInId = 2;
            AppointmentStatuses = Enum.GetValues(typeof(AppointmentStatus)).Cast<AppointmentStatus>().ToList();

            TodaysAppointments = new ObservableCollection<Appointment>();

            buttonVisibilityStore = ButtonVisibilityStore.Instance;
            ButtonsShowCommand = new ButtonsShowCommand(buttonVisibilityStore);
            ButtonsShowCommand.Execute(buttonVisibilityStore);

            //NavigateJournalCommand = new NavigateJournalCommand(navigationStore);

            RefreshCommand.Execute(null);
        }


        //Commands
        private ICommand refreshCommand = null!;
        public ICommand RefreshCommand => refreshCommand ??= refreshCommand = new RelayCommand(() =>
        {
            TodaysAppointments = new ObservableCollection<Appointment>(appointmentController.GetTodaysAppointments());

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
            //JournalViewModel journalViewModel = new JournalViewModel(CurrentVehicle.RegistrationNumber);
        });

        private ICommand getItemsCommand = null!;
        public ICommand GetItemsCommand => getItemsCommand ??= getItemsCommand = new RelayCommand(() =>
        {
            if (int.TryParse(InputItemId, out int id))
            {
                CurrentItems = [itemController.GetItem(id)];
            }
            else
            {
                CurrentItems = new ObservableCollection<Item>(itemController.GetItemsByDesc(InputItemId));
            }

            CurrentItem = (CurrentItems.Count > 0) ? CurrentItems[0] : null!;
        });

        private ICommand addItemCommand = null!;
        public ICommand AddItemCommand => addItemCommand ??= addItemCommand = new RelayCommand(() =>
        {
            if (int.TryParse(ItemQuantity, out int quantity))
            {
                if (quantity>0) 
                {
                    int affectedRows = appointmentController.EnterItem(CurrentAppointment, CurrentItem, quantity);

                    UsedItem newUsage = new UsedItem();
                    newUsage.Appointment = CurrentAppointment;
                    newUsage.Item = CurrentItem;
                    newUsage.Quantity = quantity;

                    CurrentAppointment.UsedItems.Add(newUsage);

                    MessageBox.Show($"{quantity} piece(s) of the item {currentItem.Description} was added!" +
                        $"\n{affectedRows} were affected!");
                }
            }
            else { MessageBox.Show(quantity.ToString()); };
        });

        private ICommand addCommentCommand = null!;
        public ICommand AddCommentCommand => addCommentCommand ??= addCommentCommand = new RelayCommand(() =>
        {
            if (InputComment != null)
            {
                Employee loggedInEmployee = employeeController.GetEmployee(loggedInId);

                int affectedRows = appointmentController.AddCommentToAppointment(currentAppointment, InputComment, loggedInEmployee);
                MessageBox.Show($"The comment was added! {affectedRows} were affected.");

                Comment newComment = new Comment();
                newComment.Appointment = CurrentAppointment;
                newComment.Message = InputComment;
                newComment.Author = loggedInEmployee;

                CurrentAppointment.Comments.Add(newComment);
            }
            else
            {
                MessageBox.Show("Please enter a comment!");
            }
        });

        private ICommand updateStatusCommand = null!;
        public ICommand UpdateStatusCommand => updateStatusCommand ??= updateStatusCommand = new RelayCommand(() =>
        {
            CurrentAppointment.Status = AppointmentStatus;
            int affectedRows = appointmentController.SaveChanges(currentAppointment);

            RefreshCommand.Execute(null);
            MessageBox.Show("The status was changed!");
        });
    }
}
