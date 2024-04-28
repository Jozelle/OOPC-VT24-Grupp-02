using CarService.BusinessLayer;
using CarService.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        AppointmentController appointmentController = new AppointmentController();
        EmployeeController employeeController = new EmployeeController();

        internal Appointment currentAppointment;
        internal int loggedInEmployee;

        internal IList<Appointment> _appointments = new ObservableCollection<Appointment>();
        public Main(int id)
        {
            InitializeComponent();

            loggedInEmployee = id;

            _appointments = appointmentController.GetTodaysAppointments();
            if (_appointments.Count > 0 && _appointments != null)
            {
                CurrentAppLB.ItemsSource = _appointments;
            }
        }

        private void btn_CreateBooking_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointmentWindow createAppointmentWindow = new CreateAppointmentWindow(loggedInEmployee);
            createAppointmentWindow.ShowDialog();

        }

        private void btn_OkAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentAppLB.SelectedItem != null)
            {
                currentAppointment = (Appointment)CurrentAppLB.SelectedItem;
                SelectedAppTB.Text = currentAppointment.AppointmentId.ToString();
            }
            else
            {
                MessageBox.Show("Please select an appointment in the list.");
            }
        }
        private void btn_SearchAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (selectSearchTypeBox.SelectedIndex == 0)
            {
                //SSNo.
                CurrentAppLB.ItemsSource = appointmentController.GetAppointmentsBySSNo(SearchAppTB.Text);

            }

            else if (selectSearchTypeBox.SelectedIndex == 1)
            {
                //PhoneNo.
                CurrentAppLB.ItemsSource = appointmentController.GetAppointmentsByPhoneNo(SearchAppTB.Text);
            }

            else if (selectSearchTypeBox.SelectedIndex == 2)
            {
                //FullName
                string[] nameStrings = SearchAppTB.Text.Split(",");
                if (nameStrings != null && nameStrings.Length == 2)
                {
                    CurrentAppLB.ItemsSource = appointmentController.GetAppointmentsByFullName(nameStrings[0], nameStrings[1]);
                }

            }

            else if (selectSearchTypeBox.SelectedIndex == 3)
            {
                //RegNo.
                CurrentAppLB.ItemsSource = appointmentController.GetAppointmentsByRegNo(SearchAppTB.Text);

            }


        }

        private void btn_SaveStatus_Click(object sender, RoutedEventArgs e)
        {
            if (currentAppointment != null)
            {
                Appointment copyAppointment = currentAppointment as Appointment;

                switch (StausBox.SelectedIndex)
                {
                    case 0:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.CarReceived;

                        break;

                    case 1:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.Booked;

                        break;

                    case 2:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.InProgress;

                        break;

                    case 3:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.WaitingForParts;

                        break;

                    case 4:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.ReadyForPickup;

                        break;

                    case 5:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.Canceled;

                        break;

                    case 6:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.Completed;

                        break;

                }

                appointmentController.SaveChanges(copyAppointment, currentAppointment);

            }
        }

        private void btn_AddComment_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = employeeController.GetEmployee(loggedInEmployee);

            int affectedRows = appointmentController.AddCommentToAppointment(currentAppointment, AddCommentTB.Text, employee);

            MessageBox.Show(affectedRows.ToString());

        }

        private void btn_ViewJournal_Click(object sender, RoutedEventArgs e)
        {
            Journal journal = new Journal(currentAppointment.VehicleRegistrationNumber);
            journal.ShowDialog();

        }
    }
}
