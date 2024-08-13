using QuanLyNhanSu.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Business.Interfaces
{
    public interface IChamCongService
    {
        Task<IEnumerable<Cong>> GetAllCongAsync();
        Task<Cong> GetCongByIdAsync(int id);
        Task AddCongAsync(Cong cong);
        Task UpdateCongAsync(Cong cong);
        Task DeleteCongAsync(int id);
    }
}
