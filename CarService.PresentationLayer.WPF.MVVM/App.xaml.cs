using CarService.PresentationLayer.WPF.MVVM.Views;
using CarService.PresentationLayer.WPF.MVVM.ViewModels;
using System.Windows;
using CarService.PresentationLayer.WPF.MVVM.Stores;

namespace CarService.PresentationLayer.WPF.MVVM
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = NavigationStore.Instance;

            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
            //navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);

            ButtonVisibilityStore buttonVisibilityStore = ButtonVisibilityStore.Instance;

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore, buttonVisibilityStore)
                //DataContext = new MainViewModel()
            };
            MainWindow.Show();
            
            base.OnStartup(e);
        }
    }

}
