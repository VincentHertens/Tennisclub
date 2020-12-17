﻿using System;

namespace Tennisclub_DAL.Models
{
    public class GameResult : IModel<int>
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public byte SetNr { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }
    }
}
