using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Models;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FilmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {


        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetAllUsers);
        }

        [HttpGet("email")]
        public IActionResult GetUserByEmail([FromQuery] string email)
        {

            User? user = _userService.GetUserByEmail(email);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

       
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserPostDto userDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {

                var user = new RegularUser()
                {
                    Email = userDto.Email,
                    LastName = userDto.LastName,
                    Name = userDto.Name,
                    Password = userDto.Password,
                    UserType = "RegularUser",
                    UserName = userDto.UserName,
                };

                int id = _userService.CreateUser(user);
                return Ok(id);
            }

            return Forbid("No tenes los permisos necesarios para realizar la solicitud");

        }


        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateDto userUpdateDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();

            if (role == "Admin")
            {

                var user = new RegularUser()
                {
                    Id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    LastName = userUpdateDto.LastName,
                    Name = userUpdateDto.Name,
                    Password = userUpdateDto.Password,
                    UserType = "RegularUser",
                    UserName = userUpdateDto.UserName,
                };

                _userService.UpdateUser(user);
                return Ok();
            }

            return Forbid("No tenes los permisos necesarios para realizar la solicitud");


        }

        [HttpDelete]

        public IActionResult DeleteUser()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _userService.DeleteUser(id);
            return NoContent();


        }

    }
}
