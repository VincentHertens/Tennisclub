using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tennisclub_WPF.ViewModels;

namespace Tennisclub_WPF.Commands
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
                    viewModel.SelectedViewModel = new MemberViewModel();
                    break;
                case nameof(Parameters.Roles):
                    viewModel.SelectedViewModel = new RoleViewModel();
                    break;
                case nameof(Parameters.MemberRoles):
                    viewModel.SelectedViewModel = new MemberRoleViewModel();
                    break;
                case nameof(Parameters.MemberFines):
                    viewModel.SelectedViewModel = new MemberFineViewModel();
                    break;
                case nameof(Parameters.Games):
                    viewModel.SelectedViewModel = new GameViewModel();
                    break;
                case nameof(Parameters.GameResults):
                    viewModel.SelectedViewModel = new GameResultViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
