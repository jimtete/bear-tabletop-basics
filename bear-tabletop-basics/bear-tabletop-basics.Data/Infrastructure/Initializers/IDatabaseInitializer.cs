namespace bear_tabletop_basics.Data.Infrastructure.Initializers;

public interface IDatabaseInitializer
{
    Task InitializeAsync();
}