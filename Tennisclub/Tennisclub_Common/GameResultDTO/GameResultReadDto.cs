using System;
using Tennisclub_Common.GameDTO;

namespace Tennisclub_Common.GameResultDTO
{
    public class GameResultReadDto : IModelReadDto<int>
    {
        public int Id { get; set; }
        public GameReadDto Game { get; set; }
        public byte SetNr { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }
    }
}
