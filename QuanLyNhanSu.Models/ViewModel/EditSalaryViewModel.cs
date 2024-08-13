using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models.ViewModel
{
    public class EditSalaryViewModel
    {
        public string SalaryType { get; set; }
        public decimal Money { get; set; }
    }
}
