namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Clamps.Queries;

    using MediatR;

    using Microsoft.Extensions.Logging;

    using Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Clamps.Commands;

    public class ClampsService : IClampsService
    {
        #region Fields

        private readonly ILogger<ClampsService> logger;
        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public ClampsService(
            ILogger<ClampsService> logger,
            IMediator mediator)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public async Task RemoveClampAsync(string itemId, string batch, int serie, int sequence)
        {
            try
            {
                await mediator.Send(new RemoveClampCommand(itemId, batch, serie, sequence), CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error eliminar la orden de herrajes.");
                }
                throw;
            }
        }

        #endregion

        #region Clamps

        public async Task<IEnumerable<OrderWithClampsModel>> GetOrdersToPlaceClampsAsync()
        {
            try
            {
                return await mediator.Send(new OrdersToPlaceClampsQuery(), CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al consultar las ordenes a las que no se les han colocado los herrajes.");
                }
                throw;
            }
        }

        public Task UpdateImpetiOrder(string itemId, string batch, int serie) => throw new NotImplementedException();
        public Task UpdateOrder(string itemId, string batch, int serie) => throw new NotImplementedException();

        #endregion
    }
}