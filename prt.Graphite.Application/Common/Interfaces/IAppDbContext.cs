using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<T> Set<T>()
           where T : class;

        DbContext DbContext { get; }
        DbConnection DbConnection { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> ExecuteSqlRawAsync(string sql, CancellationToken token = default);
    }
}
