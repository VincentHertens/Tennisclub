using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_BL.Services.GameServices;
using Tennisclub_Common.GameDTO;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;

        public GamesController(IGameService service)
        {
            _service = service;
        }

        [HttpGet("bydate")]
        public ActionResult<IEnumerable<GameReadDto>> GetAllByDate([FromQuery] DateTime? date)
        {
            return Ok(_service.GetAllByDate(date));
        }

        [HttpGet("bymember/{id}")]
        public ActionResult<IEnumerable<GameReadDto>> GetAllByMember(int id, [FromQuery] DateTime? date)
        {
            return Ok(_service.GetAllByMember(id, date));
        }

        [HttpGet("{id}")]
        public ActionResult<GameReadDto> GetById(int id)
        {
            var game = _service.GetById(id);
            if (game != null)
            {
                return Ok(game);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<GameReadDto> Add(GameCreateDto gameCreateDto)
        {
            if (gameCreateDto == null)
            {
                return BadRequest(new { Message = "Game cannot be empty" });
            }
            if (string.IsNullOrEmpty(gameCreateDto.GameNumber))
            {
                return BadRequest(new { Message = "GameNumber cannot be empty" });
            }
            var game = _service.Add(gameCreateDto);
            return CreatedAtAction(nameof(GetById), new { Id = game.Id }, game);
        }

        [HttpPut]
        public ActionResult<GameReadDto> Update(GameUpdateDto gameUpdateDto)
        {
            if (gameUpdateDto == null)
            {
                return BadRequest(new { Message = "Game cannot be empty" });
            }
            return Ok(_service.Update(gameUpdateDto));
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var game = _service.GetById(id);
            if (game == null)
            {
                return NotFound();
            }           
            _service.Delete(id);
            return NoContent();
        }

        /*private readonly IGameService _gameService;      

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        //GET: Get all filtered games
        [HttpGet]
        public ActionResult<IEnumerable<GameReadDto>> GetAllGamesFiltered([FromQuery] DateTime? date)
        {
            return Ok(_gameService.GetAllGamesFiltered(date));
        }

        //GET: Get game by id
        [HttpGet("{id}", Name = "GetGameById")]
        public ActionResult<GameReadDto> GetGameById(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game != null)
            {
                return Ok(game);
            }
            return NotFound();
        }

        //POST: Add game
        [HttpPost]
        public ActionResult<GameReadDto> AddGame(GameCreateDto gameCreateDto)
        {
            var gameReadDto = _gameService.AddGame(gameCreateDto);

            return CreatedAtRoute(nameof(GetGameById), new { Id = gameReadDto.Id }, gameReadDto);
        }

        //PUT: Update game
        [HttpPut("{id}")]
        public ActionResult UpdateGame(int id, GameUpdateDto gameUpdateDto)
        {
            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            
            _gameService.UpdateGame(id, gameUpdateDto);

            return NoContent();
        }

        //DELETE: Delete game
        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }

            _gameService.DeleteGame(id);

            return NoContent();
        }  */
    }
}
