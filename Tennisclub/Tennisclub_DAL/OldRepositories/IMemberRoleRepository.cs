using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.OldRepositories
{
    public interface IMemberRoleRepository : IBaseRepository<MemberRole>
    {
        IEnumerable<MemberRole> GetAllMembersByRoleIds(List<byte> roles); // Member
        IEnumerable<MemberRole> GetAllRolesByMemberId(int id); // Role
    }
}
