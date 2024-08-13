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
    public class HeSoRepository : BaseRepository<Position>, IHeSorepository
    {
        private readonly QLNSContext _context;

        public HeSoRepository(QLNSContext context) : base(context) { }
    }
}
