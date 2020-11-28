using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennisclub_Common.MemberFineDTO
{
    public class MemberFineUpdateDto : IModelUpdateDto<int>
    {
        public int Id { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
