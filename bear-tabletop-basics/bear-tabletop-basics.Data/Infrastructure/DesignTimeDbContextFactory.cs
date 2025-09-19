using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace bear_tabletop_basics.Data.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BtbContext>
{
    public BtbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<BtbContext>()
            .UseSqlite(ConnectionString.BtbDataSqlite())
            .Options;

        return new BtbContext(options);
    }
}