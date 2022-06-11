using Microsoft.EntityFrameworkCore;

namespace APISistemaTickets.Modules.Helpers;

public class SqliteDataContext : DataContext
{
    public SqliteDataContext(IConfiguration configuration) : base(configuration) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options
            .UseLazyLoadingProxies()
            .UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }
}