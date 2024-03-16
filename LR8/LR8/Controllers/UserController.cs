using LR8.Models;
using LR8.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LR8.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync(User user)
        {
            try
            {
                var newUser = await _userService.AddUserAsync(user);
                return CreatedAtAction(nameof(GetUserByIdAsync), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, User user)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(id, user);
                if (updatedUser == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("users/{id}")]
        public async Task<ActionResult<User>> DeleteUserAsync(int id)
        {
            try
            {
                var deletedUser = await _userService.DeleteUserAsync(id);
                if (deletedUser == null)
                {
                    return NotFound();
                }
                return deletedUser;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
