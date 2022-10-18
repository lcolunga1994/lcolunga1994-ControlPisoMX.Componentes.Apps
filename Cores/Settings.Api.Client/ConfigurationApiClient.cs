namespace ProlecGE.ControlPisoMX.CoresTesting.Settings.Api
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    public class ConfigurationApiClient : Http.WebApiClient, Residential.IMicroservice, Industrial.IMicroservice
    {
        #region Fields

        private readonly ILogger<ConfigurationApiClient> logger;

        #endregion

        #region Constructor

        public ConfigurationApiClient(
           HttpClient httpClient,
           ILogger<ConfigurationApiClient> logger)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<string> GetResidentialMissingItemDesignContactAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el contacto para la falta de información de diseño.'");

                return await GetAsync<string>(
                    $"residential/missingitemdesigncontact",
                    CancellationToken.None)
                .ConfigureAwait(false) ?? "Contacte con su supervisor";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el contacto para la falta de información de diseño.'");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el contacto para la falta de información de diseño en este momento.",
                    "ConfigurationMissingItemDesignContact");
            }
        }

        public async Task<string> GetResidentialInternalErrorContactAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el contacto para los errores internos del sistema.'");

                return await GetAsync<string>(
                    $"residential/internalerrorcontact",
                    CancellationToken.None)
                .ConfigureAwait(false) ?? "Contacte con su supervisor referente al error interno";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el contacto para el error del servidor.'");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el contacto para el error interno en este momento.",
                    "MissingCoreDesignContact");
            }
        }

        public async Task<string> GetResidentialMissingCoreManufacturingPlanContactAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el contacto para la falta de información de la orden.'");

                return await GetAsync<string>(
                    $"residential/missingcoremanufacturingplancontact",
                    CancellationToken.None)
                .ConfigureAwait(false) ?? "Contacte con su supervisor con respecto a la orden";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el contacto para la falta de información de la orden.'");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el contacto para la falta de información de la orden en este momento.",
                    "MissingOrderContact");
            }
        }


        public async Task<string> GetIndustrialMissingItemDesignContactAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el contacto para la falta de información de diseño.'");

                return await GetAsync<string>(
                    $"industrial/missingitemdesigncontact",
                    CancellationToken.None)
                .ConfigureAwait(false) ?? "Contacte con su supervisor";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el contacto para la falta de información de diseño.'");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el contacto para la falta de información de diseño en este momento.",
                    "ConfigurationMissingItemDesignContact");
            }
        }

        public async Task<string> GetIndustrialInternalErrorContactAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el contacto para los errores internos del sistema.'");

                return await GetAsync<string>(
                    $"industrial/internalerrorcontact",
                    CancellationToken.None)
                .ConfigureAwait(false) ?? "Contacte con su supervisor referente al error interno";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el contacto para el error del servidor.'");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el contacto para el error interno en este momento.",
                    "MissingCoreDesignContact");
            }
        }

        public async Task<string> GetIndustrialMissingCoreManufacturingPlanContactAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando el contacto para la falta de información de la orden.'");

                return await GetAsync<string>(
                    $"industrial/missingcoremanufacturingplancontact",
                    CancellationToken.None)
                .ConfigureAwait(false) ?? "Contacte con su supervisor con respecto a la orden";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el contacto para la falta de información de la orden.'");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el contacto para la falta de información de la orden en este momento.",
                    "MissingOrderContact");
            }
        }

        #endregion

        #region Functionality

        private static UserException CreateServiceException(string message, string errorCode)
        {
            System.Text.StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(message);
            stringBuilder.AppendLine("Ocurrió un error en el servidor.");
            stringBuilder.AppendLine($"Contacte al area de sistemas ({errorCode}).");
            throw new UserException(stringBuilder.ToString(), errorCode, true);
        }

        #endregion
    }
}