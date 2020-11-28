using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameResultDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_BL.OldServices
{
    public class GameResultService //: IGameResultService
    {
       /* private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameResultService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<GameResultReadDto> GetAllGameResultsByMemberId(int id, DateTime? date)
        {
            return _mapper.Map<IEnumerable<GameResultReadDto>>(_unitOfWork.GameResults.GetAllGameResultsByMemberId(id, date));
        }

        public GameResultReadDto GetGameResultById(int id)
        {
            return _mapper.Map<GameResultReadDto>(_unitOfWork.GameResults.GetById(id));
        }

        public GameResultReadDto AddGameResult(GameResultCreateDto gameResult)
        {
            var gameResultToCreate = _mapper.Map<GameResult>(gameResult);
            _unitOfWork.GameResults.Add(gameResultToCreate);
            _unitOfWork.Commit();

            var gameResultReadDto = _mapper.Map<GameResultReadDto>(gameResultToCreate);
            return gameResultReadDto;
        }

        public void UpdateGameResult(int id, GameResultUpdateDto gameResult)
        {
            var gameResultToUpdate = _unitOfWork.GameResults.GetById(id);
            var updatedGameResult = _mapper.Map(gameResult, gameResultToUpdate);

            _unitOfWork.GameResults.Update(updatedGameResult);
            _unitOfWork.Commit();
        }*/
    }
}
