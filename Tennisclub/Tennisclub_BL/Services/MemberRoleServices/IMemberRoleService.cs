using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberRoleDTO;

namespace Tennisclub_BL.Services.MemberRoleServices
{
    public interface IMemberRoleService
    {
        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByRoles(List<byte> roles);
        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByMember(int id);
    }
}
