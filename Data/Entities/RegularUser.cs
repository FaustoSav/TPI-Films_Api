using System.Runtime.CompilerServices;

namespace FilmsAPI.Data.Entities
{
    public class RegularUser : User
    {

      public RegularUser() {
            this.UserType = "RegularUser";
        }
    }
}
