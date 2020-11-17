using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tennisclub_UI.Commands;

namespace Tennisclub_UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel = new MembersViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set 
            { 
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {          
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
