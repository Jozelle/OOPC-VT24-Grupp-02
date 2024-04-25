using BusinessLayer;
using CarService.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for CreateAppointmentWindow.xaml
    /// </summary>
    public partial class CreateAppointmentWindow : Window
    {

        CarServiceController controller = new ();

        internal Vehicle currentVehicle;
        internal Customer currentCustomer;

        public CreateAppointmentWindow()
        {
            InitializeComponent();
        }



        private void btn_SearchVehicle_Click(object sender, RoutedEventArgs e)
        {
            string regNo = RegNoTB.Text;
            currentVehicle = controller.GetVehicle(regNo);

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
                //MessageBox.Show("Please fill out all the fields.");
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
                controller.SaveVehicle(vehicle);
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

            if (SelectionBox.SelectedItem == "Social Security No.")
            {

                currentCustomer = controller.GetCustomerBySSN(id);
                SSNumberTB.Text = currentCustomer.SocialSecurityNumber;
            }

            else if (SelectionBox.SelectedItem == "Phone No.")
            {
                currentCustomer = controller.GetCustomerByPhone(phoneNo);
                PhoneNoTB.Text = currentCustomer.PhoneNumber;
            }
            else if (SelectionBox.SelectedItem == "Full name")
            {
                currentCustomer = controller.GetCustomerByFullName(firstName, lastName);
                FirstnameTB.Text = currentCustomer.FirstName;

            }
        }

        private void btn_AddCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            string id = SSNumberTB.Text;
            string phoneNo = PhoneNoTB.Text;
            string firstName = FirstnameTB.Text;
            string lastName = LastnameTB.Text;
            string address = AddressTB.Text;
            string email = EmailTB.Text;

            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(phoneNo) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                //MessageBox.Show("Please fill out all the fields.");
                return;
            }

            else
            {
                Customer customer =  new Customer();
                {
                    customer.SocialSecurityNumber = id;
                    customer.PhoneNumber = phoneNo;
                    customer.FirstName = firstName;
                    customer.LastName = lastName;
                    customer.Address = null;
                    customer.Email = null;
                }
                controller.SaveCustomer(customer);
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

                else if (selectedDate<DateTime.Today) 
                {
                    MessageBox.Show("The date has passed, select another date.");
                }
                else 
                { Appointment appointment = new Appointment();
                    
                    { 
                    appointment.SubmissionDate = selectedDate;
                    appointment.DeliveryDate = selectedDate.AddDays(1);
                    appointment.Status = Entities.Enums.AppointmentStatus.Booked;
                    appointment.Purpose = ReportedIssues.Text;
                    appointment.VehicleRegistrationNumber = currentVehicle.RegistrationNumber;
                    appointment.CreatedById = 1;
                    appointment.CustomerId = currentCustomer.CustomerID;
          
                    } 
                   controller.CreateAppointment(appointment);
                    
                }


        }

       
    }
}
