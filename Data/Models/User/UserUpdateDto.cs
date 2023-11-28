using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Models.User
{
    public class UserUpdateDto
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public string UserName { get; set; }
    }
}
