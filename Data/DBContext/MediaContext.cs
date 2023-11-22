using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPI.Data.DBContext
{
    public class MediaContext : DbContext
    {
        public MediaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serie> Series { get; set; }

        public DbSet<FavoriteMedia> FavoritesMedia { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavoritesMedia)
                .WithOne(fs => fs.User);


            modelBuilder.Entity<User>().HasData(
              new User
              {
                  LastName = "Farias",
                  Name = "Franco",
                  Email = "fariasfranco@gmail.com",
                  UserName = "FrancoFarias",
                  Password = "123456",
                  Id = 1,
                  UserType = "Admin"
              },
               new User
               {
                   LastName = "Savoya",
                   Name = "Fausto",
                   Email = "savoyafausto@gmail.com",
                   UserName = "FaustoSav",
                   Password = "123456",
                   Id = 2,
                   UserType = "Admin"
               },
               new User
               {
                   LastName = "Garcia",
                   Name = "Pedro",
                   Email = "pgarcia@gmail.com",
                   UserName = "pgarcia",
                   Password = "123456",
                   Id = 3,
                   UserType = "RegularUser"
               }); ;



            //Se generan 10 peliculas de test, para tener una base
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Movie>().HasData(
                    new Movie
                    {

                        Title = $"Pelicula {i}",
                        Description = $"Descripción de la película {i}",
                        Genre = Genre.Action,
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

                        Title = $"Serie {i}",
                        Seasons = i + 1,
                        Description = $"Descripción de la serie {i}",
                        Genre = Genre.Comedy,
                        Episodes = i + 3

                    }
                );
            }

            modelBuilder.Entity<FavoriteMedia>().HasDiscriminator(fm => fm.MediaType);

            modelBuilder.Entity<FavoriteMedia>()
         .HasOne(fm => fm.User)
         .WithMany(u => u.FavoritesMedia);


            //garantiza que cualquier configuración predeterminada proporcionada por Entity Framework Core se aplique antes de aplicar tus propias configuraciones personalizadas.
            base.OnModelCreating(modelBuilder);

        }
    }
}
