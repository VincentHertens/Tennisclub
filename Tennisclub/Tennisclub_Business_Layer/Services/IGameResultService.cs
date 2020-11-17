using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public interface IGameResultService
    {
        IEnumerable<GameResultReadDto> GetAllGameResultsByMemberId(int id, DateTime? date);
        GameResultReadDto GetGameResultById(int id);
        GameResultReadDto AddGameResult(GameResultCreateDto gameResult);
        void UpdateGameResult(int id, GameResultUpdateDto gameResult);

       /* IEnumerable<GameResult> GetAllGameResultsByMemberId(int id, DateTime? date);
        GameResult GetGameResultById(int id);
        void AddGameResult(GameResult gameResult);
        void UpdateGameResult(GameResult gameResult);*/
    }
}
