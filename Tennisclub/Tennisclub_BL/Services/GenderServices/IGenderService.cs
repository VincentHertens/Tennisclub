using System.Collections.Generic;
using Tennisclub_Common.GenderDTO;

namespace Tennisclub_BL.Services.GenderServices
{
    public interface IGenderService
    {
        public IEnumerable<GenderReadDto> GetAllGenders();
    }
}
