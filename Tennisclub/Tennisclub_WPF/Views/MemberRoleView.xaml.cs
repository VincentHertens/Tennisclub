using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tennisclub_Common.MemberDTO;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_Common.RoleDTO;
using Tennisclub_WPF.Helpers;

namespace Tennisclub_WPF.Views
{
    public partial class MemberRoleView : UserControl
    {
        public MemberRoleView()
        {
            InitializeComponent();
        }

        private async Task LoadMemberRoles(string path, DataGrid dataGrid)
        {
            List<MemberRoleReadDto> memberRolesList = await WebAPI.Get<List<MemberRoleReadDto>>(path);
            dataGrid.ItemsSource = memberRolesList;
        }

        private async Task LoadMembers(DataGrid dataGrid, TextBox federationTextBox, TextBox firstNameTextBox, TextBox lastNameTextBox, TextBox zipCodeTextBox, TextBox cityTextBox)
        {
            string path = $"members?federationNr={federationTextBox.Text}&firstName={firstNameTextBox.Text}" +
                $"&lastName={lastNameTextBox.Text}&zipCode={zipCodeTextBox.Text}&city={cityTextBox.Text}";

            List<MemberReadDto> membersList = await WebAPI.Get<List<MemberReadDto>>(path);
            dataGrid.ItemsSource = membersList;
        }

        private async Task LoadRoles(ItemsControl obj)
        {
            List<RoleReadDto> rolesList = await WebAPI.Get<List<RoleReadDto>>($"roles");
            obj.ItemsSource = rolesList;
        }   
        
        private async Task AddMemberRole()
        {
            if (AddMembersDataGrid.SelectedItem is MemberReadDto member)
            {
                RoleReadDto role = AddRoleComboBox.SelectedItem as RoleReadDto;
                MemberRoleCreateDto memberRole = new MemberRoleCreateDto
                {
                    MemberId = member.Id,
                    RoleId = role.Id,
                    StartDate = AddStartDateDatePicker.SelectedDate.Value
                };

                var result = await WebAPI.Post<MemberRoleReadDto, MemberRoleCreateDto>($"memberroles", memberRole);

                if (result != null)
                {
                    MessageBox.Show("Member role created successfully!");
                    ControlManager.LoopVisualTree(AddMemberRoleGrid, null);
                }
            }
            else
            {
                MessageBox.Show("Please select a member");
            }        
        }

        private async Task UpdateMemberRole(DataGrid dataGrid, DatePicker datePicker)
        {
            if (dataGrid.SelectedItem is MemberRoleReadDto memberRole)
            {
                MemberRoleUpdateDto memberRoleToUpdate = new MemberRoleUpdateDto
                {
                    Id = memberRole.Id,
                    EndDate = datePicker.SelectedDate.Value
                };

                var result = await WebAPI.Put<MemberRoleReadDto, MemberRoleUpdateDto>($"memberroles", memberRoleToUpdate);

                if (result != null)
                {
                    ControlManager.LoopVisualTree(ManageMembersListGrid, null);
                }
            }
            else
            {
                MessageBox.Show("Please select a member role");
            }
        }       

        private void AddMemberRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = AddMemberRole();            
        }

        private void ViewMemberRolesBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = GetMemberListMemberRoles();
            ResetMemberList(false);
        }

        private void ViewMemberRolesBtn2_Click(object sender, RoutedEventArgs e)
        {
            MemberReadDto member = MembersDataGrid.SelectedItem as MemberReadDto;
            _ = LoadMemberRoles($"memberroles/bymember/{member.Id}", RolesListDataGrid);
            ResetRoleList(false);
        }

        private void BackToRolesBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetMemberList(true);
        }

        private void BackToMembersBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetRoleList(true);
        }        

        private void UpdateMemberListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to update this member role?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = UpdateMemberList();               
            }
        }

        private void UpdateRoleListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to update this member role?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = UpdateRoleList();
            }
        }

        private async Task GetMemberListMemberRoles()
        {
            List<byte> rolesList = new List<byte>();
            foreach (RoleReadDto role in RolesDataGrid.SelectedItems)
            {
                rolesList.Add(role.Id);
            }

            StringBuilder path = new StringBuilder("memberroles/byroles?");
            rolesList.ForEach(x => path.Append("roles=" + x + "&"));

            await LoadMemberRoles(path.ToString(), MemberListDataGrid);
        }

        private async Task UpdateMemberList()
        {
            await UpdateMemberRole(MemberListDataGrid, UpdateEndDateMemberDatePicker);
            await GetMemberListMemberRoles();
        }

        private async Task UpdateRoleList()
        {
            MemberReadDto member = MembersDataGrid.SelectedItem as MemberReadDto;
            await UpdateMemberRole(RolesListDataGrid, UpdateEndDateRoleDatePicker);
            await LoadMemberRoles($"memberroles/bymember/{member.Id}", RolesListDataGrid);
        }      

        private void AddOnEnterHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = LoadMembers(AddMembersDataGrid, AddFilterFederationNrTextBox, AddFilterFirstnameTextBox, AddFilterLastnameTextBox, AddFilterZipcodeTextBox, AddFilterCityTextBox);
            }
        }

        private void OnEnterHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = LoadMembers(MembersDataGrid, FilterFederationNrTextBox, FilterFirstnameTextBox, FilterLastnameTextBox, FilterZipcodeTextBox, FilterCityTextBox);
            }
        }

        private void ResetMemberList(bool value)
        {
            MemberListDataGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            ManageMembersListGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;

            RolesDataGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            ViewMembersListGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            UpdateEndDateMemberDatePicker.SelectedDate = null;
            MemberListDataGrid.SelectedItem = null;
        }

        private void ResetRoleList(bool value)
        {
            RolesListDataGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            ManageRoleListGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;

            FilterMembersGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            MembersDataGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            ViewRoleListGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;

            UpdateEndDateRoleDatePicker.SelectedDate = null;
            RolesListDataGrid.SelectedItem = null;
        }

        private void TabItem_Loaded_1(object sender, RoutedEventArgs e)
        {
            _ = LoadRoles(RolesDataGrid);
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            _ = LoadMembers(AddMembersDataGrid, AddFilterFederationNrTextBox, AddFilterFirstnameTextBox, AddFilterLastnameTextBox, AddFilterZipcodeTextBox, AddFilterCityTextBox);
            _ = LoadRoles(AddRoleComboBox);
        }

        private void TabItem_Loaded_2(object sender, RoutedEventArgs e)
        {
            _ = LoadMembers(MembersDataGrid, FilterFederationNrTextBox, FilterFirstnameTextBox, FilterLastnameTextBox, FilterZipcodeTextBox, FilterCityTextBox);
        }
    }
}
