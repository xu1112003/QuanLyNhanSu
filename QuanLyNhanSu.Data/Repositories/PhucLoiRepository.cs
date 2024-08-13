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
    public class PhucLoiRepository :BaseRepository<PhucLoi>, IPhucLoiRepository
    {
        private readonly QLNSContext _context;

        public PhucLoiRepository(QLNSContext context) : base(context) { }
    }
}
