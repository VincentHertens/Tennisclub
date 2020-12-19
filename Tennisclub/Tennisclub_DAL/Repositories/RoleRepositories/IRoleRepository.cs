using System.Collections.Generic;
using Tennisclub_Common.RoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.RoleRepositories
{
    public interface IRoleRepository : IGenericRepository<Role, RoleReadDto, RoleCreateDto, RoleUpdateDto, byte>
    {
        public IEnumerable<RoleReadDto> GetAllRolesSP();
    }
}
