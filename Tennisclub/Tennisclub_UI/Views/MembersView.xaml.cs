using Newtonsoft.Json;
using System;
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
using Tennisclub_Common.GenderDTO;
using Tennisclub_Common.MemberDTO;
using Tennisclub_UI.ViewModels;

namespace Tennisclub_UI.Views
{
    /// <summary>
    /// Interaction logic for MembersView.xaml
    /// </summary>
    public partial class MembersView : UserControl
    {
        public MembersView()
        {
            InitializeComponent();
        }

        private void MembersListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {         
            GetMembers("api/members", MembersListDataGrid, FilterFedNrTextBox, FilterFirstNameTextBox, FilterLastNameTextBox, FilterZipcodeTextBox, FilterCityTextBox);
        }

        private void InactiveMembersListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            GetMembers("api/members/inactive", InactiveMembersListDataGrid, FilterInactiveFedNrTextBox, FilterInactiveFirstNameTextBox, FilterInactiveLastNameTextBox, FilterInactiveZipcodeTextBox, FilterInactiveCityTextBox);
        }

        private void AddMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Input validation
            GenderReadDto gender = AddGenderComboBox.SelectedItem as GenderReadDto;
            MemberCreateDto member = new MemberCreateDto
            {
                FederationNr = AddFederationNrTextBox.Text,
                FirstName = AddFirstNameTextBox.Text,
                LastName = AddLastNameTextBox.Text,
                BirthDate = AddBirthDateDatePicker.SelectedDate.Value,
                GenderId = gender.Id,
                Number = AddNumberTextBox.Text,
                Address = AddAddressTextBox.Text,
                Addition = AddAdditionTextBox.Text,
                Zipcode = AddZipcodeTextBox.Text,
                City = AddCityTextBox.Text,
                PhoneNr = AddPhoneNrTextBox.Text
            };

            _ = WebAPI.Post<MemberReadDto, MemberCreateDto>("api/members/", member);
            //WebAPI.LoopVisualTree(AddVisualTree);
            MemberOverviewTabItem.IsSelected = true;
            /*if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Member Added!");
                WebAPI.LoopVisualTree(AddVisualTree);
                MemberOverviewTabItem.IsSelected = true;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }*/
        }

        private void UpdateMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            int memberId = Convert.ToInt32(MemberIdTextBox.Text);
            byte genderId = (byte)UpdateGenderComboBox.SelectedValue;
            //GenderReadDto gender = UpdateGenderComboBox.SelectedItem as GenderReadDto;

            MemberUpdateDto member = new MemberUpdateDto
            {
                FederationNr = UpdateFederationNrTextBox.Text,
                FirstName = UpdateFirstNameTextBox.Text,
                LastName = UpdateLastNameTextBox.Text,
                BirthDate = UpdateBirthDateDatePicker.SelectedDate.Value,
                GenderId = genderId,
                Number = UpdateNumberTextBox.Text,
                Address = UpdateAddressTextBox.Text,
                Addition = UpdateAdditionTextBox.Text,
                Zipcode = UpdateZipcodeTextBox.Text,
                City = UpdateCityTextBox.Text,
                PhoneNr = UpdatePhoneNrTextBox.Text
            };

            //HttpResponseMessage response = WebAPI.ApiClient.PutAsJsonAsync("api/members/" + memberId, member).Result;

            /*if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Member Updated!");

                WebAPI.LoopVisualTree(UpdateVisualTree);              
                UpdateMemberTabItem.Visibility = Visibility.Hidden;
                MemberOverviewTabItem.IsSelected = true;

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }*/

        }

        private void OverviewDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MembersListDataGrid.SelectedItem is MemberReadDto member)
            {
                /*HttpResponseMessage response = WebAPI.ApiClient.DeleteAsync("api/members/" + member.Id).Result;

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Member Deleted!");
                    GetMembers("api/members", MembersListDataGrid, FilterFedNrTextBox, FilterFirstNameTextBox, FilterLastNameTextBox, FilterZipcodeTextBox, FilterCityTextBox);
                }
                else
                {
                    MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                }*/
            }
            else
            {
                MessageBox.Show("Select a Member!");
            }
        }

        private void OverviewUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MembersListDataGrid.SelectedItem is MemberReadDto member)
            {
                UpdateMemberTabItem.IsSelected = true;
                UpdateMemberTabItem.Visibility = Visibility.Visible;

                GetGenders(UpdateGenderComboBox);
                MemberIdTextBox.Text = member.Id.ToString();
                UpdateFederationNrTextBox.Text = member.FederationNr;
                UpdateFirstNameTextBox.Text = member.FirstName;
                UpdateLastNameTextBox.Text = member.LastName;
                UpdateBirthDateDatePicker.SelectedDate = member.BirthDate;
                UpdateGenderComboBox.SelectedValue = member.Gender.Id;
                UpdateAddressTextBox.Text = member.Address;
                UpdateAdditionTextBox.Text = member.Addition;
                UpdateNumberTextBox.Text = member.Number;
                UpdateCityTextBox.Text = member.City;
                UpdatePhoneNrTextBox.Text = member.PhoneNr;
                UpdateZipcodeTextBox.Text = member.Zipcode;
            }
            else
            {
                MessageBox.Show("Select a Member!");
            }
        }

        private void OverviewSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            GetMembers("api/members", MembersListDataGrid, FilterFedNrTextBox, FilterFirstNameTextBox, FilterLastNameTextBox, FilterZipcodeTextBox, FilterCityTextBox);
        }

        private void ArchiveSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            GetMembers("api/members/inactive", InactiveMembersListDataGrid, FilterInactiveFedNrTextBox, FilterInactiveFirstNameTextBox, FilterInactiveLastNameTextBox, FilterInactiveZipcodeTextBox, FilterInactiveCityTextBox);
        }

        private void AddGenderComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            GetGenders(AddGenderComboBox);
        }

        private void GetMembers(string path, DataGrid dataGrid, TextBox fedTextBox, TextBox firstNameTextBox, TextBox lastNameTextBox, TextBox zipCodeTextBox, TextBox cityTextBox)
        {
           /* HttpResponseMessage response = WebAPI.ApiClient.GetAsync(path + "?federationnr=" + fedTextBox.Text
                + "&firstname=" + firstNameTextBox.Text
                + "&lastname=" + lastNameTextBox.Text
                + "&zipcode=" + zipCodeTextBox.Text
                + "&city=" + cityTextBox.Text).Result;

            if (response.IsSuccessStatusCode)
            {
                var members = response.Content.ReadAsAsync<IEnumerable<MemberReadDto>>().Result;
                dataGrid.ItemsSource = members;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }*/
        }

        private void GetGenders(ComboBox comboBox)
        {
           /* HttpResponseMessage response = WebAPI.ApiClient.GetAsync("api/genders").Result;
            if (response.IsSuccessStatusCode)
            {
                var genders = response.Content.ReadAsAsync<IEnumerable<GenderReadDto>>().Result;
                comboBox.ItemsSource = genders;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }*/
        }    
    }
}

