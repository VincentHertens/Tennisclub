using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.GameRepositories
{
    public interface IGameRepository : IGenericRepository<Game, GameReadDto, GameCreateDto, GameUpdateDto, int>
    {
        public IEnumerable<GameReadDto> GetAllGamesByDate(DateTime? date);

        public IEnumerable<GameReadDto> GetAllGamesByMember(int id, DateTime? date);
    }
}
