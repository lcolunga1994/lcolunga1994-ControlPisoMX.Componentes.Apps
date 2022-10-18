namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Domain
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Domain.Entities;

    public interface IUnitOfWork
    {
        #region Repositories

        DbSet<Setting> Settings { get; }

        #endregion

        #region Methods

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        void RollbackTransaction();

        #endregion
    }
}