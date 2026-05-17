using Microsoft.EntityFrameworkCore;

namespace project01
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Watchlist>()
                .HasKey(w => new { w.UserId, w.MovieId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=MovieStreamingDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }
    }
}