using CarService.BusinessLayer;
using CarService.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for CreateAppointmentWindow.xaml
    /// </summary>
    public partial class CreateAppointmentWindow : Window
    {

        VehicleController vehicleController = new();
        EmployeeController employeeController = new EmployeeController();
        CustomerController customerController = new CustomerController();
        AppointmentController appointmentController = new AppointmentController();

        internal Vehicle currentVehicle;
        internal Customer currentCustomer;
        internal IList<Appointment> appointments =new ObservableCollection<Appointment>();

        public CreateAppointmentWindow()
        {
            InitializeComponent();
            appointments = appointmentController.GetAllAppointments();
            AllAppLB.ItemsSource = appointments;

        }
        private void btn_SearchVehicle_Click(object sender, RoutedEventArgs e)
        {
            string regNo = RegNoTB.Text;
            currentVehicle = vehicleController.GetVehicle(regNo);

            if (currentVehicle == null)
            {
                //MessageBox.Show("No vehicle could be found, please try again.");
            }

            else
            {
                MakeTB.Text = currentVehicle.Make;
                ModelTB.Text = currentVehicle.Model;
                YearTB.Text = currentVehicle.Year;
            }
        }

        private void btn_SaveVehicle_Click(object sender, RoutedEventArgs e)
        {
            string regNo = RegNoTB.Text;
            string make = MakeTB.Text;
            string model = ModelTB.Text;
            string year = YearTB.Text;

            if (string.IsNullOrEmpty(regNo) && string.IsNullOrEmpty(make) && string.IsNullOrEmpty(model) && string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Please fill out all the fields.");
                return;
            }
            else
            {
                Vehicle vehicle = new Vehicle
                {
                    RegistrationNumber = regNo,
                    Make = make,
                    Model = model,
                    Year = year
                };
                int rowsChanged = vehicleController.SaveVehicle(vehicle);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"Ändringar sparades! {rowsChanged}");
                }
                currentVehicle = vehicle;
            }

        }



        private void SelectionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelectionBox_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void btn_SearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            string id = SSNumberTB.Text;
            string phoneNo = PhoneNoTB.Text;
            string firstName = FirstnameTB.Text;
            string lastName = LastnameTB.Text;

            if (SelectionBox.SelectedIndex == 0)
            {
                currentCustomer = customerController.GetCustomerBySSN(id);
            }
            else if (SelectionBox.SelectedIndex == 1)
            {
                currentCustomer = customerController.GetCustomerByPhone(phoneNo);
            }
            else if (SelectionBox.SelectedIndex == 2)
            {
                currentCustomer = customerController.GetCustomerByFullName(firstName, lastName);
            }
            else if (SelectionBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose what to search by in the drop down menu.");
                return;
            }

            SSNumberTB.Text = currentCustomer.SocialSecurityNumber.ToString();
            PhoneNoTB.Text = currentCustomer?.PhoneNumber;
            FirstnameTB.Text = currentCustomer?.FirstName;
            LastnameTB.Text = currentCustomer.LastName;
            EmailTB.Text = currentCustomer?.Email;
            AddressTB.Text = currentCustomer?.Address;

        }
        private void btn_SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            string id = SSNumberTB.Text;
            string phoneNo = PhoneNoTB.Text;
            string firstName = FirstnameTB.Text;
            string lastName = LastnameTB.Text;
            string? address = AddressTB.Text;
            string? email = EmailTB.Text;

            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(phoneNo) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please fill out all the fields.");
                return;
            }

            else
            {
                Customer customer = new Customer();
                {
                    customer.SocialSecurityNumber = id;
                    customer.PhoneNumber = phoneNo;
                    customer.FirstName = firstName;
                    customer.LastName = lastName;
                    customer.Address = address;
                    customer.Email = email;
                }
                int rowsChanged = customerController.SaveCustomer(customer);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"Ändringar sparades! {rowsChanged}");
                }
                currentCustomer = customer;
            }
        }




        private void btn_SaveAppointment_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = (DateTime)AppDate.SelectedDate;

            if (selectedDate == null)
            {
                MessageBox.Show("Please select a date for the appointment.");

            }

            else if (currentVehicle == null)
            {
                MessageBox.Show("Please select a vehicle.");

            }

            else if (currentCustomer == null)
            {
                MessageBox.Show("Please select a customer.");
            }

            else if (selectedDate < DateTime.Today)
            {
                MessageBox.Show("The date has passed, select another date.");
            }
            else
            {
                Appointment appointment = new Appointment();

                {
                    appointment.SubmissionDate = selectedDate;
                    appointment.DeliveryDate = selectedDate.AddDays(1);
                    appointment.Status = Entities.Enums.AppointmentStatus.Booked;
                    appointment.Purpose = ReportedIssues.Text;
                    appointment.VehicleRegistrationNumber = currentVehicle.RegistrationNumber;
                    appointment.CreatedById = 1;
                    appointment.CustomerId = currentCustomer.CustomerID;

                }
                int rowsChanged = appointmentController.CreateAppointment(appointment);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"Ändringar sparades! {rowsChanged}");
                }
            }


        }


    }
}
