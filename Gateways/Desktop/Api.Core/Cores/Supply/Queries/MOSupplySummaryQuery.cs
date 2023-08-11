namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Queries
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

    internal class MOSupplySummaryQuery : IRequest<MOSupplySummaryModel?>
    {
        #region Contructor

        public MOSupplySummaryQuery(string itemId, string batch)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser nulo o vacío");
            }

            if (string.IsNullOrWhiteSpace(batch))
            {
                throw new UserException("El lote no puede ser nulo o vacío");
            }

            ItemId = itemId;
            Batch = batch;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public string Batch { get; }

        #endregion
    }

    internal class MOSupplySummaryQueryHandler : IRequestHandler<MOSupplySummaryQuery, MOSupplySummaryModel?>
    {
        #region Fields

        private readonly ILogger<MOSupplySummaryQueryHandler> logger;
        private readonly ControlPisoMX.ERP.IMicroservice erp;
        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public MOSupplySummaryQueryHandler(
            ILogger<MOSupplySummaryQueryHandler> logger,
            ControlPisoMX.ERP.IMicroservice erp,
            ControlPisoMX.Cores.IMicroservice cores,
            IConfiguration configuration)
        {
            this.logger = logger;
            this.erp = erp;
            this.cores = cores;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<MOSupplySummaryModel?> Handle(MOSupplySummaryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                ERP.Models.ManufacturingOrderModel? manufacturingOrder = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ? 
                    await erp
                    .GetManufacturingOrderAsync(request.ItemId, request.Batch, cancellationToken)
                    .ConfigureAwait(false)
                    : await erp
                    .GetManufacturingOrderAsync_sqlctp(request.ItemId, request.Batch, cancellationToken)
                    .ConfigureAwait(false);

                if (manufacturingOrder == null)
                {
                    return null;
                }

                IEnumerable<ControlPisoMX.Cores.Models.ManufacturingOrders.MOSupplyItemStatusModel> suppliedOrders = await cores
                    .GetSuppliesByBatchAsync(request.ItemId, request.Batch)
                    .ConfigureAwait(false);

                MOSupplySummaryModel supplySummary = new()
                {
                    ItemId = manufacturingOrder.ItemId,
                    Batch = manufacturingOrder.Batch,
                    Quantity = manufacturingOrder.Quantity,
                    Orders = suppliedOrders.Select(e => new MOSupplyItemStatusModel()
                    {
                        ItemId = e.ItemId,
                        Batch = e.Batch,
                        Serie = e.Serie,
                        Sequence = e.Sequence,
                        SuppliedUtcDate = e.SuppliedUtcDate,
                        Confirmed = e.Confirmed
                    }).ToList()
                };

                return supplySummary;
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al consultar las ordenes suministradas para el pedido {itemId}-{batch}.", request.ItemId, request.Batch);
                }
                throw;
            }
        }

        #endregion
    }
}