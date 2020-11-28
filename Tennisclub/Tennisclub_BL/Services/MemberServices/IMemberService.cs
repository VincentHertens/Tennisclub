using System.Collections.Generic;
using Tennisclub_Common.MemberDTO;

namespace Tennisclub_BL.Services.MemberServices
{
    public interface IMemberService
    {
        public IEnumerable<MemberReadDto> GetAllActiveMembers(string federationNr, string firstName, string lastName, string zipCode, string city);
        public MemberReadDto GetById(int id);
        public MemberReadDto Add(MemberCreateDto memberCreateDto);
        public MemberReadDto Update(MemberUpdateDto memberUpdateDto);
        public void Delete(int id);
    }
}
