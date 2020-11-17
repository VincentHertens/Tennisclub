using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Data;
using Tennisclub_Data_Layer.Models;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MemberReadDto> GetAllActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city)
        {
            return _mapper.Map<IEnumerable<MemberReadDto>>(_unitOfWork.Members.GetAllActiveMembersFiltered(federationNr, firstName, lastName, zipCode, city));
        }

        public IEnumerable<MemberReadDto> GetAllInActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city)
        {
            return _mapper.Map<IEnumerable<MemberReadDto>>(_unitOfWork.Members.GetAllInActiveMembersFiltered(federationNr, firstName, lastName, zipCode, city));
        }

        public MemberReadDto GetMemberById(int id)
        {
            return _mapper.Map<MemberReadDto>(_unitOfWork.Members.GetById(id));
        }

        public MemberReadDto AddMember(MemberCreateDto member)
        {           
            var memberToCreate = _mapper.Map<Member>(member);

            _unitOfWork.Members.Add(memberToCreate);
            _unitOfWork.Commit();

            var memberReadDto = _mapper.Map<MemberReadDto>(memberToCreate);
            return memberReadDto;
        }        

        public void UpdateMember(int id, MemberUpdateDto member)
        {
            var memberToUpdate = _unitOfWork.Members.GetById(id);
            var updatedMember = _mapper.Map(member, memberToUpdate);            

            _unitOfWork.Members.Update(updatedMember);
            _unitOfWork.Commit();
        }

        public void SetMemberNotActive(int id)
        {
            var notActiveMember = _unitOfWork.Members.GetById(id);
            notActiveMember.Active = false;

            _unitOfWork.Members.Update(notActiveMember);
            _unitOfWork.Commit();
        }

        /*//Get all filtered members
        public IEnumerable<Member> GetAllMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city)
        {            
            return _unitOfWork.Members.GetAllMembersFiltered(federationNr, firstName, lastName, zipCode, city);
        }

         //Get member by id
        public Member GetMemberById(int id)
        {
            return _unitOfWork.Members.GetById(id);
        }

        //Add member
        public void AddMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }
            _unitOfWork.Members.Add(member);
            _unitOfWork.Commit();
        }
       
        //Update member
        public void UpdateMember(Member member)
        {
            _unitOfWork.Members.Update(member);
            _unitOfWork.Commit();
        }*/

        //TODO: member niet effectief verwijderen
        /*public void DeleteMember(Member member)
        {
            _unitOfWork.Members.Delete(member);
            _unitOfWork.Commit();
        }*/
    }
}
