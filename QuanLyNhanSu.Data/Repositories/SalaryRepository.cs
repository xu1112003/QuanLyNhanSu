using Microsoft.EntityFrameworkCore;
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
    public class SalaryRepository : BaseRepository<Salary>, ISalaryRepository
    {
        private readonly QLNSContext _context;

        public SalaryRepository(QLNSContext context) : base(context) { }

    }
}
