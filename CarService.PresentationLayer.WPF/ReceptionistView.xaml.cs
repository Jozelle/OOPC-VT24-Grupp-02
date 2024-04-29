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
    public partial class ReceptionistView : Window
    {
        AppointmentController appointmentController = new AppointmentController();
        EmployeeController employeeController = new EmployeeController();

        internal Appointment currentAppointment;
        internal int loggedInEmployee;

        internal ObservableCollection<Appointment> _appointments = new ObservableCollection<Appointment>();
        public ReceptionistView(int id)
        {
            InitializeComponent();

            loggedInEmployee = id;

            CurrentAppLB.ItemsSource = _appointments;


            IList<Appointment> hej = appointmentController.GetTodaysAppointments();

            foreach (Appointment appointment in hej)
            {
                _appointments.Add(appointment);
            }
            //if (_appointments.Count > 0 && _appointments != null)
            //{
            //    CurrentAppLB.ItemsSource = _appointments;
            //}
        }

        private void btn_CreateBooking_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointment createAppointment = new CreateAppointment(loggedInEmployee);
            createAppointment.ShowDialog();

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
                int selected = StausBox.SelectedIndex;
                int index = _appointments.IndexOf(currentAppointment);
                switch (selected)
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

                int affectedRows = appointmentController.SaveChanges(currentAppointment);
                if (affectedRows > 0)
                {
                    MessageBox.Show("The status was changed!");
                    _appointments[index] = currentAppointment;
                    CurrentAppLB.ItemsSource = null;
                    CurrentAppLB.ItemsSource = _appointments;
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment first!");
            }
        }

        private void btn_AddComment_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = employeeController.GetEmployee(loggedInEmployee);

            int affectedRows = appointmentController.AddCommentToAppointment(currentAppointment, AddCommentTB.Text, employee);
            if (affectedRows > 0)
            {
                MessageBox.Show("The comment was added!");
            }
        }

        private void btn_ViewJournal_Click(object sender, RoutedEventArgs e)
        {
            if (currentAppointment != null)
            {
                Journal journal = new Journal(currentAppointment.VehicleRegistrationNumber);
                journal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an appointment first!");
            }

        }
    }
}
