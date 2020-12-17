using System;

namespace Tennisclub_Common.RoleDTO
{
    public class RoleUpdateDto : IModelUpdateDto<byte>
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}
