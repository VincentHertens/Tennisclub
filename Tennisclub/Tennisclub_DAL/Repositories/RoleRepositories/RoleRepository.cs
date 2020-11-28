using AutoMapper;
using Tennisclub_Common.RoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.RoleRepositories
{
    public class RoleRepository : GenericRepository<Role, RoleReadDto, RoleCreateDto, RoleUpdateDto, byte>, IRoleRepository
    {
        public RoleRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }

        public override RoleReadDto Update(RoleUpdateDto updateDto)
        {
            var entry = _context.Entry(_mapper.Map<Role>(updateDto));
            entry.Property(x => x.Name).IsModified = true;
            SaveChanges();
            entry.Reload();
            return GetById(updateDto.Id);
        }
    }
}
