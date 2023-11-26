
using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using Microsoft.EntityFrameworkCore;



namespace FilmsAPI.Data.DBContext
{
    public class MediaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteMedia> FavoritesMedia { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RegularUser> RegularUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public MediaContext(DbContextOptions<MediaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.UserType);


            modelBuilder.Entity<Admin>().HasData(
              new Admin
              {
                  LastName = "Farias",
                  Name = "Franco",
                  Email = "fariasfranco@gmail.com",
                  UserName = "FrancoFarias",
                  Password = "123456",
                  Id = 1
              },
               new Admin
               {
                   LastName = "Savoya",
                   Name = "Fausto",
                   Email = "savoyafausto@gmail.com",
                   UserName = "FaustoSav",
                   Password = "123456",
                   Id = 2
               });


            modelBuilder.Entity<RegularUser>().HasData(
                new RegularUser
                {
                    LastName = "Garcia",
                    Name = "Pedro",
                    Email = "regular@gmail.com",
                    UserName = "regular",
                    Password = "123456",
                    Id = 3
                });


            modelBuilder.Entity<User>()
               .HasMany(u => u.FavoritesMedia)
               .WithOne(fs => fs.User);

            //Se generan 10 peliculas de test, para tener una base
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Movie>().HasData(
                    new Movie
                    {
                        MediaId = i,
                        Title = $"Pelicula {i}",
                        Description = $"Descripción de la película {i}",
                        Genre = Genre.Action.ToString(),
                        Duration = i + 100

                    }
                );
            }
            //Se generan 10 series de test, para tener una base
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Serie>().HasData(
                    new Serie
                    {
                        MediaId = i + 10,
                        Title = $"Serie {i}",
                        Seasons = i + 1,
                        Description = $"Descripción de la serie {i}",
                        Genre = Genre.Comedy.ToString(),
                        Episodes = i + 3

                    }
                );
            }

            // modelBuilder.Entity<FavoriteMedia>().HasDiscriminator(fm => fm.MediaType);

            modelBuilder.Entity<FavoriteMedia>()
         .HasOne(fm => fm.User)
         .WithMany(u => u.FavoritesMedia);


            //garantiza que cualquier configuración predeterminada proporcionada por Entity Framework Core se aplique antes de aplicar tus propias configuraciones personalizadas.
            base.OnModelCreating(modelBuilder);
        }
    }
}