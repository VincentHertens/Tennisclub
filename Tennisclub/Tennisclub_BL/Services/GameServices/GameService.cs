using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub_Common.GameDTO;
using Tennisclub_DAL.Repositories.GameRepositories;

namespace Tennisclub_BL.Services.GameServices
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GameReadDto> GetAllByDate(DateTime? date)
        {
            return _repository.GetAll(filter: game => (game.Date == date || date == null),
                orderBy: game => game.OrderBy(x => x.Date),
                x => x.Member, x => x.League);
        }

        public IEnumerable<GameReadDto> GetAllByMember(int id, DateTime? date)
        {
            return _repository.GetAll(filter: game => (game.Date == date || date == null) && game.MemberId == id, 
                orderBy: game => game.OrderBy(x => x.Date), 
                x => x.Member, x => x.League);
        }

        public GameReadDto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public GameReadDto Add(GameCreateDto gameCreateDto)
        {
            return _repository.Add(gameCreateDto);
        }

        public GameReadDto Update(GameUpdateDto gameUpdateDto)
        {
            return _repository.Update(gameUpdateDto);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
