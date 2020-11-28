using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tennisclub_Common.RoleDTO;

namespace Tennisclub_WPF.Views
{
    /// <summary>
    /// Interaction logic for RoleView.xaml
    /// </summary>
    public partial class RoleView : UserControl
    {
        public RoleView()
        {
            InitializeComponent();
            _ = LoadRoles();
        }

        private async Task LoadRoles()
        {
            List<RoleReadDto> rolesList = await WebAPI.Get<List<RoleReadDto>>("roles");
            RolesDataGrid.ItemsSource = rolesList;
        }

        private async Task AddRole()
        {
            //TODO Validation
            RoleCreateDto role = new RoleCreateDto
            {
                Name = ManagementNameTextBox.Text
            };

            await WebAPI.Post<RoleReadDto, RoleCreateDto>("roles", role);
            _ = LoadRoles();
        }

        private async Task UpdateRole()
        {
            //TODO Validation
            RoleReadDto roleToUpdate = RolesDataGrid.SelectedItem as RoleReadDto;
            RoleUpdateDto role = new RoleUpdateDto
            {
                Id = roleToUpdate.Id,
                Name = ManagementNameTextBox.Text
            };

            await WebAPI.Put<RoleReadDto, RoleUpdateDto>("roles", role);
            _ = LoadRoles();
        }

        private void AddRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = AddRole();
        }

        private void UpdateRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to update this role?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = UpdateRole();
            }
        }

        private void NewRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            RolesDataGrid.SelectedItem = null;
        }
    }
}
