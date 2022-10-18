namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using System.Text;

    using MediatR;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    internal static class Program
    {
        #region Properties

        public static string UserDisplayName { get; internal set; } = "";

        #endregion

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            SetupExceptionHandling();

            IHost host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.Configure<ThemeConfiguration>(context.Configuration.GetSection("Theme"));

                   services.AddHttpClient<BFWeb.Components.IInsulationsService, BFWeb.Components.InsulationsHttpService>(
                       "ComponentsHttpClient", client => client.BaseAddress = new Uri(context.Configuration.GetValue<string>("Urls:ComponentsUrl")));

                   services.AddMediatR(
                       typeof(ClientApp.Queries.GuillotineShearsQuery),
                       typeof(Shared.ClientApp.Queries.ManufacturingOrderQuery));

                   services.AddTransient<OnlyDevelopForm>();
                   services.AddTransient<frmLogin>();
                   services.AddTransient<ManualCartonShears>();
                   services.AddTransient<CartonGuillotineShears>();
                   services.AddTransient<LVTaps>();
                   services.AddTransient<LVTaps2>();
                   services.AddTransient<InsOrderFabrication>();
                   services.AddTransient<InsOrderMaintenance>();
               })
               .Build();

            using IServiceScope scope = host.Services.CreateScope();

            IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            if (string.IsNullOrWhiteSpace(configuration.GetValue<string>("Urls:ComponentsUrl")) ||
                string.IsNullOrWhiteSpace(configuration.GetValue<string>("Urls:SignalR")))
            {
                MessageBox.Show("Es necesario configurar las url de la aplicación", "Fabricación de aislamientos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            else
            {
                Form? mainform = null;

                if (args.Length > 0)
                {
                    switch (args[0].ToString().Trim())
                    {
                        case "AIS_B":
                            mainform = scope.ServiceProvider.GetService<InsOrderFabrication>();
                            break;
                        case "AIS_C":
                            mainform = scope.ServiceProvider.GetService<ManualCartonShears>();
                            break;
                        case "AIS_D":
                            mainform = scope.ServiceProvider.GetService<CartonGuillotineShears>();
                            break;
                        case "AIS_E":
                            MessageBox.Show("Parametro recibido: " + args[0]);
                            break;
                        case "AIS_G":
                            mainform = scope.ServiceProvider.GetService<LVTaps>();
                            break;
                        case "AIS_H":
                            mainform = scope.ServiceProvider.GetRequiredService<frmLogin>();

                            if (mainform.ShowDialog() == DialogResult.OK)
                            {
                                mainform = scope.ServiceProvider.GetRequiredService<InsOrderMaintenance>();
                            }
                            else
                            {
                                mainform = null;
                            }
                            break;
                        case "AIS_I":
                            mainform = scope.ServiceProvider.GetService<LVTaps2>();
                            break;
                        default:
                            MessageBox.Show("Parametro recibido: " + args[0]);
                            break;
                    }

                    if (mainform != null)
                    {
                        Application.Run(mainform);
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    if (host.Services.GetRequiredService<IHostEnvironment>().IsDevelopment())
                    {
                        mainform = scope.ServiceProvider.GetRequiredService<OnlyDevelopForm>();
                    }
                    else
                    {
                        mainform = scope.ServiceProvider.GetRequiredService<frmLogin>();
                        if (mainform.ShowDialog() == DialogResult.OK)
                        {
                            mainform = scope.ServiceProvider.GetRequiredService<InsOrderMaintenance>();
                        }
                    }

                    if (mainform != null)
                    {
                        Application.Run(mainform);
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private static void SetupExceptionHandling()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += (s, e) => ManageUnhandledException((Exception)e.ExceptionObject);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e) => ManageUnhandledException(e.ExceptionObject as Exception);

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e) => ManageUnhandledException(e.Exception);

        private static void ManageUnhandledException(Exception? exception)
        {
            if (exception != null)
            {
                StringBuilder message = new("Ha ocurrido un error inesperado.\r\n");

                message.Append(string.Format("{0}\r\n", exception.Message));
                message.Append(string.Format("Por favor, contacte a soporte técnico."));

                MessageBox.Show(message.ToString(), "Error");
            }
        }
    }
}