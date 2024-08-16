using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Business.Services;
using QuanLyNhanSu.Models.DTO;
using QuanLyNhanSu.Models.Entities;
using QuanLyNhanSu.Models.ViewModel;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeSosController : ControllerBase
    {
        private readonly IPositionService _salaryService;
        public HeSosController(IPositionService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpGet]
        public async Task<IEnumerable<GetHeSoViewModel>> Get()
        {
            var entities = _salaryService.GetAllPositionsAsync().Result;
            var heso = new List<GetHeSoViewModel>();
            foreach(var e in entities)
            {
                var h = new GetHeSoViewModel 
                { 
                    Id = e.PositionId,
                    Name = e.PositionName,
                    HeSo = e.HeSo
                };
                heso.Add(h);
            }
            return heso;
        }


        [HttpPost]
        public virtual async Task<ActionResult> Post([FromBody] GetHeSoViewModel entity)
        {
            if (entity == null)
            {
                return new JsonResult(new { title = $"Request body cannot be null" });
            }
            if (!decimal.TryParse(entity.HeSo.ToString(), out decimal HeSo))
            {
                return new JsonResult(new { title = $"Money '{entity.Name}' is invalid." });
            }
            var Position = new Position
            {
                PositionName = entity.Name,
                HeSo = entity.HeSo,
            };
            await _salaryService.AddPositionAsync(Position);
            return Ok();
        }


        [HttpGet("{entityId}")]
        public async Task<ActionResult<Position>> GetById(int entityId)
        {
            var position = await _salaryService.GetPositionByIdAsync(entityId);
            if (position == null)
            {
                return NotFound();
            }

            return Ok(position);
        }
        //public async Task<GetHeSoViewModel> GetById(int entityId)
        //{
        //    var entity = await _salaryService.GetPositionByIdAsync(entityId);
        //    if (entity != null)
        //    {
        //        return new GetHeSoViewModel 
        //        {
        //            Id = entity.PositionId,
        //            Name = entity.PositionName,
        //            HeSo = entity.HeSo
        //        };
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        [HttpPut("{entityId}")]
        public async Task<ActionResult> Put(int entityId, PositionDTO positionDTO)
        {
            var existingPosition = await _salaryService.GetPositionByIdAsync(entityId);
            if (existingPosition == null)
            {
                return NotFound();
            }
            existingPosition.PositionName = positionDTO.PositionName;
            existingPosition.Description = positionDTO.Description;
            existingPosition.Number = positionDTO.Number;
            existingPosition.HeSo = positionDTO.HeSo;

            await _salaryService.UpdatePositionAsync(existingPosition);
            return NoContent();
        }
        //public async Task<IActionResult> Put(int entityId, [FromBody] GetHeSoViewModel positionDTO)
        //{
        //    var existingPosition = await _salaryService.GetPositionByIdAsync(entityId);
        //    if (existingPosition == null)
        //    {
        //        return NotFound();
        //    }
        //    existingPosition.PositionName = positionDTO.Name;
        //    existingPosition.HeSo = positionDTO.HeSo;

        //    await _salaryService.UpdatePositionAsync(existingPosition);
        //    return NoContent();

        //}



        [HttpDelete("{entityId}")]
        public async Task<ActionResult> Delete(int entityId)
        {
            await _salaryService.DeletePositionAsync(entityId);
            return Ok();
        }
    }
}
