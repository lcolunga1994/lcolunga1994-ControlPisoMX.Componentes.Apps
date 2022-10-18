﻿namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.Extensions.Logging;

    using Models;

    using ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders;

    public class AddOrderToSupplyListCommand : IRequest
    {
        #region Constructor

        public AddOrderToSupplyListCommand(IEnumerable<OrderParameterModel> orders)
        {
            if (!orders.Any())
            {
                throw new UserException("No se han indicado las ordenes a suministrar.");
            }

            Orders = orders;
        }

        #endregion

        #region Properties

        public IEnumerable<OrderParameterModel> Orders { get; }

        #endregion
    }

    public class AddOrderToSupplyListCommandHandler : IRequestHandler<AddOrderToSupplyListCommand>
    {
        #region Fields

        private readonly ILogger<AddOrderToSupplyListCommandHandler> logger;
        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly ControlPisoMX.Insulations.IMicroservice insulations;
        private readonly ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public AddOrderToSupplyListCommandHandler(
            ILogger<AddOrderToSupplyListCommandHandler> logger,
            ControlPisoMX.Cores.IMicroservice cores,
            ControlPisoMX.Insulations.IMicroservice insulations,
            ERP.IMicroservice erp)
        {
            this.logger = logger;
            this.cores = cores;
            this.insulations = insulations;
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(AddOrderToSupplyListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Registrando las ordenes como disponibles para suministrar núcleos.");

                List<MOSupplyParameterModel> ordersToSupply = new();

                foreach (OrderParameterModel order in request.Orders)
                {
                    logger.LogInformation("Marcando orden {itemId}-{batch}-{serie} como disponible para suministrar núcleos.", order.ItemId, order.Batch, order.Serie);

                    List<MOPrintableAttributeModel> printableAttributes = new();

                    ControlPisoMX.Insulations.Models.ManufacturingPlanItemModel? scheduledOrder = await insulations
                        .GetManufacturingPlanBySerieAsync(order.ItemId, order.Batch, order.Serie, order.Sequence, cancellationToken)
                        .ConfigureAwait(false);

                    if (scheduledOrder != null)
                    {
                        ControlPisoMX.Insulations.Models.ManufacturingItemModel? insulation = await insulations
                           .GetManufacturingOrderAsync(scheduledOrder.ItemId, scheduledOrder.Batch, scheduledOrder.Serie, cancellationToken)
                           .ConfigureAwait(false);

                        if (insulation is not null && (insulation.Status == (int)InsulationsState.Finished || insulation.Status == (int)InsulationsState.InProgress || insulation.Status == (int)InsulationsState.Pending))
                        {
                            printableAttributes.Add(new MOPrintableAttributeModel() { Attribute = "Market", Value = scheduledOrder.Market });

                            printableAttributes.AddRange(await erp
                                .GetMOPrintableAttributesAsync(scheduledOrder.ItemId, scheduledOrder.Batch, scheduledOrder.Serie)
                                .ConfigureAwait(false));

                            ordersToSupply.Add(new MOSupplyParameterModel(
                                scheduledOrder.ItemId,
                                scheduledOrder.Batch,
                                scheduledOrder.Serie,
                                scheduledOrder.Sequence,
                                scheduledOrder.ScheduledDate,
                                scheduledOrder.Machine,
                                printableAttributes)
                            {
                                ProductLine = scheduledOrder.ProductLine,
                                Phases = scheduledOrder.Phases
                            });
                        }
                        else
                        {
                            throw new UserException($"La fabricación de los aislamientos de la orden {order.ItemId}-{order.Batch}-{order.Serie} no se ha terminado.");
                        }
                    }
                    else
                    {
                        throw new UserException($"La orden {order.ItemId}-{order.Batch}-{order.Serie} no existe en el programa de fabricación de bobinas.");
                    }
                }

                if (ordersToSupply.Any())
                {
                    await cores.AddOrdersToSupplyListAsync(ordersToSupply, cancellationToken).ConfigureAwait(false);
                }

                return Unit.Value;
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al registrar las ordenes como disponibles para suministrar núcleos.");

                    throw UserException.WithInnerException("Ocurrió un error al registrar las ordenes como disponibles para suministrar núcleos.", ex);
                }

                throw;
            }
        }

        #endregion
    }
}