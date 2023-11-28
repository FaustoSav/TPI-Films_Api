using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Models.User;

namespace FilmsAPI.Services.Interface
{
    public interface IUserService
    {

        public BaseResponse ValidarUsuario(string username, string password);
        public List<User> GetAllUsers();
        public User? GetUserByEmail(string email);
        public User? GetUserById(int id);
        public int CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);

    }
}
