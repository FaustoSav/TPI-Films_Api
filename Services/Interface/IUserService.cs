using FilmsAPI.Data.Entities;

namespace FilmsAPI.Services.Interface
{
    public interface IUserService
    {


        public User? GetUserByEmail(string email);
        public int CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);

        
    }
}
