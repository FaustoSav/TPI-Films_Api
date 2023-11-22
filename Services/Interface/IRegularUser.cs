using FilmsAPI.Data.Entities;

namespace FilmsAPI.Services.Interface
{
    public interface IRegularUser
    {

        public List<User> GetAllRegularUsers();
    }
}
