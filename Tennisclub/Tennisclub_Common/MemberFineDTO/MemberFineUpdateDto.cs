using System;

namespace Tennisclub_Common.MemberFineDTO
{
    public class MemberFineUpdateDto : IModelUpdateDto<int>
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
