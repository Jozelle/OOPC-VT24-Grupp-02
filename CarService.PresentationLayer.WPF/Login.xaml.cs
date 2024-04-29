using CarService.BusinessLayer;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        EmployeeController employeeController = new();
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEmployeeID.Text.Length > 0 && int.TryParse(tbxEmployeeID.Text, out int id))
            {
                if (employeeController.VerifyUser(id, tbxPassword.Password))
                {
                    if (employeeController.IsReceptionist(id))
                    {
                        //koppla till main
                        ReceptionistView receptionistView = new ReceptionistView(id);
                        this.Close();
                        receptionistView.ShowDialog();
                    }
                    else
                    {
                        //Koppla till AddItems
                        MechanicView mechanicView = new MechanicView(id);
                        this.Close();
                        mechanicView.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Felaktigt användarnamn eller lösenord, försök igen!");
                }
            }
            else
            {
                MessageBox.Show("Felaktigt användarnamn eller lösenord, försök igen!");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
