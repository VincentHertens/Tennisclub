using System;

namespace Tennisclub_Common.MemberFineDTO
{
    public class MemberFineCreateDto
    {
        public int FineNumber { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime HandoutDate { get; set; }
    }
}
