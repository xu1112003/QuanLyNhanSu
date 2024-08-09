using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Data.Interfaces;
using QuanLyNhanSu.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Business.Services
{
    public class ScheduleService : IScheduleService
    {
        private IBaseRepository<Schedule> _scheduleRepository;
        public ScheduleService(IBaseRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task AddScheduleAsync(Schedule schedule)
        {
            await _scheduleRepository.AddAsync(schedule);
        }

        public async Task DeleteScheduleAsync(int id)
        {
            await _scheduleRepository.DeleteAsync(id);
        }

        public async Task<Schedule> GetScheduleByIdAsync(int id)
        {
            return await _scheduleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesAsync()
        {
            return await _scheduleRepository.GetAllAsync();
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            await _scheduleRepository.UpdateAsync(schedule);
        }
        public async Task<IEnumerable<Schedule>> GetSchedulesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _scheduleRepository.GetSchedulesByDateRangeAsync(startDate, endDate);
        }
    }

    
}
