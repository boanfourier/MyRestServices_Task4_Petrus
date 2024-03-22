using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BusinessLogic.Interfaces;
using MyRESTServices.Helpers;
using MyRESTServices.Models;

namespace MyRESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly AppSettings _AppSettings;

        public UserController(IUserBLL userBLL, IConfiguration configuration, AppSettings appSettings)
        {
            _userBLL = userBLL;
            _AppSettings = appSettings;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userBLL.GetUserWithRoles(loginDTO.Username);
            if (user == null) return Unauthorized();

            var roles = user.Roles.Select(r => r.RoleName);
            var token = _AppSettings.GenerateJwtToken(user, roles);

            return Ok(new
            {
                Token = token,
                Username = user.Username,
                Roles = roles
            });
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO model)
        {
            if (string.IsNullOrEmpty(model.Username)) return BadRequest("Username is required.");

            var success = await _userBLL.ChangePassword(model.Username, model.NewPassword);
            if (!success) return BadRequest("Failed to change password.");

            return Ok("Password changed successfully.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers() => Ok(await _userBLL.GetAllUsers());

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = await _userBLL.GetUserByUsername(username);
            if (user == null) return NotFound();

            return Ok(user);
        }
    }
}
