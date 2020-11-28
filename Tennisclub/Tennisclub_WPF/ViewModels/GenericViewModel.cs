using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tennisclub_WPF.ViewModels
{
    public abstract class GenericViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
