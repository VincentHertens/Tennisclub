using System;
using System.Collections.Generic;
using System.Linq;
using Tennisclub_Common.MemberDTO;
using Tennisclub_DAL.Repositories.MemberRepositories;

namespace Tennisclub_BL.Services.MemberServices
{
    public class MemberService : IMemberService
    {
        private const int MAX_FEDERATIONNR = 10;
        private const int MAX_FIRSTNAME = 25;
        private const int MAX_LASTNAME = 35;
        private const int MAX_ADDRESS = 70;
        private const int MAX_NUMBER = 6;
        private const int MAX_ADDITION = 2;
        private const int MAX_ZIPCODE = 6;
        private const int MAX_CITY = 30;
        private const int MAX_PHONENR = 15;
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
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id cannot have a value less than 1");

            return _repository.GetById(id);
        }

        public MemberReadDto Add(MemberCreateDto memberCreateDto)
        {
            var list = _repository.GetAll(member => member.FederationNr == memberCreateDto.FederationNr);

            if (list.Count() != 0)
                throw new ArgumentException($"FederationNr must be unique");

            ValidateFields(memberCreateDto.FederationNr, memberCreateDto.FirstName, memberCreateDto.LastName, memberCreateDto.Address, memberCreateDto.Number, memberCreateDto.Addition, memberCreateDto.Zipcode, memberCreateDto.City, memberCreateDto.PhoneNr);

            return _repository.Add(memberCreateDto);
        }
        public MemberReadDto Update(MemberUpdateDto memberUpdateDto)
        {
            var list = _repository.GetAll(member => member.FederationNr == memberUpdateDto.FederationNr && member.Id != memberUpdateDto.Id);

            if (list.Count() != 0)
                throw new ArgumentException($"FederationNr must be unique");

            if (GetById(memberUpdateDto.Id) == null)
                throw new ArgumentException($"Member to update cannot be found");

            ValidateFields(memberUpdateDto.FederationNr, memberUpdateDto.FirstName, memberUpdateDto.LastName, memberUpdateDto.Address, memberUpdateDto.Number, memberUpdateDto.Addition, memberUpdateDto.Zipcode, memberUpdateDto.City, memberUpdateDto.PhoneNr);

            return _repository.Update(memberUpdateDto);
        }

        public void Delete(int id)
        {
            if (GetById(id) == null)
                throw new NullReferenceException($"No member with id {id} exists");

            _repository.Delete(id);
        }

        private void ValidateFields(string fedNr, string firstName, string lastName, string address, string number, string addition, string zipcode, string city, string phoneNr)
        {
            if (string.IsNullOrEmpty(fedNr) || fedNr.Length > MAX_FEDERATIONNR)
                throw new ArgumentException($"FederationNr cannot be empty or more than {MAX_FEDERATIONNR} characters");

            if (string.IsNullOrEmpty(firstName) || firstName.Length > MAX_FIRSTNAME)
                throw new ArgumentException($"First name cannot be empty or more than {MAX_FIRSTNAME} characters");

            if (string.IsNullOrEmpty(lastName) || lastName.Length > MAX_LASTNAME)
                throw new ArgumentException($"Last name cannot be empty or more than {MAX_LASTNAME} characters");

            if (string.IsNullOrEmpty(address) || address.Length > MAX_ADDRESS)
                throw new ArgumentException($"Address cannot be empty or more than {MAX_ADDRESS} characters");

            if (string.IsNullOrEmpty(number) || number.Length > MAX_NUMBER)
                throw new ArgumentException($"Number cannot be empty or more than {MAX_NUMBER} characters");

            if (string.IsNullOrEmpty(zipcode) || zipcode.Length > MAX_ZIPCODE)
                throw new ArgumentException($"Zipcode cannot be empty or more than {MAX_ZIPCODE} characters");

            if (string.IsNullOrEmpty(city) || city.Length > MAX_CITY)
                throw new ArgumentException($"City cannot be empty or more than {MAX_CITY} characters");

            if (phoneNr?.Length > MAX_PHONENR)
                throw new ArgumentException($"PhoneNr cannot be more than {MAX_PHONENR} characters");

            if (addition?.Length > MAX_ADDITION)
                throw new ArgumentException($"Addition cannot be more than {MAX_ADDITION} characters");
        }
    }
}
