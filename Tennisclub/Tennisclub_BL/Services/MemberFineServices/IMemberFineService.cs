using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberFineDTO;

namespace Tennisclub_BL.Services.MemberFineServices
{
    public interface IMemberFineService
    {
        public IEnumerable<MemberFineReadDto> GetAllMemberFinesByMember(int id, DateTime? handoutDate, DateTime? paymentDate);
        public MemberFineReadDto GetById(int id);
        public MemberFineReadDto Add(MemberFineCreateDto memberFineCreateDto);
        public MemberFineReadDto Update(MemberFineUpdateDto memberFineUpdateDto);
    }
}
