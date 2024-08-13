using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models.ViewModel
{
    public class GetCongViewModel
    {
        public int CongId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime NgayCham { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public string Status { get; set; }
    }
}
