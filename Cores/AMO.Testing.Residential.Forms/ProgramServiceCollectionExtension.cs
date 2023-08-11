namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Forms
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;
    using ProlecGE.ControlPisoMX.Cores.Commands;
    using ProlecGE.ControlPisoMX.Cores.Queries;
    using ProlecGE.ControlPisoMX.Cores.Residential.Queries;
    using ProlecGE.ControlPisoMX.Cores.Services;
    using ProlecGE.ControlPisoMX.AMO.Testing.Residential.Commands;
    using ProlecGE.ControlPisoMX.AMO.Testing.Residential.Queries;
    using ProlecGE.ControlPisoMX.Cores;

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

            services.AddHttpClient<IResidentialCoresService, ResidentialCoresHttpService>(
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
            //services.AddTransient<ITestCodeLengthValidator, TestCodeLengthValidator>();
            //services.AddTransient<ITestCodeTextValidator, TestCodeTextValidator>();
            //services.AddTransient<IRackLocationLengthValidator, RackLocationLengthValidator>();

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

            //services.AddTransient<MediatR.IRequestHandler<RackLocationLengthValidatorCommand, bool>, RackLocationLengthValidatorCommandHandler>();
            //services.AddTransient<MediatR.IRequestHandler<TestCodeLengthValidatorCommand, bool>, TestCodeLengthValidatorCommandHandler>();
            //services.AddTransient<MediatR.IRequestHandler<TestCodeTextValidatorCommand, bool>, TestCodeTextValidatorCommandHandler>();

            return services;
        }

        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<RegisterDefectCommand, ResidentialCoreTestResultModel>, RegisterDefectCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<ReworkResidentialCoreCommand, ResidentialCoreTestResultModel>, ReworkResidentialCoreCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<TestResidentialCoreCommand, ResidentialCoreTestResultModel>, TestCoreCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<TestResidentialPatternCommand, ResidentialCoreTestResultModel>, TestResidentialPatternCommandHandler>();

            return services;
        }

        private static IServiceCollection AddSharedQueries(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<StationIdentifierQuery, string>, StationIdentifierQueryHandler>();

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<CoreTestSummaryQuery, ResidentialCoreTestSummaryModel?>, CoreTestSummaryQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<CoreVoltageDesignQuery, CoreVoltageDesignModel?>, CoreVoltageDesignQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<DateRangeAvailableForTestQuery, IEnumerable<DateRangeAvailableModel>>, DateRangeAvailableForTestQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<DefectConceptQuery, IEnumerable<CoreTestDefectConceptModel>>, DefectConceptQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<ItemQuery, BFWeb.Components.Cores.Models.ItemModel?>, ItemQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<ItemsPlannedToBeManufacturedQuery, BFWeb.Components.Cores.QueryResult<string>>, ItemsPlannedToBeManufacturedQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<ManufacturedCoresQuery, BFWeb.Components.Cores.QueryResult<ManufacturedResidentialCoreModel>>, ManufacturedCoresQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<NextCoreToBeManufacturedQuery, CoreManufacturingPlanModel?>, NextCoreToBeManufacturedQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<ResidentialCorePatternTestsSummaryQuery, ResidentialCorePatternTestsSummaryModel?>, ResidentialCorePatternTestsSummaryQueryHandler>();

            return services;
        }
    }
}