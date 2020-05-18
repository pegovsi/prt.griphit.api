using Microsoft.EntityFrameworkCore;

namespace Prt.Graphit.Persistence
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
            => new AppDbContext(options);
    }
}
