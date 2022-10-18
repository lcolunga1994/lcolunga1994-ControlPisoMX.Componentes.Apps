namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Combo.Queries;
    using MediatR;

    using Microsoft.Extensions.Logging;

    using Models;
    using System.Net.Http;

    public class ComboService : IComboService
    {
        #region Fields

        private readonly ILogger<ComboService> logger;
        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public ComboService(
             HttpClient httpClient,
            ILogger<ComboService> logger,
            IMediator mediator)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        #endregion

        public async Task<IEnumerable<ComboOrderDesignModel>> GetComboOrderDesignAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                return await mediator.Send(new ComboOrderDesignQuery(itemId), CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al consultar los diseños de la orden.");
                }
                throw;
            }
        }
    }
}
