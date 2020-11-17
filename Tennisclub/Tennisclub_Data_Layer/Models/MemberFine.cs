﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_Data_Layer.Models
{
    public class MemberFine
    {
        public int Id { get; set; }
        public int FineNumber { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public decimal Amount { get; set; }
        public DateTime HandoutDate { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
