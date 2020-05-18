using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<T> Set<T>()
           where T : class;

        DbContext SkuContext { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
