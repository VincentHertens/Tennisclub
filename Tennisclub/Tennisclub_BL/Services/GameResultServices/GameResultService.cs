using System;
using System.Collections.Generic;
using System.Linq;
using Tennisclub_Common.GameResultDTO;
using Tennisclub_DAL.Repositories.GameResultRepositories;

namespace Tennisclub_BL.Services.GameResultServices
{
    public class GameResultService : IGameResultService
    {
        private readonly IGameResultRepository _repository;

        public GameResultService(IGameResultRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GameResultReadDto> GetAllByMember(int id, DateTime? date)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id cannot have a value less than 1");

            return _repository.GetAll(filter: gameResult => gameResult.Game.MemberId == id && (gameResult.Game.Date == date || date == null),
                orderBy: gameResult => gameResult.OrderBy(x => x.Game.Date),
                includeProperties: x => x.Game);
        }

        public GameResultReadDto GetById(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id cannot have a value less than 1");

            return _repository.GetById(id);
        }

        public GameResultReadDto Add(GameResultCreateDto gameResultCreateDto)
        {
            var list = _repository.GetAll(gameResult => (gameResult.GameId == gameResultCreateDto.GameId && gameResult.SetNr == gameResultCreateDto.SetNr));

            if (list.Count() != 0)
                throw new ArgumentException($"The combination of game and setnr must be unique");

            return _repository.Add(gameResultCreateDto);
        }

        public GameResultReadDto Update(GameResultUpdateDto gameResultUpdateDto)
        {          
            return _repository.Update(gameResultUpdateDto);
        }
    }
}
