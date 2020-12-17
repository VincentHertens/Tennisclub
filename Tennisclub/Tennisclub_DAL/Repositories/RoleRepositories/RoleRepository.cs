using AutoMapper;
using Tennisclub_Common.RoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.RoleRepositories
{
    public class RoleRepository : GenericRepository<Role, RoleReadDto, RoleCreateDto, RoleUpdateDto, byte>, IRoleRepository
    {
        public RoleRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
