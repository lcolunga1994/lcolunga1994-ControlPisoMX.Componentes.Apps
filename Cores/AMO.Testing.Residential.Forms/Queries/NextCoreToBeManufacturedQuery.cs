namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    internal class NextCoreToBeManufacturedQuery : IRequest<CoreManufacturingPlanModel?>
    {
        #region Constructor

        public NextCoreToBeManufacturedQuery(string itemId)
        {
            ItemId = itemId.Trim();
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    internal class NextCoreToBeManufacturedQueryHandler : IRequestHandler<NextCoreToBeManufacturedQuery, CoreManufacturingPlanModel?>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public NextCoreToBeManufacturedQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<CoreManufacturingPlanModel?> Handle(NextCoreToBeManufacturedQuery request, CancellationToken cancellationToken)
            => await service.GetNextCoreToBeManufacturedAsync_AMO(request.ItemId, cancellationToken)
            .ConfigureAwait(false);

        #endregion
    }
}