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
        public ActionResult<IEnumerable<GameReadDto>> GetAllGamesByDate([FromQuery] DateTime? date)
        {
            return Ok(_service.GetAllGamesByDate(date));
        }

        [HttpGet("bymember/{id}")]
        public ActionResult<IEnumerable<GameReadDto>> GetAllGamesByMember(int id, [FromQuery] DateTime? date)
        {
            try
            {
                return Ok(_service.GetAllGamesByMember(id, date));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<GameReadDto> GetById(int id)
        {
            try
            {
                var game = _service.GetById(id);

                if (game != null)
                    return Ok(game);

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }           
        }

        [HttpPost]
        public ActionResult<GameReadDto> Add(GameCreateDto gameCreateDto)
        {
            try
            {
                if (gameCreateDto == null)
                    return BadRequest(new { Message = "Game cannot be empty" });

                var game = _service.Add(gameCreateDto);
                return CreatedAtAction(nameof(GetById), new { Id = game.Id }, game);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }           
        }

        [HttpPut]
        public ActionResult<GameReadDto> Update(GameUpdateDto gameUpdateDto)
        {
            try
            {
                if (gameUpdateDto == null)
                    return BadRequest(new { Message = "Game cannot be empty" });

                return Ok(_service.Update(gameUpdateDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var game = _service.GetById(id);

                if (game == null)
                    return NotFound();

                _service.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }           
        }
    }
}
