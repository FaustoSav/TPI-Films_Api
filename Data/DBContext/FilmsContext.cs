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

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<RegularUser> RegularUsers { get; set; }

        public DbSet<Film> Films { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serie> Series { get; set; }

        public DbSet<FavoriteSerie> FavoritesSeries { get; set; }
        public DbSet<FavoriteMovie> FavoritesMovies { get; set; }


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
                        Genre = Genres.Action,
                        Duration = i + 100,
                        FilmType = FilmType.Movie
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
                        Genre = Genres.Comedy,
                        Episodes = i + 3,
                        FilmType= FilmType.Serie
                    }
                );

                modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType)
                                    .HasValue<Admin>(UserType.Admin)
                                    .HasValue<RegularUser>(UserType.RegularUser);

                // Configuración de relaciones entre User y FavoriteSerie/FavoriteMovie
                modelBuilder.Entity<User>()
                    .HasMany(u => u.FavoriteSeries)
                    .WithOne(fs => fs.User)
                    .HasForeignKey(fs => fs.UserId);

                modelBuilder.Entity<User>()
                    .HasMany(u => u.FavoriteMovies)
                    .WithOne(fm => fm.User)
                    .HasForeignKey(fm => fm.UserId);

                // Configuración de relaciones entre FavoriteSerie y Serie
                modelBuilder.Entity<FavoriteSerie>()
                    .HasOne(fs => fs.Serie)
                    .WithMany(s => s.Favorites)
                    .HasForeignKey(fs => fs.SerieId);

                // Configuración de relaciones entre FavoriteMovie y Movie
                modelBuilder.Entity<FavoriteMovie>()
                    .HasOne(fm => fm.Movie)
                    .WithMany(m => m.Favorites)
                    .HasForeignKey(fm => fm.MovieId);




                //garantiza que cualquier configuración predeterminada proporcionada por Entity Framework Core se aplique antes de aplicar tus propias configuraciones personalizadas.
                base.OnModelCreating(modelBuilder);

        }
    }
}
