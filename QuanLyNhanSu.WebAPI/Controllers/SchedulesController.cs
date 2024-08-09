using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Business.Services;
using QuanLyNhanSu.Models.DTO;
using QuanLyNhanSu.Models.Entities;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules() {
            var schedule = await _scheduleService.GetSchedulesAsync();
            return Ok(schedule);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(int id)
        {
            var schedule = await _scheduleService.GetScheduleByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }
        [HttpPost]
        public async Task<ActionResult> CreateSchedules([FromBody] ScheduleDTO scheduleDTO)
        {
            if (scheduleDTO == null)
            {
                return BadRequest("Schedule object is null.");
            }

            // Kiểm tra xem EmployeeId có tồn tại trong bảng Employee không
            //var employeeExists = await _context.Employees.AnyAsync(e => e.Id == scheduleDTO.EmployeeId);
            //if (!employeeExists)
            //{
            //    return NotFound("Employee not found.");
            //}
            var schedule = new Schedule
            {
                ScheduleId = scheduleDTO.ScheduleId,
                WorkingDate = scheduleDTO.WorkingDate,
                MorningActivity = scheduleDTO.MorningActivity,
                AfternoonActivity = scheduleDTO.AfternoonActivity,
                EveningActivity = scheduleDTO.EveningActivity,
                EmployeeId = scheduleDTO.EmployeeId
            };
            await _scheduleService.AddScheduleAsync(schedule);
            return CreatedAtAction(nameof(GetSchedule), new { id = schedule.ScheduleId }, schedule);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Schedule>> UpdateSchedule(int id, ScheduleDTO scheduleDTO)
        {
            if (id != scheduleDTO.ScheduleId)
            {
                return BadRequest();
            }
            var existingSchedule = await _scheduleService.GetScheduleByIdAsync(id);
            if (existingSchedule == null)
            {
                return NotFound();
            }
            existingSchedule.ScheduleId = scheduleDTO.ScheduleId;
            existingSchedule.WorkingDate = scheduleDTO.WorkingDate;
            existingSchedule.MorningActivity = scheduleDTO.MorningActivity;
            existingSchedule.AfternoonActivity = scheduleDTO.AfternoonActivity;
            existingSchedule.EveningActivity = scheduleDTO.EveningActivity;
           
            await _scheduleService.UpdateScheduleAsync(existingSchedule);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSchedule(int id)
        {
            await _scheduleService.DeleteScheduleAsync(id);
            return NoContent();
        }
    }
}
