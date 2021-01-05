using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_BL.Services.LeagueServices;
using Tennisclub_Common.LeagueDTO;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService _service;

        public LeaguesController(ILeagueService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<LeagueReadDto> GetAllLeagues()
        {
            return _service.GetAllLeagues();
        }
    }
}
