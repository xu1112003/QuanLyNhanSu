using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models.DTO
{
    public class PositionDTO
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public decimal HeSo { get; set; }

    }
}
