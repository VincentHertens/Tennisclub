using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Common.GenderDTO
{
    public class GenderReadDto : IModelReadDto<byte>
    {
        public byte Id { get; set; } //byte
        public string Name { get; set; }
    }
}
