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
    }
}
