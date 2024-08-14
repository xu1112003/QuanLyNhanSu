using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Business.Interfaces;
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

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        // GET: api/Account/{id}
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

        // POST: api/Account
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount([FromBody] AccountDTO accountDto)
        {
            var account = new Account
            {
                AccountId = accountDto.AccountId,
                Username = accountDto.Username,
                Email = accountDto.Email,
                Password = accountDto.Password,
                ConfirmPassword = accountDto.ConfirmPassword,
                Role = accountDto.Role
                // Employee is not included, so leave it as null or handle it as needed
            };
            var createdAccount = await _accountService.CreateAccountAsync(account);
            return CreatedAtAction(nameof(GetAccount), new { id = createdAccount.AccountId }, createdAccount);
        }

        // PUT: api/Account/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, [FromBody] AccountDTO accountDto)
        {
            var account = new Account
            {
                AccountId = id,
                Username = accountDto.Username,
                Email = accountDto.Email,
                Password = accountDto.Password,
                ConfirmPassword = accountDto.ConfirmPassword,
                Role = accountDto.Role
                // Employee is not included, so leave it as null or handle it as needed
            };
            try
            {
                await _accountService.UpdateAccountAsync(id, account);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Account/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                await _accountService.DeleteAccountAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
