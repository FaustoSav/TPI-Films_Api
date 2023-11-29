using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Models.User;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FilmsAPI.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly MediaContext _mediaContext;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserService(MediaContext mediaContext, IHttpContextAccessor httpContextAccessor)
        {
            _mediaContext = mediaContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<User> GetAllUsers()
        {
            return _mediaContext.Users.Where(u => u.State == true ).ToList();
        }
        public User? GetUserByEmail(string email)
        {
            return _mediaContext.Users.SingleOrDefault(u => u.Email == email);
        }
        public BaseResponse ValidarUsuario(string email, string password)
        {
            BaseResponse response = new BaseResponse();
            User? userForLogin = _mediaContext.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "loging Succesfull";
                }
                else
                {
                    response.Result = false;
                    response.Message = "wrong password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }


        public int CreateUser(User user)
        {
            _mediaContext.Add(user);
            _mediaContext.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(User user)
        {
            _mediaContext.Update(user);
            _mediaContext.SaveChanges();

        }

        public void DeleteUser(int userId)
        {
            User? userToDelete = _mediaContext.Users.FirstOrDefault(u => u.Id == userId);
            userToDelete.State = false;
            _mediaContext.Update(userToDelete);
            _mediaContext.SaveChanges();

        }

        public User? GetUserById(int userId)
        {
            return _mediaContext.Users.SingleOrDefault(u => u.Id == userId && u.State);

        }

        public int? GetCurrentUser()
        {

            var userIdString = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return userIdString != null ? int.Parse(userIdString) : (int?)null;

        }

    }
}
