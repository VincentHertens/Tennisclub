using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.GenderDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_BL.OldServices
{
    public interface IGenderService
    {
        IEnumerable<GenderReadDto> GetAllGenders();
        GenderReadDto GetGenderById(byte id);

        /*IEnumerable<Gender> GetAllGenders();
        Gender GetGenderById(byte id);*/
    }
}
