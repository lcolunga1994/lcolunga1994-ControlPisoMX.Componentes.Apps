namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Queries
{
    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    using System.Threading;
    using System.Threading.Tasks;

    public class ManufacturedCoresQuery
        : IRequest<BFWeb.Components.Cores.QueryResult<ManufacturedResidentialCoreModel>>
    {
        #region Constructor

        public ManufacturedCoresQuery(
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

    public class ManufacturedCoresQueryHandler
        : IRequestHandler<ManufacturedCoresQuery, BFWeb.Components.Cores.QueryResult<ManufacturedResidentialCoreModel>>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public ManufacturedCoresQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }
        #endregion

        #region Methods

        public async Task<BFWeb.Components.Cores.QueryResult<ManufacturedResidentialCoreModel>> Handle(
            ManufacturedCoresQuery request,
            CancellationToken cancellationToken)
        {
            return await service
                .GetManufacturedCoresAsync(
                    request.Page,
                    request.PageSize,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}