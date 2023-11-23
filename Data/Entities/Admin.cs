namespace FilmsAPI.Data.Entities
{
    public class Admin : User
    {
        public Admin()
        {
            this.UserType = "Admin";
        }

    }
}
