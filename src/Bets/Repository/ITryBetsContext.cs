using Bets.Models;
using Microsoft.EntityFrameworkCore;

namespace Bets.Repository;

public interface IBetsContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Bet> Bets { get; set; }
    public int SaveChanges();
}