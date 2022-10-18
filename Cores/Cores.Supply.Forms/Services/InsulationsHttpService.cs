namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.Services
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    internal class InsulationsHttpService : Http.WebApiClient, IInsulationsService
    {
        #region Fields

        private readonly ILogger<InsulationsHttpService> logger;

        #endregion

        #region Constructor

        public InsulationsHttpService(
           HttpClient httpClient,
           ILogger<InsulationsHttpService> logger)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<InsulationManufactureModel?> GetManufacturingOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando información del aislamiento para la orden {order}.", $"{itemId}-{batch}-{serie}");

                InsulationManufactureModel? result = await GetAsync<InsulationManufactureModel?>($"insulations/manufacturingorder/{itemId}/{batch}/{serie}", cancellationToken).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar la información del aislamiento para la orden {order}.", $"{itemId}-{batch}-{serie}");

                if (ex is UserException)
                {
                    throw;
                }

                throw new UserException($"No se puede consultar la información del aislamiento para la orden {itemId}-{batch}-{serie}", "GetManufacturingOrders", true);
            }
        }

        #endregion
    }
}