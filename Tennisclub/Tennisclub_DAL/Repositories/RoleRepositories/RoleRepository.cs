using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tennisclub_Common.RoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.RoleRepositories
{
    public class RoleRepository : GenericRepository<Role, RoleReadDto, RoleCreateDto, RoleUpdateDto, byte>, IRoleRepository
    {
        public RoleRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }

        public IEnumerable<RoleReadDto> GetAllRolesSP()
        {
            var roles = _dbSet.FromSqlRaw("EXEC sp_getRoles").AsNoTracking().ToList();
            return _mapper.Map<IEnumerable<RoleReadDto>>(roles);
        }
    }
}
