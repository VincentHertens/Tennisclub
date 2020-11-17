using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public interface IGenderService
    {
        IEnumerable<GenderReadDto> GetAllGenders();
        GenderReadDto GetGenderById(byte id);

        /*IEnumerable<Gender> GetAllGenders();
        Gender GetGenderById(byte id);*/
    }
}
