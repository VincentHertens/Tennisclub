using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Common.LeagueDTO
{
    public class LeagueReadDto : IModelReadDto<byte>
    {
        public byte Id { get; set; } //byte

        public string Name { get; set; }
    }
}
