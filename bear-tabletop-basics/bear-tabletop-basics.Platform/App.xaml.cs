using System.Configuration;
using System.Data;
using System.Windows;
using bear_tabletop_basics.Data.Infrastructure.Initializers;
using bear_tabletop_basics.Platform.Infastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace bear_tabletop_basics.Platform;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost Host { get; private set; } = null!;

    public App() => Host = AppHostBuilder.Build();

    protected override async void OnStartup(StartupEventArgs e)
    {
        await Host.StartAsync();

        using var scope = Host.Services.CreateScope();
        var init = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
        await init.InitializeAsync(); // <-- DB created/updated here
        var main = scope.ServiceProvider.GetRequiredService<MainWindow>();
        main.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await Host.StopAsync();
        Host.Dispose();
        base.OnExit(e);
    }
}