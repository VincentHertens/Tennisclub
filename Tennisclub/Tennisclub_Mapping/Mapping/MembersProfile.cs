using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub_Data_Layer.Models;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Mapping.Mapping
{
    public class MembersProfile : Profile
    {
        public MembersProfile()
        {
            CreateMap<Member, MemberReadDto>();

            CreateMap<MemberCreateDto, Member>();

            CreateMap<MemberUpdateDto, Member>();
        }
    }
}
