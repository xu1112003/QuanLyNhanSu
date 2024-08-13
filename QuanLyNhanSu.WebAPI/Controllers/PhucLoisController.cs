using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Data.Context;
using QuanLyNhanSu.Models.Entities;
using QuanLyNhanSu.Models.ViewModel;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhucLoisController : ControllerBase
    {
        private readonly IPhucLoiService _salaryService;
        private readonly QLNSContext _projectPart2Context;
        public PhucLoisController(IPhucLoiService salaryService,QLNSContext projectPart2Context)
        {
            _salaryService = salaryService;
            _projectPart2Context = projectPart2Context;
        }
        [HttpGet]
        public async Task<IEnumerable<PhucLoi>> Get()
        {
            var entities = await _salaryService.GetAllAsync();
            return entities;
        }


        [HttpPost]
        public virtual async Task<ActionResult> Post([FromBody] PhucLoiViewModel entity)
        {
            if (entity == null)
            {
                return new JsonResult(new { title = $"Request body cannot be null" });
            }
            if (!decimal.TryParse(entity.Money.ToString(), out decimal Money))
            {
                return new JsonResult(new { title = $"Money '{entity.PhucLoiType}' is invalid." });
            }
            if (_projectPart2Context.PhucLois.Where(s => s.PhucLoiType.ToUpper().Equals(entity.PhucLoiType.ToUpper())).Any())
            {
                return new JsonResult(new { title = $"'{entity.PhucLoiType}' is already exists." });
            }
            var PhucLoi = new PhucLoi
            {
                PhucLoiType = entity.PhucLoiType,
                Money = entity.Money,
            };
            await _salaryService.AddAsync(PhucLoi);
            return Ok();
        }


        [HttpGet("{entityId}")]
        public async Task<PhucLoi> GetById(int entityId)
        {
            var entity = await _salaryService.GetByIdAsync(entityId);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }


        [HttpPut("{entityId}")]
        public async Task<IActionResult> Put([FromBody] PhucLoiViewModel entity, int entityId)
        {
            if (entity == null)
            {
                return new JsonResult(new { title = $"Request body cannot be null" });
            }
            if (!decimal.TryParse(entity.Money.ToString(), out decimal Money))
            {
                return new JsonResult(new { title = $"Money '{entity.PhucLoiType}' is invalid." });
            }
            if (_projectPart2Context.PhucLois.Where(s => s.PhucLoiType.ToUpper().Equals(entity.PhucLoiType.ToUpper())).Any())
            {
                return new JsonResult(new { title = $"'{entity.PhucLoiType}' is already exists." });
            }
            var PhucLoi = _salaryService.GetByIdAsync(entityId).Result;
            PhucLoi.PhucLoiType = entity.PhucLoiType;
            PhucLoi.Money = entity.Money;
            await _salaryService.UpdateAsync(PhucLoi);
            return Ok(PhucLoi);
        }



        [HttpDelete("{entityId}")]
        public async Task<ActionResult> Delete(int entityId)
        {
            await _salaryService.DeleteAsync(entityId);
            return Ok();
        }
    }
}
