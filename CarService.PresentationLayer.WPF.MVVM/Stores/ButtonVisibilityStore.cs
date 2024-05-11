using CarService.PresentationLayer.WPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.PresentationLayer.WPF.MVVM.Stores
{
    public sealed class ButtonVisibilityStore
    {
        private static ButtonVisibilityStore buttonVisibilityStore = null!;
        private static readonly object singletonLock = new object();

        private ButtonVisibilityStore() { }

        public static ButtonVisibilityStore Instance
        {
            get
            {
                lock (singletonLock)
                {
                    if (buttonVisibilityStore == null)
                    {
                        buttonVisibilityStore = new ButtonVisibilityStore();
                    }
                    return buttonVisibilityStore;
                }
            }
        }
        
        public event Action CurrentButtonVisibilityChanged;

        private bool currentButtonVisibility = false;
        public bool CurrentButtonVisibility
        {
            get { return currentButtonVisibility; }
            set
            {
                currentButtonVisibility = value;
                OnCurrentButtonVisibilityChanged();
            }
        }

        private void OnCurrentButtonVisibilityChanged()
        {
            CurrentButtonVisibilityChanged?.Invoke();
        }
    }
}
