using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Business.Services;
using QuanLyNhanSu.Models.Entities;
using QuanLyNhanSu.Models.ViewModel;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeSosController : ControllerBase
    {
        private readonly IHeSoService _salaryService;
        public HeSosController(IHeSoService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpGet]
        public async Task<IEnumerable<GetHeSoViewModel>> Get()
        {
            var entities = _salaryService.GetAllAsync().Result;
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
                Id = entity.PositionId,
                PositionName = entity.Name,
                HeSo = entity.HeSo,
            };
            await _salaryService.AddAsync(Position);
            return Ok();
        }


        [HttpGet("{entityId}")]
        public async Task<GetHeSoViewModel> GetById(int entityId)
        {
            var entity = await _salaryService.GetByIdAsync(entityId);
            if (entity != null)
            {
                return new GetHeSoViewModel 
                {
                    Name = entity.PositionName,
                    HeSo = entity.HeSo
                };
            }
            else
            {
                return null;
            }
        }


        [HttpPut("{entityId}")]
        public async Task<IActionResult> Put(int entityId, [FromBody] GetHeSoViewModel entity)
        {
            if (entity == null)
            {
                return new JsonResult(new { title = $"Request body cannot be null" });
            }
            if (!decimal.TryParse(entity.HeSo.ToString(), out decimal HeSo))
            {
                return new JsonResult(new { title = $"Money '{entity.Name}' is invalid." });
            }
            var position = await _salaryService.GetByIdAsync(entity.Id);
            position.PositionName = entity.Name;
            position.HeSo = entity.HeSo;
            await _salaryService.UpdateAsync(position);
            return Ok(position);
            //if (entity == null)
            //{
            //    return BadRequest("Invalid input data.");
            //}

            //try
            //{
            //    await _salaryService.UpdateAsync(new Position
            //    {
            //        PositionId = entityId,
            //        PositionName = entity.Name,
            //        HeSo = entity.HeSo
            //    });

            //    return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"Error occurred while updating position coefficient with ID {entityId}.");
            //    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            //}
        }



        [HttpDelete("{entityId}")]
        public async Task<ActionResult> Delete(int entityId)
        {
            await _salaryService.DeleteAsync(entityId);
            return Ok();
        }
    }
}
