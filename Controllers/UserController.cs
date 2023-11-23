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
        public IActionResult GetAllUsers()
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

        //public int CreateUser(User user);
        //public void UpdateUser(User user);
        //public void DeleteUser(int userId);



        //public  Name 
        //public  LastName 
        //public  Password
        //public  Email 
        //public  UserName 
        //public  UserType 
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserPostDto userDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {

                var user = new User()
                {
                    Email = userDto.Email,
                    LastName = userDto.LastName,
                    Name = userDto.Name,
                    Password = userDto.Password,
                    UserType = userDto.UserType,
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

                var user = new User()
                {
                    Id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    LastName = userUpdateDto.LastName,
                    Name = userUpdateDto.Name,
                    Password = userUpdateDto.Password,
                    UserType = userUpdateDto.UserType,
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
