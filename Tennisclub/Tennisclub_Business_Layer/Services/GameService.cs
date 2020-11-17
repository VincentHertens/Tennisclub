using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Data;
using Tennisclub_Data_Layer.Models;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;        
        }

        public IEnumerable<GameReadDto> GetAllGamesFiltered(DateTime? date)
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
        }

        /*public IEnumerable<Game> GetAllGamesFiltered(DateTime? date)
        {
            return _unitOfWork.Games.GetAllGamesFiltered(date);
        }

        public Game GetGameById(int id)
        {
            return _unitOfWork.Games.GetById(id);
        }

        public void AddGame(Game game)
        {
            _unitOfWork.Games.Add(game);
            _unitOfWork.Commit();
        }               

        public void UpdateGame(Game game)
        {
            _unitOfWork.Games.Update(game);
            _unitOfWork.Commit();
        }

        public void DeleteGame(Game game)
        {
            _unitOfWork.Games.Delete(game);
            _unitOfWork.Commit();
        }*/
    }
}
