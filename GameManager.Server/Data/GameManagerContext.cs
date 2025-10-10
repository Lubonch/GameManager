using Microsoft.EntityFrameworkCore;
using GameManager.Server.Models;

namespace GameManager.Server.Data;

public class GameManagerContext : DbContext
{
    public GameManagerContext(DbContextOptions<GameManagerContext> options) : base(options) { }

    public DbSet<Game> Games { get; set; }
    public DbSet<Console> Consoles { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<People> Peoples { get; set; }
    public DbSet<LoginTable> LoginTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Publisher)
            .WithMany()
            .HasForeignKey(g => g.PublisherId);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Console)
            .WithMany()
            .HasForeignKey(g => g.ConsoleId);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Genre)
            .WithMany()
            .HasForeignKey(g => g.GenreId);
    }
}