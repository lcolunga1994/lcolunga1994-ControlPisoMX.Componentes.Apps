namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    public static class ComponentsServiceCollectionExtension
    {
        public static IServiceCollection AddComponentsGateway(
            this IServiceCollection services)
        {
            services.AddTransient(factory =>
              {
                  AutoMapper.MapperConfiguration config = new(config =>
                  {
                      config.AddProfile(new ComponentsMapperProfile());
                  });

                  config.AssertConfigurationIsValid();
                  return config.CreateMapper();
              });

            services.AddTransient<IResidentialCoresService, ResidentialCoresService>();
            services.AddTransient<IIndustrialCoresService, IndustrialCoresService>();
            services.AddTransient<ICoresSupplyService, CoresSupplyService>();

            services.AddTransient<IInsulationsService, InsulationsService>();
            services.AddTransient<IClampsService, ClampsService>();
            services.AddTransient<IInspectionCMService, InspectionCMService>();
            services.AddMediatR(typeof(Clamps.Queries.OrdersToPlaceClampsQuery).Assembly);

            return services;
        }
    }
}