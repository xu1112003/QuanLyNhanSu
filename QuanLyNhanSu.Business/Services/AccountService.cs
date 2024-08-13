using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Data.Interfaces;
using QuanLyNhanSu.Data.Repositories;
using QuanLyNhanSu.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Business.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository<Account> _accountRepository;
        public AccountService(IAccountRepository<Account> accountRepositoty)
        {
            _accountRepository = accountRepositoty;
        }
        public async Task AddAccountAsync(Account account)
        {
            await _accountRepository.AddAsync(account);
        }

        public async Task DeleteAccountAsync(int id)
        {
            await _accountRepository.DeleteAsync(id);
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            await _accountRepository.UpdateAsync(account);
        }
    }
}
