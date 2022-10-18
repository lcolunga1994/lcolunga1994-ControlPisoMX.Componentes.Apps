namespace ProlecGE.ControlPisoMX.Cores.Storing.Residential.Forms
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;
    using ProlecGE.ControlPisoMX.Cores.Commands;
    using ProlecGE.ControlPisoMX.Cores.Queries;
    using ProlecGE.ControlPisoMX.Cores.Residential.Queries;
    using ProlecGE.ControlPisoMX.Cores.Services;
    using ProlecGE.ControlPisoMX.Cores.Storing.Residential.Commands;
    using ProlecGE.ControlPisoMX.Cores.Storing.Residential.Queries;

    using System;

    internal static class ProgramServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            MediatR.Registration.ServiceRegistrar.AddRequiredServices(services, new MediatR.MediatRServiceConfiguration());

            services.AddHttpClient<IResidentialCoresService, ResidentialCoresHttpService>(
                "ApiGateway", client => client.BaseAddress = new Uri(configuration.GetValue<string>("ApiGateway")));


            services.AddHttpClient<MediatR.IRequestHandler<InternalErrorContactQuery, string>, InternalErrorContactQueryHandler>(
              client => client.BaseAddress = new Uri(configuration.GetValue<string>("ConfigurationsApi")));
            services.AddHttpClient<MediatR.IRequestHandler<MissingCoreManufacturingPlanContactQuery, string>, MissingCoreManufacturingPlanContactQueryHandler>(
                client => client.BaseAddress = new Uri(configuration.GetValue<string>("ConfigurationsApi")));
            services.AddHttpClient<MediatR.IRequestHandler<MissingItemDesignContactQuery, string>, MissingItemDesignContactQueryHandler>(
                client => client.BaseAddress = new Uri(configuration.GetValue<string>("ConfigurationsApi")));

            //services.AddTransient<ITemperatureReader, TemperatureReader>();
            //services.AddTransient<ICoreTestValuesReader, CoreTestValuesFileReader>();
            //services.AddTransient<ICalibrationStatusValidateReader, CalibrationStatusValidateReader>();
            //services.AddTransient<IRegisterLastTimeCoreTestWriter, RegisterLastTimeCoreTestWriter>();
            services.AddTransient<ITestCodeLengthValidator, TestCodeLengthValidator>();
            services.AddTransient<ITestCodeTextValidator, TestCodeTextValidator>();
            services.AddTransient<IRackLocationLengthValidator, RackLocationLengthValidator>();

            services.AddSharedCommands();
            services.AddCommands();
            services.AddSharedQueries();
            services.AddQueries();

            return services;
        }

        private static IServiceCollection AddSharedCommands(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<RackLocationLengthValidatorCommand, bool>, RackLocationLengthValidatorCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<TestCodeLengthValidatorCommand, bool>, TestCodeLengthValidatorCommandHandler>();
            services.AddTransient<MediatR.IRequestHandler<TestCodeTextValidatorCommand, bool>, TestCodeTextValidatorCommandHandler>();

            return services;
        }

        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<StoreResidentialCoreCommand, bool>, StoreResidentialCoreCommandHandler>();

            return services;
        }

        private static IServiceCollection AddSharedQueries(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<StationIdentifierQuery, string>, StationIdentifierQueryHandler>();

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<MediatR.IRequestHandler<ResidentialCoreLocationResultQuery, ResidentialCoreLocationResultModel?>, ResidentialCoreLocationResultQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<ResidentialCoreSuggestedCodeResultQuery, ResidentialCoreSuggestedCodeResultModel?>, ResidentialCoreSuggestedCodeResultQueryHandler>();
            services.AddTransient<MediatR.IRequestHandler<ResidentialCoreTestQuery, ResidentialCoreTestModel?>, ResidentialCoreTestQueryHandler>();

            return services;
        }
    }
}