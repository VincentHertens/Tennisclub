using System;

namespace Tennisclub_Common.MemberRoleDTO
{
    public class MemberRoleUpdateDto : IModelUpdateDto<int>
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
    }
}
