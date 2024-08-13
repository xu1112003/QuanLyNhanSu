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
    public class ChamCongsController : ControllerBase
    {
        private readonly IChamCongService _chamCongService;
        public ChamCongsController(IChamCongService chamCongService)
        {
            _chamCongService = chamCongService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cong>>> GetCongs()
        {
            var congs = await _chamCongService.GetAllCongAsync();
            var congsModel = congs.Select(p => new GetCongViewModel
            {
                CongId = p.CongId,
                EmployeeId = p.EmployeeId,
                NgayCham = p.NgayCham,
                CheckIn = p.CheckIn,
                CheckOut = p.CheckOut,
                Status = p.Status,
            });
            return Ok(congsModel);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cong>> GetCong(int id)
        {
            var cong = await _chamCongService.GetCongByIdAsync(id);
            if (cong == null)
            {
                return NotFound();
            }
            var congViewModel = new GetCongViewModel
            {
                CongId = cong.CongId,
                EmployeeId = cong.EmployeeId,
                NgayCham = cong.NgayCham,
                CheckIn = cong.CheckIn,
                CheckOut = cong.CheckOut,
                Status = cong.Status,
            };
            return Ok(congViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCong([FromBody] CongViewModel congViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cong = new Cong
            {
                EmployeeId = congViewModel.EmployeeId,
                NgayCham = congViewModel.NgayCham,
                CheckIn = congViewModel.CheckIn,
                CheckOut = congViewModel.CheckOut,
                Status = congViewModel.Status,
            };
            await _chamCongService.AddCongAsync(cong);
            return CreatedAtAction(nameof(GetCong), new { id = cong.CongId }, cong);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cong>> UpdateCong(int id, [FromBody] CongViewModel congViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingCong = await _chamCongService.GetCongByIdAsync(id);
            if (existingCong == null)
            {
                return NotFound();
            }
            existingCong.EmployeeId = congViewModel.EmployeeId;
            existingCong.NgayCham = congViewModel.NgayCham;
            existingCong.CheckIn = congViewModel.CheckIn;
            existingCong.CheckOut = congViewModel.CheckOut;
            existingCong.Status = congViewModel.Status;

            await _chamCongService.UpdateCongAsync(existingCong);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var existingCong = await _chamCongService.GetCongByIdAsync(id);
            if (existingCong == null)
            {
                return NotFound();
            }
            await _chamCongService.DeleteCongAsync(id);
            return NoContent();
        }
    }
}
