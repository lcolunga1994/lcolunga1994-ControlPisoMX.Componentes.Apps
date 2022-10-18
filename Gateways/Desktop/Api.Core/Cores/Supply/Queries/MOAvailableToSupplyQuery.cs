namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Models;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    internal class MOAvailableToSupplyQuery : IRequest<IEnumerable<MOManufacturingStatusModel>>
    {
        #region Contructor

        public MOAvailableToSupplyQuery(DateTime date, string machine)
        {
            Date = date;
            Machine = machine;            
        }

        #endregion

        #region Properties

        public DateTime Date { get; }

        public string Machine { get; }

        #endregion
    }

    internal class CMSManufacturingStatusQueryHandler
        : IRequestHandler<MOAvailableToSupplyQuery, IEnumerable<MOManufacturingStatusModel>>
    {
        #region Fields

        private readonly ControlPisoMX.Insulations.IMicroservice insulations;
        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public CMSManufacturingStatusQueryHandler(
            ControlPisoMX.Insulations.IMicroservice insulations,
            ControlPisoMX.Cores.IMicroservice cores)
        {
            this.insulations = insulations;
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<MOManufacturingStatusModel>> Handle(MOAvailableToSupplyQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ControlPisoMX.Insulations.Models.ManufacturingPlanItemModel> scheduledOrders = await insulations
                    .GetManufacturingPlanByMachineAsync(request.Date, request.Machine, cancellationToken)
                    .ConfigureAwait(false);

            IEnumerable<ControlPisoMX.Cores.Models.ManufacturingOrders.MOSupplyItemModel> supplies = await cores
                .GetSuppliesByScheduleAsync(request.Date, request.Machine)
                .ConfigureAwait(false);

            List<MOManufacturingStatusModel> ordersToSupply = new();

            foreach (ControlPisoMX.Insulations.Models.ManufacturingPlanItemModel scheduledOrder in scheduledOrders)
            {
                if (!supplies.Any(i =>
                     i.ItemId == scheduledOrder.ItemId
                     && i.Batch == scheduledOrder.Batch
                     && i.Serie == scheduledOrder.Serie))
                {
                    ControlPisoMX.Insulations.Models.ManufacturingItemModel? insulation = await insulations
                        .GetManufacturingOrderAsync(scheduledOrder.ItemId, scheduledOrder.Batch, scheduledOrder.Serie, cancellationToken)
                        .ConfigureAwait(false);

                    ControlPisoMX.Cores.Models.Residential.ResidentialCoreTestModel? coreTestResult = await cores
                        .GetResidentialCoreTestByOrder(scheduledOrder.ItemId, scheduledOrder.Batch, scheduledOrder.Serie, scheduledOrder.Sequence)
                        .ConfigureAwait(false);

                    ordersToSupply.Add(new MOManufacturingStatusModel(scheduledOrder.ItemId, scheduledOrder.Batch, scheduledOrder.Serie, scheduledOrder.Sequence)
                    {
                        Machine = scheduledOrder.Machine,
                        ScheduledDate = scheduledOrder.ScheduledDate,
                        InsulationStatus = insulation?.Status,
                        CoreTestResult = (CoreTestResult?)coreTestResult?.Status,
                        CoreTestColor = (CoreLimitColor?)coreTestResult?.Color,
                        CoreLocation = coreTestResult?.Location
                    });
                }
            }

            return ordersToSupply;
        }

        #endregion
    }
}