using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Tennisclub_Mapping.Dtos;
using Tennisclub_UI.Helpers;

namespace Tennisclub_UI.Views
{
    /// <summary>
    /// Interaction logic for RolesView.xaml
    /// </summary>
    public partial class RolesView : UserControl
    {
        public RolesView()
        {
            InitializeComponent();
        }

        private void RolesListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            GetRoles();
        }

        private void OverviewUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RolesListDataGrid.SelectedItem is RoleReadDto role)
            {
                UpdateRoleTabItem.IsSelected = true;
                UpdateRoleTabItem.Visibility = Visibility.Visible;

                RoleIdTextBox.Text = role.Id.ToString();
                UpdateNameTextBox.Text = role.Name;
            }
            else
            {
                MessageBox.Show("Select a Role!");
            }
        }

        private void AddRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            RoleCreateDto role = new RoleCreateDto{ Name = AddNameTextBox.Text };

            HttpResponseMessage response = APIHelper.ApiClient.PostAsJsonAsync("api/roles/", role).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Role Added!");
                AddNameTextBox.Text = null;
                RolesOverviewTabItem.IsSelected = true;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void UpdateRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            byte roleId = Convert.ToByte(RoleIdTextBox.Text);
            RoleUpdateDto role = new RoleUpdateDto { Name = UpdateNameTextBox.Text };

            HttpResponseMessage response = APIHelper.ApiClient.PutAsJsonAsync("api/roles/" + roleId, role).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Role Updated!");
                UpdateNameTextBox.Text = null;
                RoleIdTextBox.Text = null;
                UpdateRoleTabItem.Visibility = Visibility.Hidden;
                RolesOverviewTabItem.IsSelected = true;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void GetRoles()
        {
            HttpResponseMessage response = APIHelper.ApiClient.GetAsync("api/roles").Result;

            if (response.IsSuccessStatusCode)
            {
                var roles = response.Content.ReadAsAsync<IEnumerable<RoleReadDto>>().Result;
                RolesListDataGrid.ItemsSource = roles;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
    }
}
