using Microsoft.EntityFrameworkCore;

namespace grpc_dotnet
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hello> Hellos { get; set; }
    }
}