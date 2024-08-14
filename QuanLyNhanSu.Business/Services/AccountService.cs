using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Data.Context;
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
        private readonly QLNSContext _context;

        public AccountService(QLNSContext context)
        {
            _context = context;
        }
        public async Task<Account> CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new KeyNotFoundException("Account not found");
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task UpdateAccountAsync(int id, Account account)
        {
            if (id != account.AccountId)
            {
                throw new ArgumentException("Account ID mismatch");
            }

            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
