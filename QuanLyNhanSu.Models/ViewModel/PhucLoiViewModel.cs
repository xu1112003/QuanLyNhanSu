using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models.ViewModel
{
    public class PhucLoiViewModel
    {
        public int PhucLoiId { get; set; }
        public string PhucLoiType { get; set; }
        public decimal Money { get; set; }
    }
}
