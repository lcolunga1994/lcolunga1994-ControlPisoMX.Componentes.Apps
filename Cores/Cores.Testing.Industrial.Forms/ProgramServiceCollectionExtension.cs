namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Forms
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;
    using ProlecGE.ControlPisoMX.Cores.Commands;
    using ProlecGE.ControlPisoMX.Cores.Industrial.Queries;
    using ProlecGE.ControlPisoMX.Cores.Queries;
    using ProlecGE.ControlPisoMX.Cores.Services;
    using ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Commands;
    using ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Queries;

    internal static class ProgramServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
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

            services.AddHttpClient<IIndustrialCoresService, IndustrialCoresHttpService>(
                "ApiGateway", client => client.BaseAddress = new Uri(configuration.GetValue<string>("ApiGateway")));
            
            services.AddHttpClient<MediatR.IRequestHandler<InternalErrorContactQuery, string>, InternalErrorContactQueryHandler>(
                client => client.BaseAddress = new Uri(configuration.GetValue<string>("ConfigurationsApi")));
            services.AddHttpClient<MediatR.IRequestHandler<MissingCoreManufacturingPlanContactQuery, string>, MissingCoreManufacturingPlanContactQueryHandler>(
                client => client.BaseAddress = new Uri(configuration.GetValue<string>("ConfigurationsApi")));
            services.AddHttpClient<MediatR.IRequestHandler<MissingItemDesignContactQuery, string>, MissingItemDesignContactQueryHandler>(
                client => client.BaseAddress = new Uri(configuration.GetValue<string>("ConfigurationsApi")));

            services.AddTransient<ITemperatureReader, TemperatureReader>();
            services.AddTransient<ICoreTestValuesReader, CoreTestValuesFileReader>();
            services.AddTransient<ICalibrationStatusValidateReader, CalibrationStatusValidateReader>();
            services.AddTransient<IRegisterLastTimeCoreTestWriter, RegisterLastTimeCoreTestWriter>();

            services.AddSharedCommands();
            services.AddCommands();
            services.AddSharedQueries();
            services.AddQueries();

            return services;
        }

        private static IServiceCollection AddSharedCommands(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<ReadCalibrationStatusCommand, bool>, ReadCalibrationStatusCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<TestTermoparConnectivityCommand, bool>, TestTermoparConnectivityCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<ReadTemperatureCommand, double>, ReadTemperatureCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<ReadTestValuesCommand, CoreTestsValues>, ReadTestValuesCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<RegisterLastTimeCoreTestCommand, MediatR.Unit>, RegisterLastTimeCoreTestCommandHandler>();

            return services;
        }

        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<TestIndustrialCoreCommand, IndustrialCoreTestResultModel>, TestIndustrialCoreCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<TestIndustrialPatternCommand, IndustrialCoreTestResultModel>, TestIndustrialPatternCommandHandler>();

            return services;
        }

        private static IServiceCollection AddSharedQueries(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<StationIdentifierQuery, string>, StationIdentifierQueryHandler>();

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<IndustrialCoreFoilWidthsQuery, IEnumerable<double>?>, IndustrialCoreFoilWidthsQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<IndustrialCorePatternDesignQuery, IndustrialCorePatternModel?>, IndustrialCorePatternDesignQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<IndustrialCoreTestResultQuery, IndustrialCoreTestResultModel?>, IndustrialCoreTestResultQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<IndustrialCoreTestSummaryQuery, IndustrialCoreTestSummaryModel?>, IndustrialCoreTestSummaryQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<IndustrialCoreVoltageDesignQuery, IndustrialItemVoltageDesignModel?>, CoreVoltageDesignQueryHandler>();

            return services;
        }
    }
}