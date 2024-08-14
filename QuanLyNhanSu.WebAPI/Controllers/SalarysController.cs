using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Business.Services;
using QuanLyNhanSu.Data.Context;
using QuanLyNhanSu.Models.DTO;
using QuanLyNhanSu.Models.Entities;
using QuanLyNhanSu.Models.Filters;
using QuanLyNhanSu.Models.ViewModel;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalarysController :ControllerBase
    {
        private readonly ISalaryService _salaryService;
        private readonly QLNSContext _projectPart2Context;
        public SalarysController(ISalaryService salaryService, QLNSContext projectPart2Context)
        {
            _salaryService = salaryService;
            _projectPart2Context = projectPart2Context;
        }
        [HttpGet]
        public async Task<IEnumerable<Salary>> Get()
        {
                var entities = await _salaryService.GetAllAsync();
                return entities;
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> GetSalaryPagings([FromQuery] SalaryFilter departmentFilter)
        {

            var entities = _projectPart2Context.Salaries.AsQueryable();//.Where(e => e.DepartmentName.Equals(departmentFilter.DepartmentName))
            var paging = await entities.Skip((departmentFilter.Page - 1) * departmentFilter.PageSize).Take(departmentFilter.PageSize).ToListAsync();

            var paging2 = new Pagging<Salary>
            {
                totalRecord = await entities.CountAsync(),
                data = paging,
                pageIndex = departmentFilter.Page,
                pageSize = departmentFilter.PageSize,
                totalPages = (int)Math.Ceiling((double)entities.Count() / departmentFilter.PageSize)
            };

            if (paging2.data.Any() && departmentFilter.Page >= 0 && departmentFilter.PageSize >= 0)
            {
                return Ok(paging2);
            }
            else return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EditSalaryViewModel entity)
        {
            try
            {
                if (entity == null)
                {
                    return new JsonResult(new { title = $"Request body cannot be null" });
                }

                if (!decimal.TryParse(entity.Money.ToString(), out decimal Money))
                {
                    return BadRequest(new
                    {
                        type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                        title = "Invalid money value",
                        status = 400,
                        detail = $"Money '{entity.SalaryType}' is invalid."
                    });
                }

                if ( _projectPart2Context.Salaries.Where(s => s.SalaryType.ToUpper().Equals(entity.SalaryType.ToUpper())).Any())
                {
                    return new JsonResult(new { title = $"'{entity.SalaryType}' is invalid." });
                }
                var newSalary = new Salary
                {
                    SalaryType = entity.SalaryType,
                    Money = Money,
                };  
                    await _salaryService.AddAsync(newSalary);
                }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra khi thêm Salary, kiểm tra xem đã tồn tại hay chưa
                return new JsonResult(ex);
            }

            return Ok();
            //if (entity == null)
            //{
            //    return null;
            //}
            //var Salary = new Salary
            //{
            //    SalaryType = entity.SalaryType,
            //    Money = entity.Money,
            //};
            //await _salaryService.AddAsync(Salary);
            //return Ok();
        }


        [HttpGet("{entityId}")]
        public async Task<Salary> GetById(int entityId)
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
        public async Task<IActionResult> Put( [FromBody] EditSalaryViewModel entity, int entityId)
        {
            if (entity == null)
            {
                return new JsonResult(new { title = $"Request body cannot be null" });
            }
            if (!decimal.TryParse(entity.Money.ToString(), out decimal Money))
            {
                return new JsonResult(new { title = $"Money '{entity.SalaryType}' is invalid." });
            }
            var Salary = _salaryService.GetByIdAsync(entityId).Result;
            Salary.SalaryType = entity.SalaryType;
            Salary.Money = Money;
            await _salaryService.UpdateAsync(Salary);
            return Ok(Salary);
        }



        [HttpDelete("{entityId}")]
        public async Task<ActionResult> Delete(int entityId)
        {
            await _salaryService.DeleteAsync(entityId);
            return Ok();
        }
    }
}
