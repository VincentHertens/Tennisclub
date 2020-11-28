using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_BL.OldServices
{
    public class GameService //: IGameService
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        /*public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;        
        }*/

       /* public IEnumerable<GameReadDto> GetAllGamesFiltered(DateTime? date)
        {
            return _mapper.Map<IEnumerable<GameReadDto>>(_unitOfWork.Games.GetAllGamesFiltered(date));
        }

        public GameReadDto GetGameById(int id)
        {
            return _mapper.Map<GameReadDto>(_unitOfWork.Games.GetById(id));
        }

        public GameReadDto AddGame(GameCreateDto game)
        {
            var gameToCreate = _mapper.Map<Game>(game);
            _unitOfWork.Games.Add(gameToCreate);
            _unitOfWork.Commit();

            var gameReadDto = _mapper.Map<GameReadDto>(gameToCreate);
            return gameReadDto;           
        }

        public void UpdateGame(int id, GameUpdateDto game)
        {
            var gameToUpdate = _unitOfWork.Games.GetById(id);

            var updatedGame = _mapper.Map(game, gameToUpdate);

            _unitOfWork.Games.Update(updatedGame);
            _unitOfWork.Commit();
        }

        public void DeleteGame(int id)
        {
            var game = _unitOfWork.Games.GetById(id);

            _unitOfWork.Games.Delete(game);
            _unitOfWork.Commit();
        }*/
    }
}
