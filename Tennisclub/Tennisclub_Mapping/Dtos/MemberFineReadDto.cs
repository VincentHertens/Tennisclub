using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Mapping.Dtos
{
    public class MemberFineReadDto
    {
        public int Id { get; set; }
        public int FineNumber { get; set; }
        public MemberReadDto Member { get; set; }
        public decimal Amount { get; set; }
        public DateTime HandoutDate { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
