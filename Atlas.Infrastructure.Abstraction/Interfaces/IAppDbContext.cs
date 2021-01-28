using System.Threading;
using System.Threading.Tasks;
using Atlas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Infrastructure.Abstraction.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<RacingClass> RacingClasses { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Migrate();
    }
}
