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

        //Update game result
        private GameResultReadDto _gameResult;
        private byte _scoreTeamMember;
        private byte _scoreOpponent;

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

        public byte ScoreTeamMember
        {
            get { return _scoreTeamMember; }
            set { _scoreTeamMember = value; OnPropertyChanged("ScoreTeamMember"); }
        }

        public byte ScoreOpponent
        {
            get { return _scoreOpponent; }
            set { _scoreOpponent = value; OnPropertyChanged("ScoreOpponent"); }
        }

        //Add game result
        private byte _addSetNr;
        private byte _addScoreTeamMember;
        private byte _addScoreOpponent;

        public byte AddSetNr
        {
            get { return _addSetNr; }
            set { _addSetNr = value; OnPropertyChanged("AddSetNr"); }
        }

        public byte AddScoreTeamMember
        {
            get { return _addScoreTeamMember; }
            set { _addScoreTeamMember = value; OnPropertyChanged("AddScoreTeamMember"); }
        }

        public byte AddScoreOpponent
        {
            get { return _addScoreOpponent; }
            set { _addScoreOpponent = value; OnPropertyChanged("AddScoreOpponent"); }
        }
    }
}
