using bear_tabletop_basics.Data.Infrastructure;
using bear_tabletop_basics.Data.Infrastructure.Initializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace bear_tabletop_basics.Platform.Infastructure;

public static class AppHostBuilder
{
    public static IHost Build() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddDbContext<BtbContext>(opt =>
                    opt.UseSqlite(ConnectionString.BtbDataSqlite()));

                services.AddSingleton<IDatabaseInitializer, EfMigrateInitializer>();
                services.AddTransient<MainWindow>();
            })
            .Build();
}