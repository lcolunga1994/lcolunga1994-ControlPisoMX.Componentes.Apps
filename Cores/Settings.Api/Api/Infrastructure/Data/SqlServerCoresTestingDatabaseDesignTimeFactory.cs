namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    //Add-Migration {Nombre} -Project CoresTesting.Settings.Api.Core -StartupProject CoresTesting.Settings.Api.Core -OutputDir Infrastructure/Data/Migrations/SqlServer
    //Update-Database -Project CoresTesting.Settings.Api.Core -StartupProject CoresTesting.Settings.Api.Core
    //Update-Database 0 -Project CoresTesting.Settings.Api.Core -StartupProject CoresTesting.Settings.Api.Core
    //Remove-Migration -Project CoresTesting.Settings.Api.Core -StartupProject CoresTesting.Settings.Api.Core
    internal class SqlServerCoresTestingDatabaseDesignTimeFactory : IDesignTimeDbContextFactory<CoresTestingDatabase>
    {
        public CoresTestingDatabase CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CoresTestingDatabase> optionsBuilder = new();
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AppsCoresTesting;Integrated Security=True;MultipleActiveResultSets=True;",
                options =>
                {
                    options.MigrationsAssembly(typeof(SqlServerCoresTestingDatabaseDesignTimeFactory).Assembly.FullName);
                    options.MigrationsHistoryTable("__EFMigrationsHistory", "corestesting");
                });

            return new CoresTestingDatabase(optionsBuilder.Options);
        }
    }
}