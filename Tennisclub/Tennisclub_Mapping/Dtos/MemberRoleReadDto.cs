using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Mapping.Dtos
{
    public class MemberRoleReadDto
    {
        public int Id { get; set; }
        public MemberReadDto Member { get; set; }
        public RoleReadDto Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
