using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Mapping.Dtos
{
    public class GameReadDto
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public MemberReadDto Member { get; set; }        
        public LeagueReadDto League { get; set; }
        public DateTime Date { get; set; }
    }
}
