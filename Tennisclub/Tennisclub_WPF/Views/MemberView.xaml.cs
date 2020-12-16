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
using Tennisclub_Common.GenderDTO;
using Tennisclub_Common.MemberDTO;
using Tennisclub_WPF.Helpers;

namespace Tennisclub_WPF.Views
{
    public partial class MemberView : UserControl
    {
        public MemberView()
        {
            InitializeComponent();
            _ = LoadMembers();
            _ = LoadGenders();
        }

        private async Task LoadMembers()
        {
            string path = $"members?federationNr={FilterFederationNrTextBox.Text}&firstName={FilterFirstnameTextBox.Text}" +
                $"&lastName={FilterLastnameTextBox.Text}&zipCode={FilterZipcodeTextBox.Text}&city={FilterCityTextBox.Text}";

            List<MemberReadDto> membersList = await WebAPI.Get<List<MemberReadDto>>(path);
            MembersDataGrid.ItemsSource = membersList;
            ManagementGenderComboBox.SelectedIndex = 0;
        }

        private async Task LoadGenders()
        {
            List<GenderReadDto> gendersList = await WebAPI.Get<List<GenderReadDto>>("genders");
            ManagementGenderComboBox.ItemsSource = gendersList;
        }

        private async Task AddMember()
        {
            //TODO: Validation
            GenderReadDto gender = ManagementGenderComboBox.SelectedItem as GenderReadDto;
            MemberCreateDto member = new MemberCreateDto
            {
                FederationNr = ManagementFederationNrTextBox.Text,
                FirstName = ManagementFirstNameTextBox.Text,
                LastName = ManagementLastNameTextBox.Text,
                BirthDate = ManagementBirthDateDatePicker.SelectedDate.Value,
                GenderId = gender.Id,
                Number = ManagementNumberTextBox.Text,
                Address = ManagementAddressTextBox.Text,
                Addition = ManagementAdditionTextBox.Text,
                Zipcode = ManagementZipCodeTextBox.Text,
                City = ManagementCityTextBox.Text,
                PhoneNr = ManagementPhoneNrTextBox.Text
            };

            await WebAPI.Post<MemberReadDto, MemberCreateDto>($"members", member);
            _ = LoadMembers();
        }

        private async Task UpdateMember()
        {
            //TODO: Validation
            MemberReadDto memberToUpdate = MembersDataGrid.SelectedItem as MemberReadDto;
            GenderReadDto gender = ManagementGenderComboBox.SelectedItem as GenderReadDto;
            MemberUpdateDto member = new MemberUpdateDto
            {
                Id = memberToUpdate.Id,
                FederationNr = ManagementFederationNrTextBox.Text,
                FirstName = ManagementFirstNameTextBox.Text,
                LastName = ManagementLastNameTextBox.Text,
                BirthDate = ManagementBirthDateDatePicker.SelectedDate.Value,
                GenderId = gender.Id,
                Number = ManagementNumberTextBox.Text,
                Address = ManagementAddressTextBox.Text,
                Addition = ManagementAdditionTextBox.Text,
                Zipcode = ManagementZipCodeTextBox.Text,
                City = ManagementCityTextBox.Text,
                PhoneNr = ManagementPhoneNrTextBox.Text
            };

            await WebAPI.Put<MemberReadDto, MemberUpdateDto>($"members", member);
            _ = LoadMembers();
        }

        private async Task DeleteMember()
        {
            //TODO: Validation
            MemberReadDto memberToDelete = MembersDataGrid.SelectedItem as MemberReadDto;

            await WebAPI.Delete($"members/delete/{memberToDelete.Id}");
            _ = LoadMembers();
        }

        private void OnEnterHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = LoadMembers();
            }
        }

        private void NewMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            MembersDataGrid.SelectedItem = null;
            ManagementGenderComboBox.SelectedIndex = 0;
        }

        private void DeleteMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this member?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = DeleteMember();
            }
        }

        private void UpdateMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to update this member?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = UpdateMember();
            }
        }

        private void AddMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = AddMember();
            ControlManager.LoopVisualTree(AddMemberGrid, null);
        }
    }
}
