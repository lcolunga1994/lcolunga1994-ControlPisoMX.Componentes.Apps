namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using Models;
    using ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders;

    public class AuthorizeReprintCommand : IRequest
    {
        #region Constructor

        public AuthorizeReprintCommand(string itemId, string batch, int serie)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(batch))
            {
                throw new UserException("El lote no puede ser vacío o espacios en blanco.");
            }

            ItemId = itemId.Trim();
            Batch = batch.Trim();
            Serie = serie;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public string Batch { get; }

        public int Serie { get; }

        #endregion
    }

    public class AuthorizeReprintCommandHandler : IRequestHandler<AuthorizeReprintCommand>
    {
        #region Fields

        private readonly ILogger<AuthorizeReprintCommandHandler> logger;
        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly ControlPisoMX.Insulations.IMicroservice insulations;
        private readonly ERP.IMicroservice erp;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public AuthorizeReprintCommandHandler(
            ILogger<AuthorizeReprintCommandHandler> logger,
            ControlPisoMX.Cores.IMicroservice cores,
            ControlPisoMX.Insulations.IMicroservice insulations,
            ERP.IMicroservice erp,
            IConfiguration configuration)
        {
            this.logger = logger;
            this.cores = cores;
            this.insulations = insulations;
            this.erp = erp;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(AuthorizeReprintCommand request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando los datos de impresión del suministro de la orden {itemId}-{batch}-{serie}.", request.ItemId, request.Batch, request.Serie);

                List<MOPrintableAttributeModel> printableAttributes = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
                        await erp.GetMOPrintableAttributesAsync(request.ItemId, request.Batch, request.Serie).ConfigureAwait(false)
                      : await erp.GetMOPrintableAttributesAsync_LN(request.ItemId, request.Batch, request.Serie, int.Parse(_configuration.GetSection("Cia").Value.ToString())).ConfigureAwait(false);


                if(bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()))
                {                    
                    await cores.RefreshPrintableAttributesAsync(request.ItemId, request.Batch, request.Serie, printableAttributes).ConfigureAwait(false);

                    await cores.AuthorizeReprintAsync(request.ItemId, request.Batch, request.Serie).ConfigureAwait(false);
                }
                else
                {
                    await cores.RefreshPrintableAttributesAsync_sqlctp(request.ItemId, request.Batch, request.Serie, printableAttributes).ConfigureAwait(false);

                    await cores.AuthorizeReprintAsync_sqlctp(request.ItemId, request.Batch, request.Serie).ConfigureAwait(false);
                }
                return Unit.Value;
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al autorizar la reimpresión de la orden {itemId}-{batch}-{serie}.", request.ItemId, request.Batch, request.Serie);
                    throw UserException.WithInnerException($"Ocurrió un error al autorizar la reimpresión de la orden {request.ItemId}-{request.Batch}-{request.Serie}.", ex);
                }

                throw;
            }
        }

        #endregion
    }
}