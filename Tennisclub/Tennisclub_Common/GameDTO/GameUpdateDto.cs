using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Common.GameDTO
{
    public class GameUpdateDto : IModelUpdateDto<int>
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public int MemberId { get; set; }
        public byte LeagueId { get; set; } //byte
        public DateTime Date { get; set; }
    }
}
