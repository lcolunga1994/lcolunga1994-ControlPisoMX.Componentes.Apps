namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Infrastructure.Data
{
    using EntityConfigurations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using System.Data;
    using System.Threading.Tasks;

    public class CoresTestingDatabase : DbContext, Domain.IUnitOfWork
    {
        #region Fields

        private IDbContextTransaction? currentTransaction;

        #endregion

        #region Constructor

        public CoresTestingDatabase(DbContextOptions<CoresTestingDatabase> options) : base(options) { }

        #endregion

        #region Properties

        public DbSet<Domain.Entities.Setting> Settings { get; set; } = null!;

        #endregion

        #region Methods

        public async Task BeginTransactionAsync()
        {
            if (currentTransaction != null)
            {
                return;
            }

            currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();

                await (currentTransaction?.CommitAsync() ?? Task.CompletedTask);
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                currentTransaction?.Rollback();
            }
            finally
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }

        #endregion

        #region Functionality

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("corestesting");
            modelBuilder.ApplyConfiguration(new ResidentialCoreSettingEntityConfiguration());
        }

        #endregion
    }
}