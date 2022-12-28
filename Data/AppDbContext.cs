using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am =>
                new
                {
                    am.ActorId,
                    am.MovieId
                });

            // Defign Actor_Movie as the join table
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.ActorMovies)
                .HasForeignKey(m => m.MovieId);
            
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.ActorMovies)
                .HasForeignKey(m => m.ActorId);
  
            base.OnModelCreating(modelBuilder);
        }

        
        // Define the table names of the models
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> ActorMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }




    }
}