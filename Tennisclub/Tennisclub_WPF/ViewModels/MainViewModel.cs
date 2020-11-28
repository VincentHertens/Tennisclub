using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tennisclub_WPF.Commands;

namespace Tennisclub_WPF.ViewModels
{
    public class MainViewModel : GenericViewModel
    {
        private GenericViewModel _selectedViewModel = new MemberViewModel();

        public GenericViewModel SelectedViewModel
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
