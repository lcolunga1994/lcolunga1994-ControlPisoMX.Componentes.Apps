namespace ProlecGE.ControlPisoMX.Security.Forms
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using ProlecGE.ControlPisoMX.Identity.Models;
    using ProlecGE.ControlPisoMX.Security.Forms.Command;
    using ProlecGE.ControlPisoMX.Security.Forms.CommandHandlers;
    using ProlecGE.ControlPisoMX.Security.Forms.Queries;
    using ProlecGE.ControlPisoMX.Security.Forms.QueryHandlers;

    public static class SecurityServiceCollectionExtension
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration, string applicationName, string? productLine = null )
        {
            services.AddHttpClient<MediatR.IRequestHandler<UserQuery, User?>, UserQueryHandler>(
                client => client.BaseAddress = new Uri(configuration.GetValue<string>("Urls:IdentityUrl")));
            services.AddHttpClient<MediatR.IRequestHandler<ValidateUserPasswordQuery, bool>, ValidateUserPasswordQueryHandler>(
                client => client.BaseAddress = new Uri(configuration.GetValue<string>("Urls:IdentityUrl")));

            services.AddHttpClient<MediatR.IRequestHandler<ChangePasswordCommand, bool>, ChangePasswordCommandHandler>(
                client => client.BaseAddress = new Uri(configuration.GetValue<string>("Urls:IdentityUrl")));

            services.AddTransient(services => new LoginForm(services.GetRequiredService<IServiceProvider>(), applicationName, productLine));

            return services;
        }

        public static IServiceCollection AddSecurityDummy(this IServiceCollection services, string applicationName, string? productLine = null)
        {
            services.AddHttpClient<MediatR.IRequestHandler<UserQuery, User?>, UserDummyQueryHandler>();
            services.AddHttpClient<MediatR.IRequestHandler<ValidateUserPasswordQuery, bool>, ValidateUserPasswordDummyQueryHandler>();

            services.AddHttpClient<MediatR.IRequestHandler<ChangePasswordCommand, bool>, ChangePasswordDummyCommandHandler>();

            services.AddTransient(services => new LoginForm(services.GetRequiredService<IServiceProvider>(), applicationName, productLine));

            return services;
        }
    }
}