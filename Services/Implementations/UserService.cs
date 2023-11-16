using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FilmsAPI.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly FilmsContext _filmContextl;

            public UserService(FilmsContext filmContext)
        {
            _filmContextl = filmContext;
        }

        public User? GetUserByEmail(string email)
        {
            User user = new User();

            return user;
        }
        public int CreateUser(User user)
        {
            return 1;
        }
        public void UpdateUser(User user)
        {

        }
        public void DeleteUser(int userId)
        {

        }

        void AddToFavorites(int userId, Film film)
        {

        }
        void RemoveFromFavorites(int userId, Film film)
        {

        }



    }
}
