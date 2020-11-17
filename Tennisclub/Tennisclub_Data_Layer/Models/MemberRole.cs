using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_Data_Layer.Models
{
    public class MemberRole
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public byte RoleId { get; set; } //byte
        public Role Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
