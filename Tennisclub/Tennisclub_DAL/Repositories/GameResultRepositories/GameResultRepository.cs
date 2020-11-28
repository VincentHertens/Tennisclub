using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameResultDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.GameResultRepositories
{
    public class GameResultRepository : GenericRepository<GameResult, GameResultReadDto, GameResultCreateDto, GameResultUpdateDto, int>, IGameResultRepository
    {
        public GameResultRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }


    }
}
