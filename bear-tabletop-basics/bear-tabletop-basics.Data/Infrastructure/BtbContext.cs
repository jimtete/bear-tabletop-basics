using bear_tabletop_basics.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace bear_tabletop_basics.Data.Infrastructure;

public class BtbContext : DbContext
{
    public DbSet<Player>  Players { get; set; }

    public BtbContext(DbContextOptions<BtbContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite(ConnectionString.BtbDataSqlite());
    }
}