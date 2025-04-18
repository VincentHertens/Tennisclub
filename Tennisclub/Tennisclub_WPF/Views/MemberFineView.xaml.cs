﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tennisclub_Common.MemberDTO;
using Tennisclub_Common.MemberFineDTO;
using Tennisclub_WPF.Helpers;

namespace Tennisclub_WPF.Views
{
    public partial class MemberFineView : UserControl
    {
        public MemberFineView()
        {
            InitializeComponent();
        }

        private async Task LoadMembers(DataGrid dataGrid, TextBox federationTextBox, TextBox firstNameTextBox, TextBox lastNameTextBox, TextBox zipCodeTextBox, TextBox cityTextBox)
        {
            string path = $"members?federationNr={federationTextBox.Text}&firstName={firstNameTextBox.Text}" +
               $"&lastName={lastNameTextBox.Text}&zipCode={zipCodeTextBox.Text}&city={cityTextBox.Text}";

            List<MemberReadDto> membersList = await WebAPI.Get<List<MemberReadDto>>(path);
            dataGrid.ItemsSource = membersList;
        }

        private async Task LoadMemberFines()
        {
            if (MembersDataGrid.SelectedItem is MemberReadDto member)
            {
                List<MemberFineReadDto> memberFinesList = await WebAPI.Get<List<MemberFineReadDto>>($"memberfines/bymember/{member.Id}?handoutDate={FilterHandoutDateDatePicker.SelectedDate:yyyy/MM/dd}&paymentDate={FilterPaymentDateDatePicker.SelectedDate:yyyy/MM/dd}");
                MemberFinesDataGrid.ItemsSource = memberFinesList;
            }          
        }

        private async Task AddMemberFine()
        {
            if (AddDataGrid.SelectedItem is MemberReadDto member)
            {
                MemberFineCreateDto memberFine = new MemberFineCreateDto
                {
                    FineNumber = Convert.ToInt32(AddFineNumberTextBox.Text),
                    Amount = Convert.ToDecimal(AddAmountTextBox.Text),
                    HandoutDate = AddHandoutDateDatePicker.SelectedDate.Value,
                    MemberId = member.Id
                };

                var result = await WebAPI.Post<MemberFineReadDto, MemberFineCreateDto>($"memberfines", memberFine);

                if (result != null)
                {
                    MessageBox.Show("Fine created successfully!");
                    ControlManager.LoopVisualTree(AddFineGrid, null);
                    AddFineNumberTextBox.Text = "0";
                    AddDataGrid.SelectedItem = null;
                }
            }
            else
            {
                MessageBox.Show("Please select a member");
            }
        }

        private async Task UpdateMemberFine()
        {
            if (MemberFinesDataGrid.SelectedItem is MemberFineReadDto memberFine)
            {
                MemberFineUpdateDto memberFineToUpdate = new MemberFineUpdateDto
                {
                    Id = memberFine.Id,
                    PaymentDate = UpdatePaymentDateDatePicker.SelectedDate.Value
                };

                var result = await WebAPI.Put<MemberFineReadDto, MemberFineUpdateDto>($"memberfines", memberFineToUpdate);

                if (result != null)
                {
                    await LoadMemberFines();
                    ControlManager.LoopVisualTree(ManageMemberFinesGrid, null);
                }
            }
            else
            {
                MessageBox.Show("Please select a fine");
            }
        }

        private void AddFineBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = AddMemberFine();            
        }

        private void ViewMemberFinesBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = LoadMemberFines();
            Reset(false);
        }

        private void UpdateMemberFineBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to update this fine?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = UpdateMemberFine();
            }
        }

        private void BackToMembersBtn_Click(object sender, RoutedEventArgs e)
        {
            Reset(true);
        }

        private void Reset(bool value)
        {
            FineFilterGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            MemberFinesDataGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            ManageMemberFinesGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;

            ListFilterGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            MembersDataGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            ViewMemberFinesGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            FilterHandoutDateDatePicker.SelectedDate = null;
            FilterPaymentDateDatePicker.SelectedDate = null;
            UpdatePaymentDateDatePicker.SelectedDate = null;
            MemberFinesDataGrid.SelectedItem = null;
        }

        private void AddOnEnterHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = LoadMembers(AddDataGrid, AddFilterFederationNrTextBox, AddFilterFirstnameTextBox, AddFilterLastnameTextBox, AddFilterZipcodeTextBox, AddFilterCityTextBox);
            }
        }

        private void OnEnterHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = LoadMembers(MembersDataGrid, FilterFederationNrTextBox, FilterFirstnameTextBox, FilterLastnameTextBox, FilterZipcodeTextBox, FilterCityTextBox);
            }
        }

        private void AddFineTabItem_Loaded(object sender, RoutedEventArgs e)
        {
            _ = LoadMembers(AddDataGrid, AddFilterFederationNrTextBox, AddFilterFirstnameTextBox, AddFilterLastnameTextBox, AddFilterZipcodeTextBox, AddFilterCityTextBox);
        }

        private void ListFineTabItem_Loaded(object sender, RoutedEventArgs e)
        {
            _ = LoadMembers(MembersDataGrid, FilterFederationNrTextBox, FilterFirstnameTextBox, FilterLastnameTextBox, FilterZipcodeTextBox, FilterCityTextBox);
        }

        private void FilterPaymentDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _ = LoadMemberFines();
        }

        private void FilterHandoutDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _ = LoadMemberFines();
        }
    }
}
