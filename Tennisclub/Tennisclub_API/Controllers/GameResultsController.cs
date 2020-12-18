using System;
using System.Collections.Generic;
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
            try
            {
                return Ok(_service.GetAllByMember(id, date));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }           
        }

        [HttpGet("{id}")]
        public ActionResult<GameResultReadDto> GetById(int id)
        {
            try
            {
                var gameResult = _service.GetById(id);

                if (gameResult != null)
                    return Ok(gameResult);

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }          
        }

        [HttpPost]
        public ActionResult<GameResultReadDto> Add(GameResultCreateDto gameResultCreateDto)
        {
            try
            {
                if (gameResultCreateDto == null)
                    return BadRequest(new { Message = "Game result cannot be empty" });

                var gameResult = _service.Add(gameResultCreateDto);
                return CreatedAtAction(nameof(GetById), new { Id = gameResult.Id }, gameResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPut]
        public ActionResult<GameResultReadDto> Update(GameResultUpdateDto gameResultUpdateDto)
        {
            if (gameResultUpdateDto == null)
                return BadRequest(new { Message = "Game result cannot be empty" });

            return Ok(_service.Update(gameResultUpdateDto));
        }      
    }
}
