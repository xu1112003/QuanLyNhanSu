﻿using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Data.Context;
using QuanLyNhanSu.Data.Interfaces;
using QuanLyNhanSu.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Data.Repositories
{
    public class ScheduleRepository<T> : IScheduleRepository<T> where T : class
    {
        private readonly QLNSContext _context;
        private readonly DbSet<T> _dbSet;
        public ScheduleRepository(QLNSContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Schedule>> GetSchedulesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Schedules
                .Where(s => s.WorkingDate <= endDate && s.WorkingDate >= startDate)
                .ToListAsync();
        }

    }
}
