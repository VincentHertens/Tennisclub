using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_Data_Layer.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public byte LeagueId { get; set; } //byte
        public League League { get; set; }
        public DateTime Date { get; set; }
    }
}
