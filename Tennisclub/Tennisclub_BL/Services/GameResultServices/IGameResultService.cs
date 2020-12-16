using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameResultDTO;

namespace Tennisclub_BL.Services.GameResultServices
{
    public interface IGameResultService
    {
        public IEnumerable<GameResultReadDto> GetAllByMember(int id, DateTime? date);
        public GameResultReadDto GetById(int id);
        public GameResultReadDto Add(GameResultCreateDto gameResultCreateDto);
        public GameResultReadDto Update(GameResultUpdateDto gameResultUpdateDto);
    }
}
