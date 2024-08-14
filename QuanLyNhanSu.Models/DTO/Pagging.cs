using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models.DTO
{
    public class Pagging<T>
    {
        public int totalRecord { get; set; }

        public int totalPages { get; set; }

        public IEnumerable<T> data { get; set; }

        public int pageIndex { get; set; }

        public int pageSize { get; set; }
    }
}
