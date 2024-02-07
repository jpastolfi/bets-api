using Bets.Odds.Models;
using Microsoft.EntityFrameworkCore;

namespace Bets.Odds.Repository;

public class BetsContext : DbContext, IBetsContext
{
    public BetsContext(DbContextOptions<BetsContext> options) : base(options) { }
    public BetsContext() { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<Match> Matches { get; set; } = null!;
    public DbSet<Bet> Bets { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=127.0.0.1;Database=Bets;User=SA;Password=Bets123456!;TrustServerCertificate=true";
        optionsBuilder.UseSqlServer(connectionString);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Team>()
            .HasMany(t => t.MatchesA)
            .WithOne(m => m.MatchTeamA)
            .HasForeignKey(m => m.MatchTeamAId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Team>()
            .HasMany(t => t.MatchesB)
            .WithOne(m => m.MatchTeamB)
            .HasForeignKey(m => m.MatchTeamBId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Bets)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);

        modelBuilder.Entity<Match>()
            .HasMany(m => m.Bets)
            .WithOne(b => b.Match)
            .HasForeignKey(b => b.MatchId);

        modelBuilder.Entity<Team>()
            .HasMany(t => t.Bets)
            .WithOne(b => b.Team)
            .HasForeignKey(b => b.TeamId);

    }

}