using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Common.MemberRoleDTO
{
    public class MemberRoleUpdateDto : IModelUpdateDto<int>
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
    }
}
