namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api.Services
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models;
    using ProlecGE.ControlPisoMX.InspectionCMS;

    public class InspectionCMSHttpMicroservice : Http.WebApiClient, IMicroservice
    {
        #region Fields

        private readonly ILogger<InspectionCMSHttpMicroservice> logger;

        #endregion

        #region Constructor

        public InspectionCMSHttpMicroservice(
            HttpClient httpClient,
            ILogger<InspectionCMSHttpMicroservice> logger)
            : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task AcceptInspectionAsync(string itemId, string batch, int serie, string user)
        {
            try
            {
                await PostAsync($"inspectionCMS/accept?itemId={itemId}&batch={batch}&serie={serie}&user={user}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al confirmar el suministro de la orden '{itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException("No se puede confirmar el suministro de la orden en este momento.", "AcceptInspection");
            }
        }

        public async Task RejectInspectionAsync(string itemId, string batch, int serie, string machine, string user, string card, string code, CancellationToken cancellationToken)
        {
            try
            {
                await PostAsync($"inspectionCMS/rejected", new RejectInspectionParameter(itemId, batch, serie, machine, user, card, code), cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al rechazar la inspección '{itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException("No se puede rechazar la inspección en este momento.", "RejectInspection");
            }
        }

        public async Task<bool> OrderExistsAsync(string itemId, string batch, int serie)
        {
            try
            {
                return await GetAsync<bool>($"inspectionCMS/orderexists?itemId={itemId}&batch={batch}&serie={serie}", CancellationToken.None)
                  .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar la orden '{itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException("No se puede consultar la orden en este momento.", "OrderExist");
            }
        }

        public async Task<ControlPisoMX.Cores.Models.InspectionCMS.LastRejectedModel?> LastRejectedAsync(string itemId, string batch, int serie, string code)
        {
            try
            {
                return await GetAsync<ControlPisoMX.Cores.Models.InspectionCMS.LastRejectedModel?>($"inspectionCMS/lastrejected?itemId={itemId}&batch={batch}&serie={serie}&code={code}", CancellationToken.None)
                  .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar la información de rechazo '{itemId}-{batch}-{serie}-{code}'.", itemId, batch, serie, code);

                throw CreateServiceException("No se puede consultar la orden en este momento.", "LastRejected");
            }
        }

        #endregion

        #region Functionality

        private static UserException CreateServiceException(string message, string errorCode)
        {
            System.Text.StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(message);
            throw new UserException(stringBuilder.ToString(), errorCode, true);
        }

        #endregion
    }
}
