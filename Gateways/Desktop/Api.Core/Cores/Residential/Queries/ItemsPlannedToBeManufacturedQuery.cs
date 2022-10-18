namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Queries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components;

    public class NextItemSequenceInPlanQuery : IRequest<CoreManufacturingPlanModel?>
    {
        #region Constructor

        public NextItemSequenceInPlanQuery(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            ItemId = itemId.Trim();
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    public class NextItemSequenceInPlanQueryHandler
        : IRequestHandler<NextItemSequenceInPlanQuery, CoreManufacturingPlanModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly ControlPisoMX.I40.IMicroservice i40;
        private readonly AppSettings _appSettings;

        #endregion

        #region Constructor

        public NextItemSequenceInPlanQueryHandler(
            ControlPisoMX.Cores.IMicroservice cores,
            ControlPisoMX.I40.IMicroservice i40,
            AppSettings appSettings)
        {
            this.cores = cores;
            this.i40 = i40;
            _appSettings = appSettings;
        }

        #endregion

        #region Methods

        public async Task<CoreManufacturingPlanModel?> Handle(
            NextItemSequenceInPlanQuery request,
            CancellationToken cancellationToken)
        {
            ControlPisoMX.Cores.Models.CoreManufacturingPlanItemModel? nextManufacturingPlan = _appSettings.AmbientERP ?
                await cores
                    .GetNextItemSequenceInPlanAsync(request.ItemId, CancellationToken.None)
                    .ConfigureAwait(false)
                    : await cores
                    .GetNextItemSequenceInPlanAsync_discpiso(request.ItemId, CancellationToken.None)
                    .ConfigureAwait(false);

            return nextManufacturingPlan != null ? new CoreManufacturingPlanModel(
                    nextManufacturingPlan.ItemId,
                    nextManufacturingPlan.Batch,
                    nextManufacturingPlan.Serie,
                    nextManufacturingPlan.Sequence,
                    nextManufacturingPlan.ScheduledUtcDate)
            {
                ProductLine = (ProductLine)(int)nextManufacturingPlan.ProductLine,
                Tag = await i40.GetCoreTagAsync(
                        nextManufacturingPlan.ItemId,
                        nextManufacturingPlan.Batch,
                        nextManufacturingPlan.Sequence)
                    .ConfigureAwait(false)
            } : null;
        }

        #endregion
    }
}