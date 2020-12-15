using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameDTO;
using Tennisclub_Common.MemberDTO;

namespace Tennisclub_WPF.ViewModels
{
    public class GameViewModel : GenericViewModel
    {
        //Member
        private MemberReadDto _member;

        public MemberReadDto Member
        {
            get { return _member; }
            set { _member = value; OnPropertyChanged("Member"); }
        }

        //Game
        private GameReadDto _game;

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

        private string _gameNumber;

        public string GameNumber
        {
            get { return _gameNumber; }
            set { _gameNumber = value; OnPropertyChanged("GameNumber"); }
        }

        private DateTime? _date;

        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged("Date"); }
        }
    }
}
