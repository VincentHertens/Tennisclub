using Tennisclub_Common.GenderDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.GenderRepositories
{
    public interface IGenderRepository : IGenericRepository<Gender, GenderReadDto, object, object, byte>
    {
    }
}
