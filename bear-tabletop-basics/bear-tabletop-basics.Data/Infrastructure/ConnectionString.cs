namespace bear_tabletop_basics.Data.Infrastructure;

public static class ConnectionString
{
    public static string BtbDataSqlite()
    {
        var dir = GetBtbDataFolder();
        var dbPath = Path.Combine(dir, "btb-db.db");
        return $"Data Source={dbPath};";
    }
    
    private static string GetBtbDataFolder()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var btbFolder = Path.Combine(appData, "btb-data");

        if (!Directory.Exists(btbFolder))
        {
            Directory.CreateDirectory(btbFolder);
        }

        return btbFolder;
    }
}