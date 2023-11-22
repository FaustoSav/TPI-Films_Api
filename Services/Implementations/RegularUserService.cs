using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Services.Interface;

namespace FilmsAPI.Services.Implementations
{
    public class RegularUserService : IRegularUser
    {
        private readonly MediaContext _mediaContext;

        public RegularUserService(MediaContext mediaContext)
        {
            _mediaContext = mediaContext;
        }


        public List<User> GetAllRegularUsers()
        {
            return _mediaContext.Users.Where(p => p.UserType == "RegularUser").ToList();
        }
    }
}
