using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Data.Interfaces;
using QuanLyNhanSu.Data.Repositories;
using QuanLyNhanSu.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Business.Services
{
    public class HeSoService :BaseService<Position>, IHeSoService
    {
        private readonly IHeSorepository _heSoRepository;

        public HeSoService(IHeSorepository heSoRepository) :base(heSoRepository) 
        {
            _heSoRepository = heSoRepository;
        }
    }
}
