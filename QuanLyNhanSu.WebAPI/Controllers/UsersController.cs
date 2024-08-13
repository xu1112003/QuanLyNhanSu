using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Models.DTO;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) {
            _userService = userService;
        }
        //[HttpPost("authenticate")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Autheticate([FromBody] LoginRequest request)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var resultToken = await _userService.Authencate(request);
        //    if(string.IsNullOrEmpty(resultToken))
        //    {
        //        return BadRequest("Username or pasword is incorrect");
        //    }
        //    return Ok(new {token = resultToken});
        //}
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest("Register is unsuccessful");
            }
            return Ok();
        }


    }
}
