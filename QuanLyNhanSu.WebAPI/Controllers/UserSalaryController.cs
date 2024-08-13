using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Data.Context;
using QuanLyNhanSu.Models.Entities;
using QuanLyNhanSu.Models.ViewModel;
using System.Numerics;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSalaryController: ControllerBase 
    {
        private readonly IHeSoService _heSoService;
        private readonly ISalaryService _salaryService;
        private readonly IPhucLoiService _phucLoiService;
        private readonly QLNSContext _context;

        public UserSalaryController(IHeSoService heSoService, ISalaryService salaryService, IPhucLoiService phucLoiService, QLNSContext context)
        {
            _heSoService = heSoService;
            _salaryService = salaryService;
            _phucLoiService = phucLoiService;
            _context = context;
        }

        [HttpGet]
        [Route("GetSalary")]
        public async Task<IEnumerable<Salary>> GetSalary()
        {
            var entities = await _salaryService.GetAllAsync();
            return entities;
        }

        [HttpGet]
        [Route("GetPhucLoi")]
        public async Task<IEnumerable<PhucLoi>> GePhucLoi()
        {
            var entities = await _phucLoiService.GetAllAsync();
            return entities;
        }

        [HttpGet]
        [Route("GetHeSo")]
        public async Task<IEnumerable<GetHeSoViewModel>> GetHeSo()
        {
            var entities = _heSoService.GetAllAsync().Result;
            var heso = new List<GetHeSoViewModel>();
            foreach (var e in entities)
            {
                var h = new GetHeSoViewModel
                {
                    Id = e.PositionId,
                    Name = e.PositionName,
                    HeSo = e.HeSo
                };
                heso.Add(h);
            }
            return heso;
        }

        [HttpGet]
        [Route("Tong")]
        public async Task<UserSalaryViewModel> GetThuNhap()
        {
            decimal all = 0, month = 0;
            foreach(var s in _context.Salaries)
            {
                all += s.Money;
            }
            foreach (var pl in _context.PhucLois)
            {
                all += pl.Money;
            }
            month = Math.Round(all / 12, 0);
            return new UserSalaryViewModel
            {
                Tong = all,
                Monthly = month,
                TongThucLinh = all * 12 / 100,
                Yearly = month *12/100 
            };
        }
    }
}
