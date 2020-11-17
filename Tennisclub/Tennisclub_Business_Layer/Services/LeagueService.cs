using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Data;
using Tennisclub_Data_Layer.Models;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeagueService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<LeagueReadDto> GetAllLeagues()
        {
            return _mapper.Map<IEnumerable<LeagueReadDto>>(_unitOfWork.Leagues.GetAll());
        }

        public LeagueReadDto GetLeagueById(byte id)
        {
            return _mapper.Map<LeagueReadDto>(_unitOfWork.Leagues.GetById(id));
        }

        /*public IEnumerable<League> GetAllLeagues()
        {
            return _unitOfWork.Leagues.GetAll();
        }

        public League GetLeagueById(byte id)
        {
            return _unitOfWork.Leagues.GetById(id);
        }*/
    }
}
