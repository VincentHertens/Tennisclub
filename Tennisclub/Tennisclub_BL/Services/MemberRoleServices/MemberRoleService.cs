using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_DAL.Repositories.MemberRoleRepositories;

namespace Tennisclub_BL.Services.MemberRoleServices
{
    public class MemberRoleService : IMemberRoleService
    {
        private readonly IMemberRoleRepository _repository;

        public MemberRoleService(IMemberRoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByMember(int id)
        {
            return _repository.GetAll(filter : memberRole => memberRole.MemberId == id,
                orderBy: null,
                includeProperties: x => x.Role);
        }

        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByRoles(List<byte> roles)
        {
            return _repository.GetAll(filter: memberRole => roles.Contains(memberRole.RoleId), 
                orderBy: null,
                x => x.Member, x => x.Role );           
        }
    }
}
