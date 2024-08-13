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
    public class SalaryService : BaseService<Salary>, ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService (ISalaryRepository salaryRepository) : base(salaryRepository) 
        {
            _salaryRepository = salaryRepository;
        }
    }
}
