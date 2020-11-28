using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_BL.OldServices
{
    public class MemberService //: IMemberService
    {
        /*private readonly IUnitOfWork _unitOfWork;
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
        }*/      
    }
}
