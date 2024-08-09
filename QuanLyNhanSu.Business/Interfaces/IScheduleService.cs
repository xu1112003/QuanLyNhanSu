using QuanLyNhanSu.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Business.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> GetSchedulesAsync();
        Task<Schedule> GetScheduleByIdAsync(int id);
        Task AddScheduleAsync(Schedule schedule);
        Task UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(int id);

    }
}
