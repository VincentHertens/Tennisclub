using AutoMapper;
using Tennisclub_Common.GenderDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.GenderRepositories
{
    public class GenderRepository : GenericRepository<Gender, GenderReadDto, object, object, byte>, IGenderRepository
    {
        public GenderRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
