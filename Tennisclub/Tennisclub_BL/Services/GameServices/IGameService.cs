using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GameDTO;

namespace Tennisclub_BL.Services.GameServices
{
    public interface IGameService
    {
        public IEnumerable<GameReadDto> GetAll(DateTime? date);
        public GameReadDto Add(GameCreateDto gameCreateDto);
        public GameReadDto Update(GameUpdateDto gameUpdateDto);
        public void Delete(int id);
    }
}
