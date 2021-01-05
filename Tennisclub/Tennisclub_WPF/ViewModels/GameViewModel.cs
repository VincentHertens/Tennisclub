using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameDTO;
using Tennisclub_Common.MemberDTO;

namespace Tennisclub_WPF.ViewModels
{
    public class GameViewModel : GenericViewModel
    {
        private MemberReadDto _member;
        private GameReadDto _game;
        private string _gameNumber;
        private DateTime? _date;

        public MemberReadDto Member
        {
            get { return _member; }
            set { _member = value; OnPropertyChanged("Member"); }
        }

        public GameReadDto Game
        {
            get { return _game; }
            set { 
                _game = value; 
                OnPropertyChanged("Game");
                GameNumber = Game?.GameNumber;
                Date = Game?.Date;
            }
        }

        public string GameNumber
        {
            get { return _gameNumber; }
            set { _gameNumber = value; OnPropertyChanged("GameNumber"); }
        }

        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged("Date"); }
        }
    }
}
