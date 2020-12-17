using System;

namespace Tennisclub_Common.GenderDTO
{
    public class GenderReadDto : IModelReadDto<byte>
    {
        public byte Id { get; set; } 
        public string Name { get; set; }
    }
}
