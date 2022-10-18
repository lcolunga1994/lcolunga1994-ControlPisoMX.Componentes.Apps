namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using ProlecGE.ControlPisoMX.Cores.Api;
    using ProlecGE.ControlPisoMX.ERP.Api;
    using ProlecGE.ControlPisoMX.I40.Api;
    using ProlecGE.ControlPisoMX.Legacy.Api;

    public static class MonolithicServiceCollectionExtension
    {
        public static IServiceCollection AddMonolithicGateway(
            this IServiceCollection services,
            IConfiguration configuration,
            string legacyConnectionStringName,
            string erpSqlServerConnectionStringName,
            string erpOracleConnectionStringName,
            IConfigurationSection erpCoresVoltageDesingSection,
            string i40ConnectionString,
            string trancosConnectionString,
            IConfigurationSection i40QueryingSection,
            string coresConnectionStringName,
            string engineeringConnectionStringName,
            IConfigurationSection coresBAAN4Section)
        {
            services.AddLegacyMicroservice(configuration.GetConnectionString(legacyConnectionStringName));

            services.AddERPMicroservice(
                erpSqlServerConnectionStringName,
                erpOracleConnectionStringName,
                erpCoresVoltageDesingSection);

            services.AddI40Microservice(i40ConnectionString, trancosConnectionString, i40QueryingSection);

            //services.AddCoresMicroservice(
            //    configuration,
            //    coresConnectionStringName,
            //    legacyConnectionStringName,
            //    engineeringConnectionStringName,
            //    erpSqlServerConnectionStringName,
            //    coresBAAN4Section);

            services.AddComponentsGateway();

            return services;
        }
    }
}