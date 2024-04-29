using CarService.BusinessLayer;
using CarService.Entities;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
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

        internal int loggedInEmployee;
        internal Vehicle currentVehicle;
        internal Customer? currentCustomer;
        internal IList<Appointment> appointments = new ObservableCollection<Appointment>();

        public CreateAppointmentWindow(int id)
        {
            InitializeComponent();

            loggedInEmployee = id;  
            appointments = appointmentController.GetAllAppointments();
            AllAppLB.ItemsSource = appointments;

        }
        private void btn_SearchVehicle_Click(object sender, RoutedEventArgs e)
        {
            string regNo = RegNoTB.Text;
            currentVehicle = vehicleController.GetVehicle(regNo);

            if (currentVehicle == null)
            {
                MessageBox.Show("No vehicle could be found, please try again.");
            }

            else
            {
                MakeTB.Text = currentVehicle.Make;
                ModelTB.Text = currentVehicle.Model;
                YearTB.Text = currentVehicle.Year;
            }
        }

        private void btn_SaveChangesVehicle_Click(object sender, RoutedEventArgs e)
        {
            string regNo = RegNoTB.Text;
            string make = MakeTB.Text;
            string model = ModelTB.Text;
            string year = YearTB.Text;

            if (currentVehicle == null)
            {
                MessageBox.Show("Please search for a vehicle before you try making changes.");
            }
            else if (string.IsNullOrEmpty(regNo) || string.IsNullOrEmpty(make) || string.IsNullOrEmpty(model) || string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Please fill out all the fields.");
                return;
            }
            else if (regNo.Length != 6)
            {
                MessageBox.Show("The registration number is not in the correct format, please try again.");
            }
            else if (currentVehicle.RegistrationNumber != regNo)
            {
                MessageBox.Show("Something went wrong, please enter vehicle details and try again!");
                MakeTB.Text = string.Empty;
                ModelTB.Text = string.Empty;
                YearTB.Text = string.Empty;

                currentVehicle = null;
            }
            else
            {
                Vehicle vehicle = new Vehicle
                {
                    RegistrationNumber = RegNoTB.Text,
                    Make = MakeTB.Text,
                    Model = ModelTB.Text,
                    Year = YearTB.Text
                };

                int rowsChanged = vehicleController.UpdateVehicle(vehicle);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"The changes has been saved! {rowsChanged}");
                    currentVehicle = vehicle;
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
        }
        private void btn_AddNewVehicle_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(RegNoTB.Text) || string.IsNullOrEmpty(MakeTB.Text) || string.IsNullOrEmpty(ModelTB.Text) || string.IsNullOrEmpty(YearTB.Text))
            {
                MessageBox.Show("Please fill out all the fields.");
            }
            else if (RegNoTB.Text.Length != 6)
            {
                MessageBox.Show("The registration number is not in the correct format, please try again.");
            }
            else if (ModelTB.Text == "Model" || MakeTB.Text == "Make" || YearTB.Text == "Year")
            {
                MessageBox.Show("Please fill out all the fields.");
            }
            else
            {
                Vehicle vehicle = new Vehicle
                {
                    RegistrationNumber = RegNoTB.Text,
                    Make = MakeTB.Text,
                    Model = ModelTB.Text,
                    Year = YearTB.Text
                };

                int rowsChanged = vehicleController.SaveVehicle(vehicle);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"Ändringar sparades! {rowsChanged}");
                    currentVehicle = vehicle;
                }
                else if (rowsChanged == -1) 
                {
                    MessageBox.Show("That social registration number is already signed up as a vehicle. I filled in the details for you!");
                    currentVehicle = vehicleController.GetVehicle(RegNoTB.Text);

                    RegNoTB.Text = currentVehicle.RegistrationNumber;
                    MakeTB.Text = currentVehicle.Make;
                    ModelTB.Text = currentVehicle.Model;
                    YearTB.Text = currentVehicle.Year;
                }
            }
        }

        private void SelectionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentCustomer = null;
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

            if (currentCustomer != null)
            {
                SSNumberTB.Text = currentCustomer.SocialSecurityNumber.ToString();
                PhoneNoTB.Text = currentCustomer?.PhoneNumber;
                FirstnameTB.Text = currentCustomer?.FirstName;
                LastnameTB.Text = currentCustomer.LastName;
                EmailTB.Text = currentCustomer?.Email;
                AddressTB.Text = currentCustomer?.Address;

                //MessageBox.Show(currentCustomer.CustomerID.ToString());
            }
            else MessageBox.Show("Nothing was found!");
        }
        private void btn_SaveChangesCustomer_Click(object sender, RoutedEventArgs e)
        {
            string id = SSNumberTB.Text;
            string phoneNo = PhoneNoTB.Text;
            string firstName = FirstnameTB.Text;
            string lastName = LastnameTB.Text;
            string? address = AddressTB.Text;
            string? email = EmailTB.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(phoneNo) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || id == "Social Security No." || phoneNo == "Phone No." || firstName == "First name" || lastName == "Last name")
            {
                MessageBox.Show("Please fill out all the fields.");
                currentCustomer = null;
                return;
            }
            else if (currentCustomer != null)
            {
                if (address == "Address")
                {
                    address = null;
                }

                if (!email.Contains('@'))
                {
                    email = null;
                }
                
                Customer customer = new Customer();
                {
                    customer.CustomerID = currentCustomer.CustomerID;
                    customer.SocialSecurityNumber = id;
                    customer.PhoneNumber = phoneNo;
                    customer.FirstName = firstName;
                    customer.LastName = lastName;
                    customer.Address = address;
                    customer.Email = email;
                }

                int rowsChanged = customerController.UpdateCustomer(customer);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"The changes has been saved! {rowsChanged}");
                }
                if (rowsChanged == -1)
                {
                    MessageBox.Show("Something went wrong, please try again!");
                }
                currentCustomer = customer;
            }
            else
            {
                MessageBox.Show("Please search for a customer before you try making changes.");
            }
        }
        private void btn_AddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SSNumberTB.Text) || string.IsNullOrEmpty(PhoneNoTB.Text) || string.IsNullOrEmpty(FirstnameTB.Text) || string.IsNullOrEmpty(LastnameTB.Text))
            {
                MessageBox.Show("Please fill out all the fields.");
                currentCustomer = null;
                return;
            }
            else
            {
                Customer customer = new Customer();
                {
                    customer.SocialSecurityNumber = SSNumberTB.Text;
                    customer.PhoneNumber = PhoneNoTB.Text;
                    customer.FirstName = FirstnameTB.Text;
                    customer.LastName = LastnameTB.Text;
                    customer.Address = AddressTB.Text;
                    customer.Email = EmailTB.Text;
                }

                int rowsChanged = customerController.SaveCustomer(customer);

                if (rowsChanged > 0)
                {
                    MessageBox.Show($"The customer was added! {rowsChanged}");
                    currentCustomer = customerController.GetCustomerBySSN(SSNumberTB.Text);
                }
                else if (rowsChanged == -1)
                {
                    MessageBox.Show("That social security number is already signed up as a customer. I filled in the details for you!");
                    currentCustomer = customerController.GetCustomerBySSN(SSNumberTB.Text);

                    SSNumberTB.Text = currentCustomer.SocialSecurityNumber.ToString();
                    PhoneNoTB.Text = currentCustomer.PhoneNumber;
                    FirstnameTB.Text = currentCustomer.FirstName;
                    LastnameTB.Text = currentCustomer.LastName;
                    EmailTB.Text = currentCustomer?.Email;
                    AddressTB.Text = currentCustomer?.Address;
                }
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
                    appointment.CreatedById = loggedInEmployee;
                    appointment.CustomerId = currentCustomer.CustomerID;

                }
                int rowsChanged = appointmentController.CreateAppointment(appointment);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"Ändringar sparades! {rowsChanged}");
                    appointments.Add(appointment);

                    this.Close();
                }
            }


        }

        private void RegNoTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            RegNoTB.Text = "";
        }

        private void MakeTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            MakeTB.Text = string.Empty;
        }

        private void ModelTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            ModelTB.Text = string.Empty;
        }

        private void YearTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            YearTB.Text = string.Empty;
        }

        private void FirstnameTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            FirstnameTB.Text = "";
        }

        private void LastnameTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            LastnameTB.Text = "";
        }

        private void SSNumberTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            SSNumberTB.Text = string.Empty;
        }

        private void AddressTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            AddressTB.Text = string.Empty;
        }

        private void PhoneNoTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            PhoneNoTB.Text = string.Empty;
        }

        private void EmailTB_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            EmailTB.Text = string.Empty;
        }
    }
}
