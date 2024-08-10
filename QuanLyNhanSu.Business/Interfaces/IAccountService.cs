using QuanLyNhanSu.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Business.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountByIdAsync(int id);
        Task AddAccountAsync(Account schedule);
        Task UpdateAccountAsync(Account schedule);
        Task DeleteAccountAsync(int id);
    }
}
