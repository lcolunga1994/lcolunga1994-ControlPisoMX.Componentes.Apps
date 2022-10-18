namespace ProlecGE.ControlPisoMX.Cores.Storing.Residential.Forms
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            bool apiUriUndefined = false;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            IHost? host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    if (string.IsNullOrEmpty(context.Configuration.GetValue<string>("ApiGateway")) ||
                        string.IsNullOrWhiteSpace(context.Configuration.GetValue<string>("ApiGateway")) ||
                        string.IsNullOrEmpty(context.Configuration.GetValue<string>("ConfigurationsApi")) ||
                        string.IsNullOrWhiteSpace(context.Configuration.GetValue<string>("ConfigurationsApi")))
                    {
                        apiUriUndefined = true;
                    }

                    services.ConfigureServices(context.Configuration);
                    
                    services.AddTransient<UsherForm>();
                })
                .Build();

            if (!apiUriUndefined)
            {
                using IServiceScope? scope = host.Services.CreateScope();
                Form mainForm = scope.ServiceProvider.GetRequiredService<UsherForm>();
                Application.Run(mainForm);
            }
            else
            {
                HandleException(new Exception("No se han definido las direcciones de las APIs en el archivo de configuración."));
            }
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

        private static void HandleException(Exception e)
        {
            string title = $"Sistema Acomodador de Núcleos Residenciales.";
            string infos = $"{e.Message}";

            MessageBox.Show(infos, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}