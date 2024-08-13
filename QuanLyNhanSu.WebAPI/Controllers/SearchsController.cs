using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Data.Context;
using QuanLyNhanSu.Models.Entities;
using QuanLyNhanSu.Models.ViewModel;
using System.Runtime.InteropServices;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchsController : ControllerBase
    {
        private readonly QLNSContext _projectPart2Context;
        public SearchsController (QLNSContext projectPart2Context)
        {
            _projectPart2Context = projectPart2Context;
        }
        [HttpGet]
        [Route("SearchCong/{key}")]
        public async Task<ActionResult> SearchChamCong(string? key)
        {
            try
            {
                var congs = from c in _projectPart2Context.Congs select c;
                congs = congs.Include(c => c.Employee);
                if (!string.IsNullOrEmpty(key))
                {
                    congs = congs.Where(x => x.Employee.Name.ToUpper().Contains(key.ToUpper()));
                }
                var results = new List<SearchResultViewModel>();
                foreach (var cong in congs)
                {
                    var result = new SearchResultViewModel
                    {
                        CongId = cong.CongId,
                        CheckIn = cong.CheckIn,
                        CheckOut = cong.CheckOut,
                        Status = cong.Status
                    };
                    results.Add(result);
                }
                if (results.Count > 0)
                {
                    return Ok(results);
                }
                else
                {
                    return new JsonResult(new { title = "Không có dữ liệu" });
                }
                
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
        [HttpGet]
        [Route("SearchAll/{keyword}")]
        public async Task<IActionResult> SearchAll(string? keyword)
        {
            var results = new List<dynamic>();

            // Tìm kiếm trong bảng PhucLoi
            var phucLois = _projectPart2Context.PhucLois
                .Where(p => p.PhucLoiType.ToUpper().Contains(keyword))
                .Select(p => new
                {
                    Id = p.PhucLoiId,
                    PhucLoiType = p.PhucLoiType,
                    Amount = p.Money
                })
                .ToList();
            results.AddRange(phucLois);

            // Tìm kiếm trong bảng Position
            var positions = _projectPart2Context.Positions
                .Where(p => p.PositionName.ToUpper().Contains(keyword) || p.Description.ToUpper().Contains(keyword))
                .Select(p => new
                {
                    Id = p.PositionId,
                    PositionName = p.PositionName,
                    Description = p.Description
                })
                .ToList();
            results.AddRange(positions);

            // Tìm kiếm trong bảng Employee
            var employees = _projectPart2Context.Employees
                .Where(e => e.Name.ToUpper().Contains(keyword) || e.Email.ToUpper().Contains(keyword) || e.Role.ToUpper().Contains(keyword) || e.Address.ToUpper().Contains(keyword))
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    Name = e.Name,
                    Email = e.Email,
                    Role = e.Role,
                    Address = e.Address
                })
                .ToList();
            results.AddRange(employees);

            // Tìm kiếm trong bảng Cong
            var congs = _projectPart2Context.Congs
                .Where(c => c.Status.ToUpper().Contains(keyword))
                .Select(c => new
                {
                    Id = c.CongId,
                    CheckIn = c.CheckIn,
                    CheckOut = c.CheckOut,
                    Status = c.Status,
                    EmployeeId = c.EmployeeId
                })
                .ToList();
            results.AddRange(congs);

            return Ok(results);
        }
    }
}
