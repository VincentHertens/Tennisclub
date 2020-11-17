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
    public class GameResultsController : ControllerBase
    {
        private readonly IGameResultService _gameResultService;        

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
        }

        /* //GET: Get all filtered game results by member id
         [HttpGet("list/{id}")]
         public ActionResult<IEnumerable<GameResultReadDto>> GetAllGameResultsByMemberId(int id, [FromQuery] DateTime? date)
         {
             return Ok(_mapper.Map<IEnumerable<GameResultReadDto>>(_gameResultService.GetAllGameResultsByMemberId(id, date)));
         }


         //GET: Get game result by id
         [HttpGet("{id}", Name = "GetGameResultById")]
         public ActionResult<GameResultReadDto> GetGameResultById(int id)
         {
             var gameResult = _gameResultService.GetGameResultById(id);
             if (gameResult != null)
             {
                 return Ok(_mapper.Map<GameResultReadDto>(gameResult));
             }
             return NotFound();
         }

         //POST: Add game result
         [HttpPost]
         public ActionResult<GameResultReadDto> AddGameResult(GameResultCreateDto gameResultCreateDto)
         {
             var gameResultToCreate = _mapper.Map<GameResult>(gameResultCreateDto);
             _gameResultService.AddGameResult(gameResultToCreate);

             var gameResultReadDto = _mapper.Map<GameResultReadDto>(gameResultToCreate);
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

             _mapper.Map(gameResultUpdateDto, gameResult);
             _gameResultService.UpdateGameResult(gameResult);

             return NoContent();
         }*/
    }
}
