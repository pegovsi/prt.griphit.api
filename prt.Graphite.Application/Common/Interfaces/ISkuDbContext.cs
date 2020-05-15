using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Common.Interfaces
{
    public interface ISkuDbContext
    {
        DbSet<T> Set<T>()
           where T : class;

        DbContext SkuContext { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
