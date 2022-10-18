namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;
    using ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Commands;
    using ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Queries;
    using ProlecGE.ControlPisoMX.CoreSupply.Forms.Commands;
    using ProlecGE.ControlPisoMX.CoreSupply.Forms.Queries;

    internal static class ProgramServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<ThemeConfiguration>(context.Configuration.GetSection("Theme"));

            MediatR.Registration.ServiceRegistrar.AddRequiredServices(services, new MediatR.MediatRServiceConfiguration());

            //BFWeb.Components.Api
            //.MonolithicServiceCollectionExtension
            //.AddMonolithicGateway(
            //    services,
            //    context.Configuration,
            //    context.Configuration.GetConnectionString("Cores_Legacy"),
            //    "ERP_SQLServer",
            //    "ERP_Oracle",
            //    context.Configuration.GetSection("ERP_VoltageDesign"),
            //    context.Configuration.GetConnectionString("I40"),
            //    context.Configuration.GetConnectionString("I40_Trancos"),
            //    context.Configuration.GetSection("I40_Querying"),
            //    context.Configuration.GetConnectionString("Cores_SQLServer"),
            //    context.Configuration.GetConnectionString("Cores_Engineering"),
            //    context.Configuration.GetSection("Cores_BAAN4"));

            //Settings.Api.CoresServiceCollectionExtensions
            //.AddSettingsMicroservice(
            //    services, 
            //    context.Configuration.GetConnectionString("CoresTesting_Settings"));

            services.AddHttpClient<BFWeb.Components.IResidentialCoresService, BFWeb.Components.ResidentialCoresHttpService>(
                "ComponentsHttpClient", client => client.BaseAddress = new Uri(configuration.GetValue<string>("Urls:ComponentsUrl")));

            services.AddHttpClient<BFWeb.Components.ICoresSupplyService, BFWeb.Components.CoresSupplyServiceHttpService>(
                "CoresSupplyHttpClient", client => client.BaseAddress = new Uri(configuration.GetValue<string>("Urls:ComponentsUrl")));

            //services.AddTransient<BFWeb.Components.IResidentialCoresService, ClientApp.ComponentsGatewayDummy>();

            services.AddHttpClient<Services.IInsulationsService, Services.InsulationsHttpService>(
                "InsulationsHttpClient", client => client.BaseAddress = new Uri(configuration.GetValue<string>("Urls:ComponentsUrl")));

            Security.Forms.SecurityServiceCollectionExtension.AddSecurity(services, configuration, "All");

            services.AddSharedCommands();
            services.AddCommands();
            services.AddQueries();

            return services;
        }

        private static IServiceCollection AddSharedCommands(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<PrintTagCommand, MediatR.Unit>, PrintTagCommandHandler>();

            return services;
        }

        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<AddOrdersToSupplyListCommand, MediatR.Unit>, AddOrderToSupplyListCommandHandler>();

            services.AddTransient<MediatR.IRequestHandler<ConfirmSupplyCommand, MediatR.Unit>, ConfirmSupplyCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<AuthorizeReprintCommand, MediatR.Unit>, AuthorizeReprintCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<ReprintCommand, MediatR.Unit>, ReprintCommandHandler>();

            services.AddTransient<MediatR.IRequestHandler<AddSupplyCoreCommand, MediatR.Unit>, AddSupplyCoreCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<RemoveSupplyCoreCommand, MediatR.Unit>, RemoveSupplyCoreCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<SupplyCoreCommand, SupplyCoreResultModel?>, SupplyCoreCommandHandler>();

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<MachinesQuery, IEnumerable<InsulationMachineModel>>, MachinesQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<MOAvailableToSupplyQuery, IEnumerable<MOManufacturingStatusModel>>, MOAvailableToSupplyQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<MOSuppliesPendingQueryQuery, IEnumerable<MOSupplyItemModel>>, MOSuppliesPendingQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<MOSuppliesToReprintSupplyQuery, IEnumerable<MOSupplyItemModel>>, MOSuppliesToReprintSupplyQueryHandler>();

            services.AddTransient<MediatR.IRequestHandler<MOSupplySummaryQuery, MOSupplySummaryModel?>, MOSupplySummaryQueryHandler>();

            services.AddTransient<MediatR.IRequestHandler<ItemQuery, ItemModel?>, ItemQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<ResidentialCoreSupplyByOrderQuery, IEnumerable<ResidentialSuppliedCoreTestModel>>, ResidentialCoreSupplyByOrderQueryHandler>();

            services.AddTransient<MediatR.IRequestHandler<MOSupplyItemTagQuery, MOSupplyItemTagModel?>, MOSupplyItemTagQueryHandler>();

            return services;
        }
    }
}