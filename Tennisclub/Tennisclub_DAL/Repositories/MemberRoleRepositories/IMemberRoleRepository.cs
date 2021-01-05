using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.MemberRoleRepositories
{
    public interface IMemberRoleRepository : IGenericRepository<MemberRole, MemberRoleReadDto, MemberRoleCreateDto, MemberRoleUpdateDto, int>
    {
        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByMemberInlineQuery(int id);

        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByRoles(List<byte> roles);
    }
}
