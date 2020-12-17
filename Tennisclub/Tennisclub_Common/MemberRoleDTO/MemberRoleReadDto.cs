using System;
using Tennisclub_Common.MemberDTO;
using Tennisclub_Common.RoleDTO;

namespace Tennisclub_Common.MemberRoleDTO
{
    public class MemberRoleReadDto : IModelReadDto<int>
    {
        public int Id { get; set; }
        public MemberReadDto Member { get; set; }
        public RoleReadDto Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int MemberId { get; set; }
        public byte RoleId { get; set; }
    }
}
