using System.Collections.Generic;
using Tennisclub_Common.MemberDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.MemberRepositories
{
    public interface IMemberRepository : IGenericRepository<Member, MemberReadDto, MemberCreateDto, MemberUpdateDto, int>
    {
        public IEnumerable<MemberReadDto> GetAllActiveMembers(string federationNr, string firstName, string lastName, string zipCode, string city);
    }
}
