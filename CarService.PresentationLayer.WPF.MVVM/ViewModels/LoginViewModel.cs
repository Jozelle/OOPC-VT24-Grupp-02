using CarService.BusinessLayer;
using CarService.PresentationLayer.WPF.MVVM.Commands;
using CarService.PresentationLayer.WPF.MVVM.Stores;
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
    public class LoginViewModel : ViewModelBase
    {
        private EmployeeController employeeController;

        public ICommand NavigateMechanicCommand { get; }

        private string? username;
        public string? Username
        {
            get { return username; }
            set { username = value; }
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

        public LoginViewModel(NavigationStore navigationStore)
        //public LoginViewModel()
        { 
            employeeController = new EmployeeController();
            NavigateMechanicCommand = new NavigateMechanicCommand(navigationStore);

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

                        MessageBox.Show("Receptionist!");
                    }
                    else
                    {
                        NavigateMechanicCommand.Execute(id);
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
    }
}
