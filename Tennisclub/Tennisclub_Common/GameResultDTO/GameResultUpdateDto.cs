using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Common.GameResultDTO
{
    public class GameResultUpdateDto : IModelUpdateDto<int>
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public byte SetNr { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }
    }
}
