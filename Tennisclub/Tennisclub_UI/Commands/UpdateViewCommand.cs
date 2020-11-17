using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tennisclub_UI.ViewModels;

namespace Tennisclub_UI.Commands
{
    public enum Parameters
    {
        Members,
        Roles,
        MemberRoles,
        MemberFines,
        Games,
        GameResults
    }

    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter)
            {
                case nameof(Parameters.Members):
                    viewModel.SelectedViewModel = new MembersViewModel();
                    break;
                case nameof(Parameters.Roles):
                    viewModel.SelectedViewModel = new RolesViewModel();
                    break;
                case nameof(Parameters.MemberRoles):
                    viewModel.SelectedViewModel = new MemberRolesViewModel();
                    break;
                case nameof(Parameters.MemberFines):                    
                    break;
                case nameof(Parameters.Games):                   
                    break;
                case nameof(Parameters.GameResults):                    
                    break;
                default:
                    break;
            }            
        }
    }
}
