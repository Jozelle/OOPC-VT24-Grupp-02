using CarService.PresentationLayer.WPF.MVVM.Commands;
using CarService.PresentationLayer.WPF.MVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        private readonly ButtonVisibilityStore _buttonVisibilityStore;
        public bool IsButtonsVisible => _buttonVisibilityStore.CurrentButtonVisibility;

        public ICommand NavigateMechanicCommand;
        public ICommand NavigateReceptionistCommand;
        public ICommand NavigateJournalCommand;
        public ICommand NavigateLogoutCommand;
        public ICommand NavigateCreateAppCommand;
        public ICommand NavigateCreateVehicleCommand;
        public ICommand ButtonsHideCommand;

        private bool receptionistIsChecked;
        public bool ReceptionistIsChecked
        {
            get => receptionistIsChecked;
            set => receptionistIsChecked = value;
        }

        private bool mechanicIsChecked;
        public bool MechanicIsChecked
        {
            get => mechanicIsChecked;
            set => mechanicIsChecked = value;
        }

        public MainViewModel(NavigationStore navigationStore, ButtonVisibilityStore buttonVisibilityStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _buttonVisibilityStore = buttonVisibilityStore;
            _buttonVisibilityStore.CurrentButtonVisibilityChanged += OnCurrentButtonVisibilityChanged;
        }

        public MainViewModel()
        {
            _navigationStore = NavigationStore.Instance;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _buttonVisibilityStore = ButtonVisibilityStore.Instance;
            _buttonVisibilityStore.CurrentButtonVisibilityChanged += OnCurrentButtonVisibilityChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnCurrentButtonVisibilityChanged()
        {
            OnPropertyChanged(nameof(IsButtonsVisible));
        }

        private ICommand goToMechanicViewCommand;
        public ICommand GoToMechanicViewCommand => goToMechanicViewCommand ??= goToMechanicViewCommand = new RelayCommand(() =>
        {
            NavigateMechanicCommand = new NavigateMechanicCommand(_navigationStore);

            NavigateMechanicCommand.Execute(1);
        });

        private ICommand goToJournalViewCommand;
        public ICommand GoToJournalViewCommand => goToJournalViewCommand ??= goToJournalViewCommand = new RelayCommand(() =>
        {
            NavigateJournalCommand = new NavigateJournalCommand(_navigationStore);
            
            NavigateJournalCommand.Execute(1);
        });

        private ICommand goToReceptionistViewCommand;
        public ICommand GoToReceptionistViewCommand => goToReceptionistViewCommand ??= goToReceptionistViewCommand = new RelayCommand(() =>
        {
            NavigateReceptionistCommand = new NavigateReceptionistCommand(_navigationStore);

            NavigateReceptionistCommand.Execute(1);
        });

        private ICommand goToCreateAppViewCommand;
        public ICommand GoToCreateAppViewCommand => goToCreateAppViewCommand ??= goToCreateAppViewCommand = new RelayCommand(() =>
        {
            NavigateCreateAppCommand = new NavigateCreateAppCommand(_navigationStore);

            NavigateCreateAppCommand.Execute(1);
        });

        private ICommand goToCreateVehicleViewCommand;
        public ICommand GoToCreateVehicleViewCommand => goToCreateVehicleViewCommand ??= goToCreateVehicleViewCommand = new RelayCommand(() =>
        {
            NavigateCreateVehicleCommand = new NavigateCreateVehicleCommand(_navigationStore);

            NavigateCreateVehicleCommand.Execute(1);
        });

        private ICommand logoutCommand;
        public ICommand LogoutCommand => logoutCommand ??= logoutCommand = new RelayCommand(() =>
        {
            NavigateLogoutCommand = new NavigateLogoutCommand(_navigationStore);
            NavigateLogoutCommand.Execute(1);

            ButtonsHideCommand = new ButtonsHideCommand(_buttonVisibilityStore);
            ButtonsHideCommand.Execute(1);
        });

        private ICommand exitCommand = null!;
        public ICommand ExitCommand => exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());
    }
}
