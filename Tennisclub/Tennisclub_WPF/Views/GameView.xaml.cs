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
using Tennisclub_Common.GameDTO;
using Tennisclub_Common.LeagueDTO;
using Tennisclub_Common.MemberDTO;

namespace Tennisclub_WPF.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
            _ = LoadMembers();
            _ = LoadLeagues();
        }

        private async Task LoadMembers()
        {
            string path = $"members?federationNr={FilterFederationNrTextBox.Text}&firstName={FilterFirstnameTextBox.Text}" +
                $"&lastName={FilterLastnameTextBox.Text}&zipCode={FilterZipcodeTextBox.Text}&city={FilterCityTextBox.Text}";

            List<MemberReadDto> membersList = await WebAPI.Get<List<MemberReadDto>>(path);
            MembersDataGrid.ItemsSource = membersList;
        }

        private async Task LoadLeagues()
        {
            List<LeagueReadDto> leagueList = await WebAPI.Get<List<LeagueReadDto>>("leagues");
            ManagementLeagueComboBox.ItemsSource = leagueList;
        }
        private async Task LoadGames(string path)
        {
            List<GameReadDto> gamesList = await WebAPI.Get<List<GameReadDto>>(path);
            GamesDataGrid.ItemsSource = gamesList;
            ManagementLeagueComboBox.SelectedIndex = 0;
        }

        private async Task CreateGame()
        {
            //TODO: Validation
            LeagueReadDto league = ManagementLeagueComboBox.SelectedItem as LeagueReadDto;
            MemberReadDto member = MembersDataGrid.SelectedItem as MemberReadDto;
            GameCreateDto game = new GameCreateDto
            {
                GameNumber = ManagementGameNumberTextBox.Text,
                MemberId = member.Id,
                LeagueId = league.Id,
                Date = ManagementDateDatePicker.SelectedDate.Value
            };

            await WebAPI.Post<GameReadDto, GameCreateDto>($"games", game);

            await LoadGames($"games/bymember/{member.Id}?date={FilterDateDatePicker.SelectedDate:yyyy/MM/dd}");
        }       

        private async Task UpdateGame()
        {
            //TODO: Validation
            GameReadDto gameToUpdate = GamesDataGrid.SelectedItem as GameReadDto;
            LeagueReadDto league = ManagementLeagueComboBox.SelectedItem as LeagueReadDto;
            MemberReadDto member = MembersDataGrid.SelectedItem as MemberReadDto;
            GameUpdateDto game = new GameUpdateDto
            {
                Id = gameToUpdate.Id,
                GameNumber = ManagementGameNumberTextBox.Text,
                MemberId = member.Id,
                LeagueId = league.Id,
                Date = ManagementDateDatePicker.SelectedDate.Value
            };

            await WebAPI.Put<GameReadDto, GameUpdateDto>($"games", game);

            await LoadGames($"games/bymember/{member.Id}?date={FilterDateDatePicker.SelectedDate:yyyy/MM/dd}");
        }

        private async Task DeleteGame()
        {
            //TODO: Validation
            MemberReadDto member = MembersDataGrid.SelectedItem as MemberReadDto;
            GameReadDto gameToDelete = GamesDataGrid.SelectedItem as GameReadDto;

            await WebAPI.Delete($"games/delete/{gameToDelete.Id}");
            await LoadGames($"games/bymember/{member.Id}?date={FilterDateDatePicker.SelectedDate:yyyy/MM/dd}");
        }

        private void ViewGamesBtn_Click(object sender, RoutedEventArgs e)
        {
            MemberReadDto member = MembersDataGrid.SelectedItem as MemberReadDto;
            _ = LoadGames($"games/bymember/{member.Id}");

            Reset(false);
            //ViewGamesGrid.Visibility = Visibility.Collapsed;
            //MembersDataGrid.Visibility = Visibility.Collapsed;
            //MemberFilterGrid.Visibility = Visibility.Collapsed;

            //ManageGamesGrid.Visibility = Visibility.Visible;
            //GamesDataGrid.Visibility = Visibility.Visible;
            //GameFilterGrid.Visibility = Visibility.Visible;
            //FilterDateDatePicker.SelectedDate = null;
        }

        private void AddGameBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = CreateGame();
            
        }

        private void UpdateGameBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to update this game?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = UpdateGame();
            }
        }

        private void DeleteGameBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this game?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = DeleteGame();
            }
        }

        private void BackToMembersBtn_Click(object sender, RoutedEventArgs e)
        {
            Reset(true);
            //ViewGamesGrid.Visibility = Visibility.Visible;
            //MembersDataGrid.Visibility = Visibility.Visible;
            //MemberFilterGrid.Visibility = Visibility.Visible;

            //ManageGamesGrid.Visibility = Visibility.Collapsed;
            //GamesDataGrid.Visibility = Visibility.Collapsed;
            //GameFilterGrid.Visibility = Visibility.Collapsed;
            //FilterDateDatePicker.SelectedDate = null;
        }

        private void OnEnterHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _ = LoadMembers();
            }
        }

        private void NewGameBtn_Click(object sender, RoutedEventArgs e)
        {
            GamesDataGrid.SelectedItem = null;
            ManagementLeagueComboBox.SelectedIndex = 0;
        }

        private void FilterDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            MemberReadDto member = MembersDataGrid.SelectedItem as MemberReadDto;
           _ = LoadGames($"games/bymember/{member.Id}?date={FilterDateDatePicker.SelectedDate:yyyy/MM/dd}");
        }

        private void Reset(bool value)
        {
            ViewGamesGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            MembersDataGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            MemberFilterGrid.Visibility = value ? Visibility.Visible : Visibility.Collapsed;

            ManageGamesGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            GamesDataGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            GameFilterGrid.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            FilterDateDatePicker.SelectedDate = null;
            GamesDataGrid.SelectedItem = null;
            ManagementGameNumberTextBox.Text = null;
            ManagementDateDatePicker.SelectedDate = null;
            ManagementLeagueComboBox.SelectedIndex = 0;
        }
    }
}
