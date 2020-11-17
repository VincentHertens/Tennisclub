using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Mapping.Dtos
{
    public class GameResultReadDto
    {
        public int Id { get; set; }
        public GameReadDto Game { get; set; }
        public byte SetNr { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }
    }
}
