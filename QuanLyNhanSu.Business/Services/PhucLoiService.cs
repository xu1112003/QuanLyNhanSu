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
    public class PhucLoiService :BaseService<PhucLoi>, IPhucLoiService
    {
        private readonly IPhucLoiRepository _phucLoiRepository;
        public PhucLoiService(IPhucLoiRepository phucLoiRepository) : base(phucLoiRepository)
        {
            _phucLoiRepository = phucLoiRepository;
        }  
    }
}
