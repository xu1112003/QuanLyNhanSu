using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Business.Services;
using QuanLyNhanSu.Models.DTO;
using QuanLyNhanSu.Models.Entities;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            var account = await _accountService.GetAccountsAsync();
            return Ok(account);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpPost]
        public async Task<ActionResult> CreateAccount([FromBody] AccountDTO accountDTO)
        {
            if (accountDTO == null)
            {
                return BadRequest();
            }

            // Kiểm tra xem EmployeeId có tồn tại trong bảng Employee không
            //var employeeExists = await _context.Employees.AnyAsync(e => e.Id == scheduleDTO.EmployeeId);
            //if (!employeeExists)
            //{
            //    return NotFound("Employee not found.");
            //}
            var account = new Account
            {
                AccountId = accountDTO.AccountId,
                Username = accountDTO.Username,
                Email = accountDTO.Email,
                Password = accountDTO.Password,
                ConfirmPassword = accountDTO.ConfirmPassword

            };
            await _accountService.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetAccount), new { id = account.AccountId }, account);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Account>> UpdateAccount(int id, AccountDTO accountDTO)
        {
            if (id != accountDTO.AccountId)
            {
                return BadRequest();
            }
            var existingAccount = await _accountService.GetAccountByIdAsync(id);
            if (existingAccount == null)
            {
                return NotFound();
            }

            existingAccount.Username = accountDTO.Username;
            existingAccount.Email = accountDTO.Email;
            existingAccount.Password = accountDTO.Password;
            existingAccount.ConfirmPassword = accountDTO.ConfirmPassword;

            await _accountService.UpdateAccountAsync(existingAccount);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            await _accountService.DeleteAccountAsync(id);
            return NoContent();
        }
        
    }
}
