using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameResultDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.GameResultRepositories
{
    public interface IGameResultRepository : IGenericRepository<GameResult, GameResultReadDto, GameResultCreateDto, GameResultUpdateDto, int>
    {

    }
}
