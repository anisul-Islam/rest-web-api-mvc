using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsersService();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(string userId)
        {
            if (!Guid.TryParse(userId, out Guid userIdGuid))
            {
                return BadRequest("Invalid user ID Format");
            }
            var user = _userService.GetUserById(userIdGuid);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }

        }

        [HttpPost]
        public IActionResult CreateUser(User newUser)
        {
            var createdUser = _userService.CreateUserService(newUser);
            return CreatedAtAction(nameof(GetUser), new { userId = createdUser.UserId }, createdUser);
        }


        [HttpPut("{userId}")]
        public IActionResult UpdateUser(string userId, User updateUser)
        {
            if (!Guid.TryParse(userId, out Guid userIdGuid))
            {
                return BadRequest("Invalid user ID Format");
            }
            var user = _userService.UpdateUserService(userIdGuid, updateUser);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(string userId)
        {
            if (!Guid.TryParse(userId, out Guid userIdGuid))
            {
                return BadRequest("Invalid user ID Format");
            }
            var result = _userService.DeleteUserService(userIdGuid);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}