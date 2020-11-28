using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
