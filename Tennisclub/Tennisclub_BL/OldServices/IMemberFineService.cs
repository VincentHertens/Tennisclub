using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberFineDTO;

namespace Tennisclub_BL.OldServices
{
    public interface IMemberFineService
    {
        IEnumerable<MemberFineReadDto> GetAllMemberFinesFiltered(DateTime? handoutDate, DateTime? paymentDate);
        IEnumerable<MemberFineReadDto> GetAllMemberFinesByMemberIdFiltered(int id, DateTime? handoutDate, DateTime? paymentDate);
        MemberFineReadDto GetMemberFineById(int id);
        MemberFineReadDto AddMemberFine(MemberFineCreateDto memberFine);
        void UpdateMemberFine(int id, MemberFineUpdateDto memberFine);

        /*IEnumerable<MemberFine> GetAllMemberFinesFiltered(DateTime? handoutDate, DateTime? paymentDate);
        IEnumerable<MemberFine> GetAllMemberFinesByMemberIdFiltered(int id, DateTime? handoutDate, DateTime? paymentDate);
        MemberFine GetMemberFineById(int id);
        void AddMemberFine(MemberFine memberFine);
        void UpdateMemberFine(MemberFine memberFine);*/
    }
}
