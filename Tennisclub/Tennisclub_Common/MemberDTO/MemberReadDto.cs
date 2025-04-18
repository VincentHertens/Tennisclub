﻿using System;
using Tennisclub_Common.GenderDTO;

namespace Tennisclub_Common.MemberDTO
{
    public class MemberReadDto : IModelReadDto<int>
    {
        public int Id { get; set; }
        public string FederationNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }       
        public GenderReadDto Gender { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
        public bool Active { get; set; }
    }
}
