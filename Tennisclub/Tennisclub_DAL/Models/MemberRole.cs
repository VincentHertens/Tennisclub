using System;

namespace Tennisclub_DAL.Models
{
    public class MemberRole : IModel<int>
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public byte RoleId { get; set; } 
        public Role Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
