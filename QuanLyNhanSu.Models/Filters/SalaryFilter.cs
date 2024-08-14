using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models.Filters
{
    public class SalaryFilter
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 2;

        //public string Filter { get; set; } = "";

        public string? SalaryType { get; set; } = null;
    }
}
