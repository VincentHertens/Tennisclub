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
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService _leagueService;

        public LeaguesController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        //GET: Get all leagues
        [HttpGet]
        public ActionResult<IEnumerable<LeagueReadDto>> GetAllLeagues()
        {
            return Ok(_leagueService.GetAllLeagues());
        }

        //GET: Get league by id
        [HttpGet("{id}", Name = "GetLeagueById")]
        public ActionResult<LeagueReadDto> GetLeagueById(byte id)
        {
            var league = _leagueService.GetLeagueById(id);
            if (league != null)
            {
                return Ok(league);
            }
            return NotFound();
        }

        /*//GET: Get all leagues
        [HttpGet]
        public ActionResult<IEnumerable<LeagueReadDto>> GetAllLeagues()
        {
            return Ok(_mapper.Map<IEnumerable<LeagueReadDto>>(_leagueService.GetAllLeagues()));
        }

        //GET: Get league by id
        [HttpGet("{id}", Name = "GetLeagueById")]
        public ActionResult<LeagueReadDto> GetLeagueById(byte id)
        {
            var league = _leagueService.GetLeagueById(id);
            if (league != null)
            {
                return Ok(_mapper.Map<LeagueReadDto>(league));
            }
            return NotFound();
        }*/
    }
}
