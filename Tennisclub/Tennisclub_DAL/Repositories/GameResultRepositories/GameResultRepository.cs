using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tennisclub_Common.GameResultDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.GameResultRepositories
{
    public class GameResultRepository : GenericRepository<GameResult, GameResultReadDto, GameResultCreateDto, GameResultUpdateDto, int>, IGameResultRepository
    {
        public GameResultRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }

        public IEnumerable<GameResultReadDto> GetAllGameResultsByMember(int id, DateTime? date)
        {
            return GetAll(filter: gameResult => gameResult.Game.MemberId == id && (gameResult.Game.Date == date || date == null),
                orderBy: gameResult => gameResult.OrderBy(x => x.Game.Date),
                includeProperties: x => x.Game);
        }

        public override GameResultReadDto Add(GameResultCreateDto createDto)
        {
            var game = _context.Set<Game>().Find(createDto.GameId);

            if (game == null)
                throw new NullReferenceException("No game with this id has been found");

            return base.Add(createDto);
        }

        public override GameResultReadDto Update(GameResultUpdateDto updateDto)
        {
            var gameResult = _dbSet.Find(updateDto.Id);
            gameResult.ScoreOpponent = updateDto.ScoreOpponent;
            gameResult.ScoreTeamMember = updateDto.ScoreTeamMember;
            _dbSet.Update(gameResult);
            SaveChanges();
            return GetById(gameResult.Id);
        }
    }
}
