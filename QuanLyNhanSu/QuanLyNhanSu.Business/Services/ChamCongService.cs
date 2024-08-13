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
    public class ChamCongService : IChamCongService
    {
        private readonly IBaseRepository<Cong> _repository;
        public ChamCongService(IBaseRepository<Cong> baseRepository)
        {
            _repository = baseRepository;
        }

        public async Task AddCongAsync(Cong cong)
        {
            await _repository.AddAsync(cong);
        }

        public async Task DeleteCongAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Cong>> GetAllCongAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Cong> GetCongByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateCongAsync(Cong cong)
        {
            await _repository.UpdateAsync(cong);
        }
    }
}
