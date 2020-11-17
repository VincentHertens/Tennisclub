using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public interface IMemberRoleRepository : IBaseRepository<MemberRole>
    {
        IEnumerable<MemberRole> GetAllMembersByRoleIds(List<byte> roles); // Member
        IEnumerable<MemberRole> GetAllRolesByMemberId(int id); // Role
    }
}
