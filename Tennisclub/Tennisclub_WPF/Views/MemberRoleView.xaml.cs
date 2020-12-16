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
using Tennisclub_Common.MemberDTO;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_Common.RoleDTO;
using Tennisclub_WPF.Helpers;

namespace Tennisclub_WPF.Views
{
    /// <summary>
    /// Interaction logic for MemberRoleView.xaml
    /// </summary>
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

        private async Task LoadMembers(DataGrid dataGrid)
        {
            string path = $"members?federationNr={AddFilterFederationNrTextBox.Text}&firstName={AddFilterFirstnameTextBox.Text}" +
                $"&lastName={AddFilterLastnameTextBox.Text}&zipCode={AddFilterZipcodeTextBox.Text}&city={AddFilterCityTextBox.Text}";

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
            //TODO: Validation
            RoleReadDto role = AddRoleComboBox.SelectedItem as RoleReadDto;
            MemberReadDto member = AddMembersDataGrid.SelectedItem as MemberReadDto;
            MemberRoleCreateDto memberRole = new MemberRoleCreateDto
            {
                MemberId = member.Id,
                RoleId = role.Id,
                StartDate = AddStartDateDatePicker.SelectedDate.Value
            };

            await WebAPI.Post<MemberRoleReadDto, MemberRoleCreateDto>($"memberroles", memberRole);
        }

        private async Task UpdateMemberRole()
        {
            //TODO: Validation
            MemberRoleReadDto memberRole = MemberListDataGrid.SelectedItem as MemberRoleReadDto;           
            MemberRoleUpdateDto memberRoleToUpdate = new MemberRoleUpdateDto
            {
                Id = memberRole.Id,
                MemberId = memberRole.Member.Id,
                RoleId = memberRole.Role.Id,
                StartDate = memberRole.StartDate,
                EndDate = UpdateEndDateMemberDatePicker.SelectedDate.Value
            };

            await WebAPI.Put<MemberRoleReadDto, MemberRoleUpdateDto>($"memberroles", memberRoleToUpdate);           
        }

        private void AddMemberRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AddMembersDataGrid.SelectedItem is MemberReadDto)
            {
                _ = AddMemberRole();
                MessageBox.Show("Member role created successfully!");
                ControlManager.LoopVisualTree(AddMemberRoleGrid, null);
            }
            else
            {
                MessageBox.Show("Please select a member");
            }
        }

        private void OnEnterHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = LoadMembers(null);               
            }
        }     

        private void ViewMemberRolesBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = GetMemberListMemberRoles();
            ResetMemberList(false);
        }            

        private void BackToRolesBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetMemberList(true);
        }

        private void TabItem_Loaded_1(object sender, RoutedEventArgs e)
        {
            _ = LoadRoles(RolesDataGrid);
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            _ = LoadMembers(AddMembersDataGrid);
            _ = LoadRoles(AddRoleComboBox);
        }

        private void UpdateMemberListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to update this member role?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = UpdateMemberList();               
            }
        }

        private async Task UpdateMemberList()
        {
            await UpdateMemberRole();
            await GetMemberListMemberRoles();
            ControlManager.LoopVisualTree(ManageMembersListGrid, null);
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

        private void ResetMemberList(bool value)
        {
            MemberListDataGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            ManageMembersListGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;

            RolesDataGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            ViewMembersListGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            UpdateEndDateMemberDatePicker.SelectedDate = null;
            MemberListDataGrid.SelectedItem = null;
        }

        private void AddOnEnterHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = LoadMembers(AddMembersDataGrid);
            }
        }
    }
}
