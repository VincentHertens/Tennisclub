using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public interface IMemberService
    {
        IEnumerable<MemberReadDto> GetAllActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city);
        IEnumerable<MemberReadDto> GetAllInActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city);
        MemberReadDto GetMemberById(int id);
        MemberReadDto AddMember(MemberCreateDto member);
        void UpdateMember(int id, MemberUpdateDto member);
        void SetMemberNotActive(int id);

        /*IEnumerable<Member> GetAllMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city);
        Member GetMemberById(int id);
        void AddMember(Member member);
        void UpdateMember(Member member);*/

        //TODO: member niet effectief verwijderen
        //void DeleteMember(Member member);
    }
}
