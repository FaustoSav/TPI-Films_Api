using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Models;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FilmsAPI.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly MediaContext _mediaContext;

        public UserService(MediaContext consultaContext)
        {
            _mediaContext = consultaContext;
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
                    response.Message = "Loging succesfull";
                }
                else
                {
                    response.Result = false;
                    response.Message = "Wrong password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "Wrong email";
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



    }
}
