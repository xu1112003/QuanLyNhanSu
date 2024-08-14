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
    public class PositionService : IPositionService
    {
        private readonly IBaseRepository<Position> _positionService;
        public PositionService(IBaseRepository<Position> positionService)
        {
            _positionService = positionService;
        }
        public async Task AddPositionAsync(Position position)
        {
            await _positionService.AddAsync(position);
        }

        public async Task DeletePositionAsync(int id)
        {
            await _positionService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await _positionService.GetAllAsync();
        }

        public Task<Position> GetPositionByIdAsync(int id)
        {
            return _positionService.GetByIdAsync(id);
        }

        public async Task UpdatePositionAsync(Position position)
        {
            await _positionService.UpdateAsync(position);
        }
    }
}
