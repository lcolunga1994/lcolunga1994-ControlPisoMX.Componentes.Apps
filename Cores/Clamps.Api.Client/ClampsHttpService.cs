namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Microsoft.Extensions.Logging;

    using Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ClampsHttpService : Http.WebApiClient, IClampsService
    {
        #region Fields

        private readonly ILogger<ClampsHttpService> logger;

        #endregion

        #region Constructor

        public ClampsHttpService(
           HttpClient httpClient,
           ILogger<ClampsHttpService> logger)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Queries

        public async Task<IEnumerable<OrderWithClampsModel>> GetOrdersToPlaceClampsAsync()
        {
            try
            {
                logger.LogInformation("Consultando las ordenes a las que no se les han colocado los herrajes.");

                IEnumerable<OrderWithClampsModel>? result =
                    await GetAsync<IEnumerable<OrderWithClampsModel>>("clamps/orderstoplace", CancellationToken.None)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    result = Enumerable.Empty<OrderWithClampsModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se pueden consultar las ordenes a las que no se les han colocado los herrajes en este momento.", "OrdersToPlace");
            }
        }
        public async Task RemoveClampAsync(string itemId, string batch, int serie, int sequence)
        {
            try
            {
                logger.LogInformation("{message}", $"Eliminando las orden {itemId}-{batch}-{sequence}");

                await PostAsync("clamps/removeclamp", new OrderModel(itemId, batch, serie, sequence), CancellationToken.None)
                .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se pueden consultar las ordenes a las que no se les han colocado los herrajes en este momento.", "OrdersToPlace");
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

        public Task UpdateOrder(string itemId, string batch, int serie) => throw new NotImplementedException();
        public Task UpdateImpetiOrder(string itemId, string batch, int serie) => throw new NotImplementedException();

        #endregion
    }
}