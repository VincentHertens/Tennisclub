using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public interface IMemberRoleService
    {
        //Haal lijst op van alle leden met bepaalde rol
        //IEnumerable<MemberRole>

        IEnumerable<MemberRoleReadDto> GetAllMembersByRoleIds(List<byte> roles); //Member
        IEnumerable<MemberRoleReadDto> GetAllRolesByMemberId(int id); // Role
        MemberRoleReadDto GetMemberRoleById(int id);
        MemberRoleReadDto AddMemberRole(MemberRoleCreateDto memberRole);
        void UpdateMemberRole(int id, MemberRoleUpdateDto memberRole);

        /*IEnumerable<Member> GetAllMembersByRoleIds(List<byte> roles); //MemberRole
        IEnumerable<Role> GetAllRolesByMemberId(int id); // MemberRole
        MemberRole GetMemberRoleById(int id);
        void AddMemberRole(MemberRole memberRole);
        void UpdateMemberRole(MemberRole memberRole);*/
    }
}
