namespace ProlecGE.ControlPisoMX.I40.Api
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.I40.Models;

    public class I40Microservice
        : Http.WebApiClient, IMicroservice
    {
        #region Fields

        private readonly ILogger<I40Microservice> logger;

        #endregion

        #region Constructor

        public I40Microservice(
           HttpClient httpClient,
           ILogger<I40Microservice> logger)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<QueryResult<ManufacturedCoreModel>> GetManufacturedCoresAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el plan de trancos: página:{page} tamaño:{pageSize}.");

#pragma warning disable CS8603 // Possible null reference return.
                return await GetAsync<QueryResult<ManufacturedCoreModel>>(
                    $"tags/plan?page={page}&pageSize={pageSize}",
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar la información.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar los núcleos fabricados en este momento.",
                    "I40CoreTags");
            }
        }

        public async Task<ManufacturedCoreModel?> GetManufacturedCoreAsync(
            string tag,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el plan de fabricación de la etiqueta '{tag}'.");

                return await GetAsync<ManufacturedCoreModel?>(
                    $"tags/{tag}",
                    cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar la información.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el núcleo en este momento.",
                    "I40ManufacturedCore");
            }
        }

        public async Task<string?> GetCoreTagAsync(string itemId, string batch, int sequence)
        {
            try
            {
                logger.LogInformation($"Consultando la etiqueta para la ordern '{itemId}/{batch}' secuencia:{sequence}.");

                return await GetAsync<string?>($"tags/by/{itemId}/{batch}/{sequence}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar la etiqueta para la ordern '{itemId}-{batch}' secuencia:{sequence}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar la etiqueta para la ordern '{itemId}/{batch}' secuencia:{sequence} en este momento.",
                    "I40CoreTag");
            }
        }

        public async Task SetCoreAsTestedAsync(string tag, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Marcando el núcleo con la etiqueta '{tag}' como probado.");

                await PostAsync($"tags/test/{tag}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al marcar el núcleo con la etiqueta '{tag}' como probado.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede marcar el núcleo como probado en este momento.",
                    "I40CoreAsTested");
            }
        }

        public async Task UpdateCoreTestAvailabilityAsync()
        {
            try
            {
                logger.LogInformation($"Actualizando la disponibilidad de los núcleos para ser probados.");

                await PostAsync($"tags/coretestavailability")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al actualizar la disponibilidad de los núcleos para ser probados.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede la disponibilidad de los núcleos para ser probados en este momento.",
                    "I40CoreTestAvailability");
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