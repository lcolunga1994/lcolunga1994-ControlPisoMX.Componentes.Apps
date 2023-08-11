namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Queries
{
    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;

    using System.Threading;
    using System.Threading.Tasks;

    internal class ItemsPlannedToBeManufacturedQuery : IRequest<BFWeb.Components.Cores.QueryResult<string>>
    {
        #region Constructor

        public ItemsPlannedToBeManufacturedQuery(
            int page,
            int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        #endregion

        #region Properties

        public int Page { get; set; }

        public int PageSize { get; set; }

        #endregion
    }

    internal class ItemsPlannedToBeManufacturedQueryHandler : IRequestHandler<ItemsPlannedToBeManufacturedQuery, BFWeb.Components.Cores.QueryResult<string>>
    {
        #region Fields

        private readonly IResidentialCoresService gateway;

        #endregion

        #region Constructor

        public ItemsPlannedToBeManufacturedQueryHandler(IResidentialCoresService gateway)
        {
            this.gateway = gateway;
        }

        #endregion

        #region Methods

        public async Task<BFWeb.Components.Cores.QueryResult<string>> Handle(ItemsPlannedToBeManufacturedQuery request, CancellationToken cancellationToken)
            => await gateway.GetItemsPlannedToBeManufacturedAsync_discpiso_AMO(request.Page, request.PageSize, cancellationToken)
            .ConfigureAwait(false);

        #endregion
    }
}