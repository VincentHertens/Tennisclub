using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameResultDTO;
using Tennisclub_Common.MemberDTO;

namespace Tennisclub_WPF.ViewModels
{
    public class GameResultViewModel : GenericViewModel
    {
        //Member
        private MemberReadDto _member;

        public MemberReadDto Member
        {
            get { return _member; }
            set { _member = value; OnPropertyChanged("Member"); }
        }

        //GameResult update
        private GameResultReadDto _gameResult;

        public GameResultReadDto GameResult
        {
            get { return _gameResult; }
            set 
            { 
                _gameResult = value; 
                OnPropertyChanged("GameResult");
                ScoreTeamMember = Convert.ToByte(GameResult?.ScoreTeamMember);
                ScoreOpponent = Convert.ToByte(GameResult?.ScoreOpponent);
            }
        }     

        private byte _scoreTeamMember;

        public byte ScoreTeamMember
        {
            get { return _scoreTeamMember; }
            set { _scoreTeamMember = value; OnPropertyChanged("ScoreTeamMember"); }
        }

        private byte _scoreOpponent;

        public byte ScoreOpponent
        {
            get { return _scoreOpponent; }
            set { _scoreOpponent = value; OnPropertyChanged("ScoreOpponent"); }
        }

        //GameResult add
        private byte _addSetNr;

        public byte AddSetNr
        {
            get { return _addSetNr; }
            set { _addSetNr = value; OnPropertyChanged("AddSetNr"); }
        }

        private byte _addScoreTeamMember;

        public byte AddScoreTeamMember
        {
            get { return _addScoreTeamMember; }
            set { _addScoreTeamMember = value; OnPropertyChanged("AddScoreTeamMember"); }
        }

        private byte _addScoreOpponent;

        public byte AddScoreOpponent
        {
            get { return _addScoreOpponent; }
            set { _addScoreOpponent = value; OnPropertyChanged("AddScoreOpponent"); }
        }
    }
}
