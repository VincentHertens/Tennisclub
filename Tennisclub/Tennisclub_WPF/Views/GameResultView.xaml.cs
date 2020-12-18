using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tennisclub_Common.GameDTO;
using Tennisclub_Common.GameResultDTO;
using Tennisclub_Common.MemberDTO;
using Tennisclub_WPF.Helpers;

namespace Tennisclub_WPF.Views
{
    /// <summary>
    /// Interaction logic for GameResultView.xaml
    /// </summary>
    public partial class GameResultView : UserControl
    {
        public GameResultView()
        {
            InitializeComponent();
        }

        private async Task LoadMembers()
        {
            string path = $"members?federationNr={FilterFederationNrTextBox.Text}&firstName={FilterFirstnameTextBox.Text}" +
                $"&lastName={FilterLastnameTextBox.Text}&zipCode={FilterZipcodeTextBox.Text}&city={FilterCityTextBox.Text}";

            List<MemberReadDto> membersList = await WebAPI.Get<List<MemberReadDto>>(path);
            MembersDataGrid.ItemsSource = membersList;
        }

        private async Task LoadGames()
        {
            List<GameReadDto> gamesList = await WebAPI.Get<List<GameReadDto>>($"games/bydate?date={FilterGameDateDatePicker.SelectedDate:yyyy/MM/dd}");
            GamesDataGrid.ItemsSource = gamesList;
        }

        private async Task LoadGameResults()
        {
            MemberReadDto member = MembersDataGrid.SelectedItem as MemberReadDto;
            List<GameResultReadDto> gameResultsList = await WebAPI.Get<List<GameResultReadDto>>($"gameresults/bymember/{member.Id}?date={FilterGameResultDateDatePicker.SelectedDate:yyyy/MM/dd}");
            GameResultsDataGrid.ItemsSource = gameResultsList;
        }

        private async Task AddGameResult()
        {           
            if (GamesDataGrid.SelectedItem is GameReadDto game)
            {
                GameResultCreateDto gameResult = new GameResultCreateDto
                {
                    GameId = game.Id,
                    ScoreOpponent = Convert.ToByte(AddGameResultOpponentsScoreTextBox.Text),
                    ScoreTeamMember = Convert.ToByte(AddGameResultTeamMemberScoreTextBox.Text),
                    SetNr = Convert.ToByte(AddGameResultSetNrTextBox.Text)
                };

                var result = await WebAPI.Post<GameResultReadDto, GameResultCreateDto>($"gameresults", gameResult);

                if (result != null)
                {
                    MessageBox.Show("Game result created successfully!");
                    ControlManager.LoopVisualTree(AddGameGrid, "0");
                }
            }
            else
            {
                MessageBox.Show("Please select a game");
            }
        }

        private async Task UpdateGameResult()
        {
            if (GameResultsDataGrid.SelectedItem is GameResultReadDto gameResult)
            {
                GameResultUpdateDto gameResultToUpdate = new GameResultUpdateDto
                {
                    Id = gameResult.Id,
                    ScoreOpponent = Convert.ToByte(ManagementGameResultOpponentsScoreTextBox.Text),
                    ScoreTeamMember = Convert.ToByte(ManagementGameResultTeamMemberScoreTextBox.Text),
                };

                var result = await WebAPI.Put<GameResultReadDto, GameResultUpdateDto>($"gameresults", gameResultToUpdate);

                if (result != null)
                {
                    await LoadGameResults();
                }
            }
            else
            {
                MessageBox.Show("Please select a game result");
            }
        }

        private void ViewGameResultsBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = LoadGameResults();
            Reset(false);
        }

        private void BackToMembersBtn_Click(object sender, RoutedEventArgs e)
        {
            Reset(true);
        }

        private void UpdateGameResultBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to update this game result?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = UpdateGameResult();
            }
        }

        private void OnEnterHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = LoadMembers();
            }
        }

        private void FilterGameResultDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _ = LoadGameResults();
        }

        private void FilterGameDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _ = LoadGames();
        }

        private void AddGameResultBtn_Click(object sender, RoutedEventArgs e)
        {
             _ = AddGameResult();                          
        }

        private void GameResultListTabItem_Loaded(object sender, RoutedEventArgs e)
        {
            _ = LoadMembers();
        }

        private void AddGameResultTabItem_Loaded(object sender, RoutedEventArgs e)
        {
            _ = LoadGames();
        }

        private void Reset(bool value)
        {
            GameResultsDataGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            ManageGameResultsGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            GameResultFilterGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;

            MembersDataGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            ViewGameResultsGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            MemberFilterGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            FilterGameResultDateDatePicker.SelectedDate = null;
            GameResultsDataGrid.SelectedItem = null;
            ManagementGameResultOpponentsScoreTextBox.Text = "0";
            ManagementGameResultTeamMemberScoreTextBox.Text = "0";
        }
    }
}
