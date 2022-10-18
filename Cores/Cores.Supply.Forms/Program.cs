namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using System.Text;

    using MediatR;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    internal static class Program
    {
        #region Properties

        public static Identity.Models.User User { get; internal set; } = new Identity.Models.User()
        {
            Name = Environment.UserName
        };

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
                   //services.Configure<ThemeConfiguration>(context.Configuration.GetSection("Theme"));

                   MediatR.Registration.ServiceRegistrar.AddRequiredServices(services, new MediatR.MediatRServiceConfiguration());

                   services.ConfigureServices(context.Configuration);
                   services.AddTransient<ManufacturingStatusForm>();
                   services.AddTransient<PrintSupplyTagForm>();
               })
               .Build();

            using IServiceScope scope = host.Services.CreateScope();

            IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            Form? mainform = null;

            if (args.Length > 0 && args[0] == "AIS_A")
            {
                mainform = scope.ServiceProvider.GetRequiredService<ManufacturingStatusForm>();
                Application.Run(mainform);
            }
            else
            {
                mainform = scope.ServiceProvider.GetRequiredService<Security.Forms.LoginForm>();

                if (mainform.ShowDialog() == DialogResult.OK)
                {
                    if (mainform is Security.Forms.LoginForm loginForm && loginForm.User != null)
                    {
                        User = loginForm.User;
                    }

                    mainform = scope.ServiceProvider.GetRequiredService<PrintSupplyTagForm>();
                    Application.Run(mainform);
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private static void SetupExceptionHandling()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += (s, e) => ManageUnhandledException(s, (Exception)e.ExceptionObject);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e) => ManageUnhandledException(sender, e.ExceptionObject as Exception);

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e) => ManageUnhandledException(sender, e.Exception);

        private static void ManageUnhandledException(object sender, Exception? exception)
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