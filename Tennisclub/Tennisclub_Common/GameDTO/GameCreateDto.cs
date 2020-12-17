using System;

namespace Tennisclub_Common.GameDTO
{
    public class GameCreateDto
    {        
        public string GameNumber { get; set; }
        public int MemberId { get; set; }
        public byte LeagueId { get; set; }
        public DateTime Date { get; set; }
    }
}
