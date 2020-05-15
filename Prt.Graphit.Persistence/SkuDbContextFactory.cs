using Microsoft.EntityFrameworkCore;

namespace Prt.Graphit.Persistence
{
    public class SkuDbContextFactory : DesignTimeDbContextFactoryBase<SkuDbContext>
    {
        protected override SkuDbContext CreateNewInstance(DbContextOptions<SkuDbContext> options)
            => new SkuDbContext(options);
    }
}
