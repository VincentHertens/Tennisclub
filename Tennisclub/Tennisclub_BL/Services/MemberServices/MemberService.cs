using System.Collections.Generic;
using System.Linq;
using Tennisclub_Common.MemberDTO;
using Tennisclub_DAL.Repositories.MemberRepositories;

namespace Tennisclub_BL.Services.MemberServices
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;

        public MemberService(IMemberRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MemberReadDto> GetAllActiveMembers(string federationNr, string firstName, string lastName, string zipCode, string city)
        {
            return _repository.GetAll(filter: member => member.Active == true
            && (member.FederationNr == federationNr || federationNr == null)
            && (firstName == null || member.FirstName.Contains(firstName))
            && (lastName == null || member.LastName.Contains(lastName))
            && (member.Zipcode == zipCode || zipCode == null)
            && (member.City == city || city == null), 
            includeProperties: x => x.Gender);
        }

        public MemberReadDto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public MemberReadDto Add(MemberCreateDto memberCreateDto)
        {           
            return _repository.Add(memberCreateDto);
        }
        public MemberReadDto Update(MemberUpdateDto memberUpdateDto)
        {
            return _repository.Update(memberUpdateDto);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
