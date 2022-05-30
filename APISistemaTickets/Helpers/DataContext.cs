using APISistemaTickets.Data.Models;
using APISistemaTickets.Data.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace APISistemaTickets.Helpers;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server database
        options
            .UseLazyLoadingProxies()
            .UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<KnowledgeBaseArticle> KnowledgeBaseArticles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}