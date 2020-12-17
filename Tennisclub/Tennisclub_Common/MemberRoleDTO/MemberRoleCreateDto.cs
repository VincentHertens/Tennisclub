using System;

namespace Tennisclub_Common.MemberRoleDTO
{
    public class MemberRoleCreateDto
    {
        public int MemberId { get; set; }
        public byte RoleId { get; set; } 
        public DateTime StartDate { get; set; }
    }
}
