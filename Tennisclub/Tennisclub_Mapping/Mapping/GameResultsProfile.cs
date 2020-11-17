using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub_Data_Layer.Models;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Mapping.Mapping
{
    public class GameResultsProfile : Profile
    {
        public GameResultsProfile()
        {
            CreateMap<GameResult, GameResultReadDto>();

            CreateMap<GameResultCreateDto, GameResult>();

            CreateMap<GameResultUpdateDto, GameResult>();
        }
    }
}
