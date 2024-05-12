using CarService.PresentationLayer.WPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.PresentationLayer.WPF.MVVM.Stores
{
    public class NavigationStore
    {
        private static NavigationStore navigationStore = null!;
        private static readonly object singletonLock = new object();

        private NavigationStore() { }

        public static NavigationStore Instance
        {
            get
            {
                lock (singletonLock)
                {
                    if (navigationStore == null)
                    {
                        navigationStore = new NavigationStore();
                    }
                    return navigationStore;
                }
            }
        }

        public event Action CurrentViewModelChanged;

        private ViewModelBase currentViewModel = null!;
        public ViewModelBase CurrentViewModel 
        {
            get { return currentViewModel; }
            set 
            { 
                currentViewModel = value;
                OnCurrentViewModelChanged();
            } 
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
