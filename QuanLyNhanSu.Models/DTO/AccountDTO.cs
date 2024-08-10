using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }

        
        public string Username { get; set; }

       
        public string Email { get; set; }

      
        public string Password { get; set; }

        
        public string ConfirmPassword { get; set; }

      
        public string Role { get; set; }
    }
}
