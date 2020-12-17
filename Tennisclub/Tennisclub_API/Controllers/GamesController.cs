using System;
using System.Collections.Generic;
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
                return Ok(game);

            return NotFound();
        }

        [HttpPost]
        public ActionResult<GameReadDto> Add(GameCreateDto gameCreateDto)
        {
            if (gameCreateDto == null)
                return BadRequest(new { Message = "Game cannot be empty" });

            var game = _service.Add(gameCreateDto);
            return CreatedAtAction(nameof(GetById), new { Id = game.Id }, game);
        }

        [HttpPut]
        public ActionResult<GameReadDto> Update(GameUpdateDto gameUpdateDto)
        {
            if (gameUpdateDto == null)
                return BadRequest(new { Message = "Game cannot be empty" });

            return Ok(_service.Update(gameUpdateDto));
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var game = _service.GetById(id);

            if (game == null)
                return NotFound();    
            
            _service.Delete(id);
            return NoContent();
        }
    }
}
