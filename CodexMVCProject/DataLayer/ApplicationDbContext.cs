using CodexMVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CodexMVCProject.DataLayer;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
           /* optionsBuilder.UseNpgsql("Server=abul.db.elephantsql.com;Port=5432;Database=eozukkfz;Username=eozukkfz;Password=2Bt3O5UFqVAIfDTUibtyk0o7hgBZOJtA");*/
           optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));

        }
    }

    public DbSet<Product> Products { get; set; }
}
