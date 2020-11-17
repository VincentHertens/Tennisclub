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
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;      

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
        }

        /*//GET: Get all filtered games
        [HttpGet]
        public ActionResult<IEnumerable<GameReadDto>> GetAllGamesFiltered([FromQuery] DateTime? date)
        {
            return Ok(_mapper.Map<IEnumerable<GameReadDto>>(_gameService.GetAllGamesFiltered(date)));
        }

        //GET: Get game by id
        [HttpGet("{id}", Name = "GetGameById")]
        public ActionResult<GameReadDto> GetGameById(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game != null)
            {
                return Ok(_mapper.Map<GameReadDto>(game));
            }
            return NotFound();
        }

        //POST: Add game
        [HttpPost]
        public ActionResult<GameReadDto> AddGame(GameCreateDto gameCreateDto)
        {
            var gameToCreate = _mapper.Map<Game>(gameCreateDto);
            _gameService.AddGame(gameToCreate);

            var gameReadDto = _mapper.Map<GameReadDto>(gameToCreate);
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

            _mapper.Map(gameUpdateDto, game);
            _gameService.UpdateGame(game);

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

            _gameService.DeleteGame(game);

            return NoContent();
        }*/
    }
}
