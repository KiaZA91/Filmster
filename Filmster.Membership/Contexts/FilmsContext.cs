using Filmster.Membership.Database.Entities;
using static System.Net.WebRequestMethods;

namespace Filmster.Membership.Database
{
    public class FilmContext : DbContext
    {
        public DbSet<Director> Directors => Set<Director>();
        public DbSet<Film> Films => Set<Film>();
        public DbSet<FilmGenre> FilmGenres => Set<FilmGenre>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<SimilarFilm> SimilarFilms => Set<SimilarFilm>();


        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Composit Keys 
            modelBuilder.Entity<SimilarFilm>().HasKey(ci => new { ci.FilmId, ci.SimilarFilmId });
            modelBuilder.Entity<FilmGenre>().HasKey(ci => new { ci.FilmId, ci.GenreId });

            modelBuilder.Entity<Film>(entity =>
            {
                entity
                    .HasMany(d => d.SimilarFilms)
                    .WithOne(p => p.Film)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.Genres)
                      .WithMany(p => p.Films)
                      .UsingEntity<FilmGenre>()
                      .ToTable("FilmGenres");
            });

            // Seed Data 
            modelBuilder.Entity<Director>().HasData(
                new { Id = 1, Name = "Kia Ala" });

            modelBuilder.Entity<Film>().HasData(
                new { Id = 1, Title = "Spiderman", DirectorId = 1 , FilmUrl = "https://www.youtube.com/watch?v=JqcncLPi9zw" },
                new { Id = 2, Title = "Batman", DirectorId = 1 , FilmUrl = "https://www.youtube.com/watch?v=mqqft2x_Aa4"},
                new { Id = 3, Title = "The Hulk", DirectorId = 1, FilmUrl = "https://www.youtube.com/watch?v=udKE1ksKWDE" });

            modelBuilder.Entity<SimilarFilm>().HasData(
                new SimilarFilm { FilmId = 1, SimilarFilmId = 2 },
                new SimilarFilm { FilmId = 1, SimilarFilmId = 3 });

            modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Sci-Fi" });

            modelBuilder.Entity<FilmGenre>().HasData(
                new FilmGenre { FilmId = 1, GenreId = 1 },
                new FilmGenre { FilmId = 3, GenreId = 1 });
        }
    
    }
}



