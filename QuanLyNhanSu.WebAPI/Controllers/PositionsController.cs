using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Models.DTO;
using QuanLyNhanSu.Models.Entities;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _positionService;
        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        // GET: api/Position
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
            var positions = await _positionService.GetAllPositionsAsync();
            return Ok(positions);
        }

        // GET: api/Position/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPosition(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            return Ok(position);
        }

        // PUT: api/Position/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPosition(int id, PositionDTO positionDTO)
        {
            if (id != positionDTO.PositionId)
            {
                return BadRequest();
            }
            var existingPosition = await _positionService.GetPositionByIdAsync(id);
            if (existingPosition == null)
            {
                return NotFound();
            }
            existingPosition.PositionName = positionDTO.PositionName;
            existingPosition.Description = positionDTO.Description;
            existingPosition.Number = positionDTO.Number;
            existingPosition.HeSo = positionDTO.HeSo;

            await _positionService.UpdatePositionAsync(existingPosition);
            return NoContent();
        }

        // POST: api/Position
        [HttpPost]
        public async Task<ActionResult> PostPosition([FromBody] PositionDTO positionDTO)
        {
            if (positionDTO == null)
            {
                return BadRequest("Position object is null");
            }
            var position = new Position
            {
                PositionId = positionDTO.PositionId,
                PositionName = positionDTO.PositionName,
                Description = positionDTO.Description,
                Number = positionDTO.Number,
                HeSo = positionDTO.HeSo,
            };
            await _positionService.AddPositionAsync(position);
            return CreatedAtAction(nameof(GetPosition), new { id = position.PositionId }, position);
        }

        // DELETE: api/Position/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePosition(int id)
        {
            await _positionService.DeletePositionAsync(id);
            return NoContent();
        }
    }
}
