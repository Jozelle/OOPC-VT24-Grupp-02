using CarService.BusinessLayer;
using CarService.PresentationLayer.WPF.MVVM.Commands;
using CarService.PresentationLayer.WPF.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class LoginViewModel
    {
        private EmployeeController employeeController;
        
        private string? username;
        public string? Username
        {
            get { return username; }
            set
            {
                username = value;
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }
        public LoginViewModel() 
        { 
            employeeController = new EmployeeController();
        }



        private ICommand loginCommand;
        public ICommand LoginCommand => loginCommand ??= loginCommand = new RelayCommand(() =>
            {
                if (Username.Length > 0 && int.TryParse(Username, out int id))
                {
                    if (employeeController.VerifyUser(id, Password))
                    {
                        if (employeeController.IsReceptionist(id))
                        {
                            //koppla till main
                            //ReceptionistView receptionistView = new ReceptionistView(id);
                            //this.Close();
                            //receptionistView.ShowDialog();
                            MessageBox.Show("Receptionist!");
                        }
                        else
                        {
                            //Koppla till AddItems
                            MechanicView mechanicView = new MechanicView(id);
                            //this.Close();
                            mechanicView.ShowDialog();
                            MessageBox.Show("Mekaniker!");
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
            });


        //private ICommand closeCommand = null!;
        //public ICommand CloseCommand => closeCommand ??= closeCommand = new RelayCommand(() => LoginViewModel.Current.Close());


        private ICommand exitCommand = null!;
        public ICommand ExitCommand => exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

    }
}
