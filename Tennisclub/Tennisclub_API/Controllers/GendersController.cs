using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_BL.Services.GenderServices;
using Tennisclub_Common.GenderDTO;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _service;

        public GendersController(IGenderService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<GenderReadDto> GetAll()
        {
            return _service.GetAll();
        }

        /*private readonly IGenderService _genderService;

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
        }*/
    }
}
