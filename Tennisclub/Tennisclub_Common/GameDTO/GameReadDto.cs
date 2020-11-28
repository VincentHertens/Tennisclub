using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub_Common.LeagueDTO;
using Tennisclub_Common.MemberDTO;

namespace Tennisclub_Common.GameDTO
{
    public class GameReadDto : IModelReadDto<int>
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public MemberReadDto Member { get; set; }        
        public LeagueReadDto League { get; set; }
        public DateTime Date { get; set; }
    }
}
