namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api
{
    using MediatR;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class CoresServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreTestingApiServices(
            this IServiceCollection services,
            string sqlServerConnectionString)
        {
            services.AddDatabase(sqlServerConnectionString);

            services.AddMediatR(typeof(Application.QueryHandlers.ResidentialInternalErrorContactQueryHandler));

            return services;
        }

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            string sqlServerConnectionString)
        {
            services.AddDbContext<Infrastructure.Data.CoresTestingDatabase>(options =>
                  options.UseSqlServer(sqlServerConnectionString));

            return services;
        }
    }
}