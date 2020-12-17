using System;

namespace Tennisclub_Common.GameResultDTO
{
    public class GameResultUpdateDto : IModelUpdateDto<int>
    {
        public int Id { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }
    }
}
