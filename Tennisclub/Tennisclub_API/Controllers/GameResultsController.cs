using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_BL.Services.GameResultServices;
using Tennisclub_Common.GameResultDTO;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultsController : ControllerBase
    {
        private readonly IGameResultService _service;

        public GameResultsController(IGameResultService service)
        {
            _service = service;
        }

        [HttpGet("bymember/{id}")]
        public ActionResult<IEnumerable<GameResultReadDto>> GetAllByMember(int id, [FromQuery] DateTime? date)
        {
            return Ok(_service.GetAllByMember(id, date));
        }

        [HttpGet("{id}")]
        public ActionResult<GameResultReadDto> GetById(int id)
        {
            var gameResult = _service.GetById(id);
            if (gameResult != null)
            {
                return Ok(gameResult);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<GameResultReadDto> Add(GameResultCreateDto gameResultCreateDto)
        {
            if (gameResultCreateDto == null)
            {
                return BadRequest(new { Message = "GameResult cannot be empty" });
            }           
            var gameResult = _service.Add(gameResultCreateDto);
            return CreatedAtAction(nameof(GetById), new { Id = gameResult.Id }, gameResult);
        }

        [HttpPut]
        public ActionResult<GameResultReadDto> Update(GameResultUpdateDto gameResultUpdateDto)
        {
            if (gameResultUpdateDto == null)
            {
                return BadRequest(new { Message = "GameResult cannot be empty" });
            }
            return Ok(_service.Update(gameResultUpdateDto));
        }

        /* private readonly IGameResultService _gameResultService;        

         public GameResultsController(IGameResultService gameResultService)
         {
             _gameResultService = gameResultService;
         }

         //GET: Get all filtered game results by member id
         [HttpGet("list/{id}")]
         public ActionResult<IEnumerable<GameResultReadDto>> GetAllGameResultsByMemberId(int id, [FromQuery] DateTime? date)
         {
             return Ok(_gameResultService.GetAllGameResultsByMemberId(id, date));
         }


         //GET: Get game result by id
         [HttpGet("{id}", Name = "GetGameResultById")]
         public ActionResult<GameResultReadDto> GetGameResultById(int id)
         {
             var gameResult = _gameResultService.GetGameResultById(id);
             if (gameResult != null)
             {
                 return Ok(gameResult);
             }
             return NotFound();
         }

         //POST: Add game result
         [HttpPost]
         public ActionResult<GameResultReadDto> AddGameResult(GameResultCreateDto gameResultCreateDto)
         {
             var gameResultReadDto = _gameResultService.AddGameResult(gameResultCreateDto);

             return CreatedAtRoute(nameof(GetGameResultById), new { Id = gameResultReadDto.Id }, gameResultReadDto);
         }

         //PUT: Update game result
         [HttpPut("{id}")]
         public ActionResult UpdateGameResult(int id, GameResultUpdateDto gameResultUpdateDto)
         {
             var gameResult = _gameResultService.GetGameResultById(id);
             if (gameResult == null)
             {
                 return NotFound();
             }

             _gameResultService.UpdateGameResult(id, gameResultUpdateDto);

             return NoContent();
         }*/
    }
}
