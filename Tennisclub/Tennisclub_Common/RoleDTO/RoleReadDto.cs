using System;

namespace Tennisclub_Common.RoleDTO
{
    public class RoleReadDto : IModelReadDto<byte>
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}
