using System.Threading;
using System.Threading.Tasks;

namespace PartyFinder.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task<IDisposable> BeginTransactionAsync(CancellationToken ct = default);
        Task<int> SaveChangesAsync(CancellationToken ct = default);
        Task CommitAsync(CancellationToken ct = default);
    }
}
