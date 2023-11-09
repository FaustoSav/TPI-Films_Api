using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPI.Data.DBContext
{
    public class FilmsContext : DbContext
    {
        public FilmsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            //Se generan 10 peliculas de test, para tener una base
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Movie>().HasData(
                    new Movie
                    {

                        Title = $"Pelicula {i}",
                        Description = $"Descripción de la película {i}",
                        Genre = Genre.Action
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


                // Configuración de la relación muchos a muchos entre User y Movie
                modelBuilder.Entity<User>()
            .HasMany(u => u.Movies)
            .WithMany()
            .UsingEntity(j => j.ToTable("UserMovies"));

                // Configuración de la relación muchos a muchos entre User y Serie
                modelBuilder.Entity<User>()
              .HasMany(u => u.Series)
              .WithMany()
              .UsingEntity(j => j.ToTable("UserSeries"));
            }

            //garantiza que cualquier configuración predeterminada proporcionada por Entity Framework Core se aplique antes de aplicar tus propias configuraciones personalizadas.
            base.OnModelCreating(modelBuilder);

        }
    }
}
