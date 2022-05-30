using APISistemaTickets.Data.Models;
using APISistemaTickets.Data.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace APISistemaTickets.Helpers;

public class SqliteDataContext : DataContext
{
    public SqliteDataContext(IConfiguration configuration) : base(configuration) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }
}