using Microsoft.EntityFrameworkCore;

namespace bear_tabletop_basics.Data.Infrastructure.Initializers;

public class EfMigrateInitializer : IDatabaseInitializer
{
    private readonly BtbContext _context;
    public EfMigrateInitializer(BtbContext context) => _context = context;
    public Task InitializeAsync() => _context.Database.MigrateAsync();
}