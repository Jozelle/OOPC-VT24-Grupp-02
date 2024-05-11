using CarService.PresentationLayer.WPF.MVVM.Stores;
using CarService.PresentationLayer.WPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.PresentationLayer.WPF.MVVM.Commands
{
    public class NavigateJournalCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateJournalCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new JournalViewModel();
            //_navigationStore.CurrentViewModel = new JournalViewModel(_navigationStore);
        }
    }
}
