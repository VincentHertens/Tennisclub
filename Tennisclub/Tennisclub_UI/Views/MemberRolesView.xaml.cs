using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

namespace Tennisclub_UI.Views
{
    /// <summary>
    /// Interaction logic for MemberRolesView.xaml
    /// </summary>
    public partial class MemberRolesView : UserControl
    {
        public MemberRolesView()
        {
            InitializeComponent();
        }

        private void SpecificRolesListBox_Loaded(object sender, RoutedEventArgs e)
        {
            GetRoles(SpecificRolesListBox);
        }

        private void AddRoleComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            GetRoles(AddRoleComboBox);
        }

        private void SpecificRolesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<byte> rolesList = new List<byte>();
            foreach (RoleReadDto role in SpecificRolesListBox.SelectedItems)
            {
                rolesList.Add(role.Id);
            }

            StringBuilder path = new StringBuilder("/members?");
            rolesList.ForEach(x => path.Append("roles=" + x + "&"));

            GetMemberRoles(path.ToString(), SpecificRolesListDataGrid);
        }

        private void SpecificMemberSearchButton_Click(object sender, RoutedEventArgs e)
        {
            string path = "/member/" + SpecificMemberIdTextBox.Text;
            GetMemberRoles(path, SpecificMemberListDataGrid);
        }

        private void GetMemberRoles(string path, DataGrid dataGrid)
        {
            /*HttpResponseMessage response = WebAPI.ApiClient.GetAsync("api/memberroles" + path).Result;

            if (response.IsSuccessStatusCode)
            {
                var memberRoles = response.Content.ReadAsAsync<IEnumerable<MemberRoleReadDto>>().Result;
                dataGrid.ItemsSource = memberRoles;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }*/
        }

        private void GetRoles(ItemsControl box)
        {
            /*HttpResponseMessage response = WebAPI.ApiClient.GetAsync("api/roles").Result;

            if (response.IsSuccessStatusCode)
            {
                var roles = response.Content.ReadAsAsync<IEnumerable<RoleReadDto>>().Result;
                box.ItemsSource = roles;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }*/
        }

        private void AddMemberRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            /* RoleReadDto role = AddRoleComboBox.SelectedItem as RoleReadDto;            
             MemberRoleCreateDto memberRole = new MemberRoleCreateDto
             {
                 MemberId = Convert.ToInt32(AddMemberIdTextBox.Text),
                 RoleId = role.Id,
                 StartDate = AddStartDateDatePicker.SelectedDate.Value,
                 EndDate = AddEndDateDatePicker.SelectedDate
             };

             HttpResponseMessage response = WebAPI.ApiClient.PostAsJsonAsync("api/memberroles/", memberRole).Result;

             if (response.IsSuccessStatusCode)
             {
                 MessageBox.Show("Member Role Added!");
                 WebAPI.LoopVisualTree(AddVisualTree);
                 SpecificRolesTabItem.IsSelected = true;
             }
             else
             {
                 MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
             }*/
        }

        private void SpecificRolesUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateButton(SpecificRolesListDataGrid);
        }

        private void SpecificMemberUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateButton(SpecificMemberListDataGrid);
        }

        private void UpdateButton(DataGrid dataGrid)
        {
            /*if (dataGrid.SelectedItem is MemberRoleReadDto memberRole)
            {
                if (memberRole.EndDate != null)
                {

                    MemberRoleUpdateDto updatedMemberRole = new MemberRoleUpdateDto
                    {
                        EndDate = memberRole.EndDate.Value
                    };

                    HttpResponseMessage response = WebAPI.ApiClient.PutAsJsonAsync("api/memberroles/" + memberRole.Id, updatedMemberRole).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Member Role Updated!");
                    }
                    else
                    {
                        MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                    }
                }
                else
                {
                    MessageBox.Show("End Date is required!");
                }
            }
            else
            {
                MessageBox.Show("Select a Member Role!");
            }            
        }        */
        }
    }
}
