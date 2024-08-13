using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models.ViewModel
{
    public class UserSalaryViewModel
    {
        public decimal Tong {  get; set; }
        public decimal Monthly { get; set; }
        public decimal TongThucLinh { get; set; }
        public decimal Yearly { get; set; }
    }
}
