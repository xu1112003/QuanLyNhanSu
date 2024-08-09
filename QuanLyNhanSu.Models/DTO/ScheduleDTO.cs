using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models.DTO
{
    public class ScheduleDTO
    {
        public int ScheduleId { get; set; }

   
        public DateTime WorkingDate { get; set; }

     
        public string MorningActivity { get; set; }

     
        public string AfternoonActivity { get; set; }

  
        public string EveningActivity { get; set; }

        public int? EmployeeId { get; set; }

    }
}
