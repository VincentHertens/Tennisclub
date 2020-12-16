using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Common.MemberRoleDTO
{
    public class MemberRoleCreateDto
    {
        public int MemberId { get; set; }
        public byte RoleId { get; set; } //byte
        public DateTime StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
    }
}
