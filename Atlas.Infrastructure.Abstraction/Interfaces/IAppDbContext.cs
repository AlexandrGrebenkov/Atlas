using System.Threading;
using System.Threading.Tasks;
using Atlas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Infrastructure.Abstraction.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<RacingClass> Measures { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
