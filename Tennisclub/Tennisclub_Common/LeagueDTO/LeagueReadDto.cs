using System;

namespace Tennisclub_Common.LeagueDTO
{
    public class LeagueReadDto : IModelReadDto<byte>
    {
        public byte Id { get; set; }

        public string Name { get; set; }
    }
}
