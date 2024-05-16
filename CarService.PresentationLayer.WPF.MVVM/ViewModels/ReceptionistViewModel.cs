using CarService.BusinessLayer;
using CarService.Entities;
using CarService.PresentationLayer.WPF.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarService.PresentationLayer.WPF.MVVM.Models;
using CarService.Entities.Enums;
using CarService.PresentationLayer.WPF.MVVM.Services;
using System.Windows;
using Microsoft.EntityFrameworkCore.Update.Internal;
using CarService.PresentationLayer.WPF.MVVM.Stores;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class ReceptionistViewModel : ViewModelBase
    {

        //Controllers
        private AppointmentController appointmentController;
        private VehicleController vehicleController;
        private EmployeeController employeeController;

        private ButtonVisibilityStore buttonVisibilityStore { get; }
        public ICommand ButtonsShowCommand { get; }

        //Properties

        private string searchAppointment = "Type here..";
        public string SearchAppointment
        {
            get { return searchAppointment; }
            set { searchAppointment = value; }
        }

        private int searchType = 0;
        public int SearchType
        {
            get { return searchType; }
            set { searchType = value; }
        }

        private ObservableCollection<Appointment> appointments = null!;
        public ObservableCollection<Appointment> Appointments
        {
            get { return appointments; }
            set
            {
                appointments = value;
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
                }
            }
        }



        private List<AppointmentStatus> appointmentsStatuses = null!;
        public List<AppointmentStatus> AppointmentsStatuses
        {
            get { return appointmentsStatuses; }
            set
            {
                appointmentsStatuses = value;
                OnPropertyChanged();
            }
        }



        private AppointmentStatus selectedAppointmentStatus = AppointmentStatus.CarReceived;
        public AppointmentStatus SelectedAppointmentStatus
        {
            get { return selectedAppointmentStatus; }
            set
            {
                selectedAppointmentStatus = value;
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



        private ObservableCollection<Appointment> todaysAppointments = null!;
        public ObservableCollection<Appointment> TodaysAppointments
        {
            get { return todaysAppointments; }
            set
            {
                todaysAppointments = value;
                OnPropertyChanged();
            }
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

        private List<int> availableHours = new List<int> { 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
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
        private int updatedHour = 7;
        public int UpdatedHour
        {
            get { return updatedHour; }
            set
            {
                updatedHour = value;
                OnPropertyChanged();
            }
        }

        private int updatedMinute = 00;
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

        public ReceptionistViewModel()
        {

            appointmentController = new AppointmentController();
            vehicleController = new VehicleController();
            employeeController = new EmployeeController();

            Appointments = new ObservableCollection<Appointment>(appointmentController.GetTodaysAppointments());

            AppointmentsStatuses = Enum.GetValues(typeof(AppointmentStatus)).Cast<AppointmentStatus>().ToList();

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
            Appointments = new ObservableCollection<Appointment>(appointmentController.GetTodaysAppointments());

            //IsNotModified = true;
        });


        private ICommand exitCommand = null!;
        public ICommand ExitCommand => exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());


        private ICommand searchAppointmentCommand = null!;
        public ICommand SearchAppointmentCommand => searchAppointmentCommand ??= searchAppointmentCommand = new RelayCommand(() =>
        {
            if (SearchType == 0)
            {
                //SSNo.
                Appointments = new ObservableCollection<Appointment>(appointmentController.GetAppointmentsBySSNo(SearchAppointment));

            }

            else if (SearchType == 1)
            {
                //PhoneNo.
                Appointments = new ObservableCollection<Appointment>(appointmentController.GetAppointmentsByPhoneNo(SearchAppointment));
            }

            else if (SearchType == 2)
            {
                //FullName
                string[] nameStrings = SearchAppointment.Split(",");
                if (nameStrings != null && nameStrings.Length == 2)
                {
                    Appointments = new ObservableCollection<Appointment>(appointmentController.GetAppointmentsByFullName(nameStrings[0], nameStrings[1]));
                }

            }

            else if (SearchType == 3)
            {
                //RegNo.
                Appointments = new ObservableCollection<Appointment>(appointmentController.GetAppointmentsByRegNo(SearchAppointment));

            }
        });

        private ICommand saveStatusCommand = null!;
        public ICommand SaveStatusCommand => saveStatusCommand ??= saveStatusCommand = new RelayCommand(() =>
        {
            if (SelectedAppointment != null)
            {
                SelectedAppointment.Status = SelectedAppointmentStatus;
                appointmentController.SaveChanges(SelectedAppointment);

                RefreshCommand.Execute(null);
                MessageBox.Show("Status updated successfully!");


            }
        });


        private ICommand addCommentCommand = null!;
        public ICommand AddCommentCommand => addCommentCommand ??= addCommentCommand = new RelayCommand(() =>
        {
            if (InputComment != null)
            {
                Employee employee = employeeController.GetEmployee(UserSessionStore.UserId);
                int affectedrows = appointmentController.AddCommentToAppointment(CurrentAppointment, InputComment, employee);

                Comment comment = new Comment()
                {
                    AuthorEmployeeId = UserSessionStore.UserId,
                    Time = DateTime.Now,
                    Message = InputComment,
                    Appointment = CurrentAppointment

                };

                // Add the comment to the collection of comments for the selected appointment
                if (CurrentAppointment.Comments == null)
                {
                    CurrentAppointment.Comments = new List<Comment>();
                }

                CurrentAppointment.Comments.Add(comment);
            }
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
                CurrentAppointment.SubmissionDate = nDate;
                appointmentController.SaveChanges(CurrentAppointment);
                RefreshCommand.Execute(null);
                MessageBox.Show("Appointment rescheduled successfully!");
            }
            
           
        });

        //private ICommand rescheduleCommand = null!;
        //public ICommand RescheduleCommand => rescheduleCommand ??= rescheduleCommand = new RelayCommand(() =>
        //{

        //    if (CurrentAppointment == null)
        //    {
        //        MessageBox.Show("Please select an appointment.");
        //    }
        //    else
        //    {
        //        CurrentAppointment.SubmissionDate = RescheduleDate;
        //        CurrentAppointment.DeliveryDate = CurrentAppointment.SubmissionDate.AddDays(1);

        //        appointmentController.SaveChanges(CurrentAppointment);
        //        RefreshCommand.Execute(null);
        //        MessageBox.Show("Appointment rescheduled successfully!");
        //    }
        //});
    }
}


    


