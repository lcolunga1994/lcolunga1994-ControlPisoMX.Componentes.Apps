namespace ProlecGE.ControlPisoMX.Clamps.Forms
{
    using System;
    using System.Text;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ConfigureExceptionHandling();

            IHost host = Host.CreateDefaultBuilder()
              .ConfigureServices((context, services) =>
              {
                  services.AddHttpClient<BFWeb.Components.IClampsService, BFWeb.Components.ClampsHttpService>(
                      "ComponentsHttpClient", client => client.BaseAddress = new Uri(context.Configuration.GetValue<string>("Urls:ComponentsUrl")));

                  MediatR.Registration.ServiceRegistrar.AddRequiredServices(services, new MediatR.MediatRServiceConfiguration());
                  services.AddTransient<MediatR.IRequestHandler<App.Queries.ClampsQuery, IEnumerable<BFWeb.Components.Models.OrderWithClampsModel>>, App.Queries.ClampsQueryHandler>();
                  services.AddTransient<MediatR.IRequestHandler<App.Commands.PlaceClampsCommand, MediatR.Unit>, App.Commands.PlaceClampsCommandHandler>();
                  //testing form
                  services.AddTransient<ClampsForm>();
              })
              .Build();

            using IServiceScope scope = host.Services.CreateScope();

            IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            //CustomTheme.Instance.On = configuration.GetValue<bool>("LightTheme");

            //if (string.IsNullOrWhiteSpace(configuration.GetValue<string>("Urls:ComponentsUrl")) ||
            //    string.IsNullOrWhiteSpace(configuration.GetValue<string>("Urls:SignalR")))
            //{
            //    MessageBox.Show("Es necesario configurar las url de la aplicación", "Fabricación de aislamientos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    Application.Exit();
            //}
            //else
            //{
            Form? mainform = scope.ServiceProvider.GetRequiredService<ClampsForm>();

            Application.Run(mainform);
            //}
        }

        private static void ConfigureExceptionHandling()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            StringBuilder message = new("Ha ocurrido un error inesperado.\r\n");

            message.Append(string.Format("{0}\r\n", ((Exception)e.ExceptionObject).Message));
            message.Append(string.Format("{0}\r\n", ((Exception)e.ExceptionObject).StackTrace));
            message.Append(string.Format("Por favor, contacte a soporte técnico."));

            MessageBox.Show(message.ToString(), "Error");
        }

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            StringBuilder message = new("Ha ocurrido un error inesperado.\r\n");

            message.Append(string.Format("{0}\r\n", e.Exception.Message));
            message.Append(string.Format("{0}\r\n", e.Exception.StackTrace));
            message.Append(string.Format("Por favor, contacte a soporte técnico."));

            MessageBox.Show(message.ToString(), "Error");
        }
    }
}