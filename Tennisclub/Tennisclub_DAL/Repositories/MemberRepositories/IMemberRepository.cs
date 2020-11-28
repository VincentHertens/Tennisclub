using Tennisclub_Common.MemberDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.MemberRepositories
{
    public interface IMemberRepository : IGenericRepository<Member, MemberReadDto, MemberCreateDto, MemberUpdateDto, int>
    {
    }
}
