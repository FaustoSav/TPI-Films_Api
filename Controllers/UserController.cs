using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Models.User;
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
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                return Ok(_userService.GetAllUsers());

            }
            return Forbid("Permisos insuficientes");

        }

        [HttpGet("{email}")]
        public IActionResult GetUserByEmail([FromQuery] string email)
        {

            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if(role == "Admin")
            {
                User? user = _userService.GetUserByEmail(email);

                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            return Forbid("Permisos insuficientes");

        }


        [HttpPost]
        [Route("CreateRegularUser")]

        public IActionResult CreateRegularUser([FromBody] UserPostDto userDto)
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

            return Forbid("No tenes los permisos necesarios.");

        }
        [HttpPost]
        [Route("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] UserPostDto userDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {

                Admin user = new Admin()
                {
                    Email = userDto.Email,
                    LastName = userDto.LastName,
                    Name = userDto.Name,
                    Password = userDto.Password,
                    UserType = "Admin",
                    UserName = userDto.UserName,
                };

                int id = _userService.CreateUser(user);
                return Ok(id);
            }

            return Forbid("No tenes los permisos necesarios.");

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

            return Forbid("No tenes los permisos necesarios.");


        }

        [HttpDelete("{id}")]

        public IActionResult DeleteUser([FromQuery] int idDelete)
        {

            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();

            if (role == "Admin")
            {
                _userService.DeleteUser(idDelete);

            }

            return Forbid("No tenes los permisos necesarios.");


        }

    }
}
