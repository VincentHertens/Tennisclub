using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_Data_Layer.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public byte SetNr { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }
    }
}
