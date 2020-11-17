using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_Business_Layer.Services;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        //GET: Get all genders
        [HttpGet]
        public ActionResult<IEnumerable<GenderReadDto>> GetAllGenders()
        {
            return Ok(_genderService.GetAllGenders());
        }

        //GET: Get gender by id
        [HttpGet("{id}", Name = "GetGenderById")]
        public ActionResult<GenderReadDto> GetGenderById(byte id)
        {
            var gender = _genderService.GetGenderById(id);
            if (gender != null)
            {
                return Ok(gender);
            }
            return NotFound();
        }

        /*//GET: Get all genders
        [HttpGet]
        public ActionResult<IEnumerable<GenderReadDto>> GetAllGenders()
        {
            return Ok(_mapper.Map<IEnumerable<GenderReadDto>>(_genderService.GetAllGenders()));
        }

        //GET: Get gender by id
        [HttpGet("{id}", Name = "GetGenderById")]
        public ActionResult<GenderReadDto> GetGenderById(byte id)
        {
            var gender = _genderService.GetGenderById(id);
            if (gender != null)
            {
                return Ok(_mapper.Map<GenderReadDto>(gender));
            }
            return NotFound();
        }*/
    }
}
