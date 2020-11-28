using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub_Common.MemberDTO;

namespace Tennisclub_Common.MemberFineDTO
{
    public class MemberFineReadDto : IModelReadDto<int>
    {
        public int Id { get; set; }
        public int FineNumber { get; set; }
        public MemberReadDto Member { get; set; }
        public decimal Amount { get; set; }
        public DateTime HandoutDate { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
