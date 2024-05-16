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
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Windows.Media.Animation;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class MechanicViewModel : ViewModelBase
    {
        //Controllers
        private AppointmentController appointmentController;
        private ItemController itemController;
        private EmployeeController employeeController;

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

        private DateTime changedDate = DateTime.Now;
        public DateTime ChangedDate
        {
            get { return changedDate; }
            set
            {
                changedDate = value;
                OnPropertyChanged();
            }
        }

        private List<int> availableHours = new List<int> { 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 };
        public List<int> AvailableHours 
        { 
            get { return availableHours; } 
            set  
            {  
                availableHours = value; 
                OnPropertyChanged(); 
            } 
        }

        private List<int> availableMinutes = new List<int> { 00, 15, 30, 45 };

        public List<int> AvailableMinutes 
        { 
            get { return availableMinutes; } 
            set 
            { 
                availableMinutes = value; 
                OnPropertyChanged(); 
            } 
        }
        private int updatedHour;
        public int UpdatedHour
        {
            get { return updatedHour; }
            set
            {
                updatedHour = value;
                OnPropertyChanged();
            }
        }

        private int updatedMinute;
        public int UpdatedMinute
        {
            get { return updatedMinute; }
            set
            {
                updatedMinute = value;
                OnPropertyChanged();
            }
        }

        

        //Constructor
        public MechanicViewModel()
        {
            appointmentController = new AppointmentController();
            itemController = new ItemController();
            employeeController = new EmployeeController();

            AppointmentStatuses = Enum.GetValues(typeof(AppointmentStatus)).Cast<AppointmentStatus>().ToList();

            TodaysAppointments = new ObservableCollection<Appointment>();

            buttonVisibilityStore = ButtonVisibilityStore.Instance;
            ButtonsShowCommand = new ButtonsShowCommand(buttonVisibilityStore);
            ButtonsShowCommand.Execute(buttonVisibilityStore);

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
                    int affectedRows = appointmentController.EnterItem(CurrentAppointment, CurrentItem, quantity, UserSessionStore.UserId);

                    UsedItem newUsage = new UsedItem();
                    newUsage.Appointment = CurrentAppointment;
                    newUsage.Item = CurrentItem;
                    newUsage.Quantity = quantity;
                    newUsage.AddedById = UserSessionStore.UserId;

                    if (CurrentAppointment.UsedItems == null)
                    {
                        CurrentAppointment.UsedItems = new List<UsedItem>();
                    }

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
                Employee loggedInEmployee = employeeController.GetEmployee(UserSessionStore.UserId);

                int affectedRows = appointmentController.AddCommentToAppointment(currentAppointment, InputComment, loggedInEmployee);
                MessageBox.Show($"The comment was added! {affectedRows} were affected.");

                Comment newComment = new Comment();
                newComment.Appointment = CurrentAppointment;
                newComment.Message = InputComment;
                newComment.Author = loggedInEmployee;
                newComment.Time = DateTime.Now;

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

        private ICommand rescheduleCommand = null!;
        public ICommand RescheduleCommand => rescheduleCommand ??= rescheduleCommand = new RelayCommand(() =>
        {
            if (CurrentAppointment == null)
            {
                MessageBox.Show("Please select an appointment.");
            }
            else
            { 
                TimeSpan ts = new TimeSpan(UpdatedHour, UpdatedMinute, 0);
                DateTime nDate = new DateTime(ChangedDate.Year, ChangedDate.Month, ChangedDate.Day, UpdatedHour, updatedMinute, 0);
                CurrentAppointment.DeliveryDate = nDate;
                appointmentController.SaveChanges(CurrentAppointment);
                RefreshCommand.Execute(null);
                MessageBox.Show("Appointment rescheduled successfully!");
            }
        }); 
    }
}



