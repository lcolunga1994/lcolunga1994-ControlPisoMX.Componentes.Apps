namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

    public class ManufacturedCoresQuery : PaginatedQuery,
        IRequest<QueryResult<ManufacturedResidentialCoreModel>>
    {
        #region Constructor

        public ManufacturedCoresQuery(int page = 1, int pageSize = 100)
            : base(page, pageSize) { }

        #endregion
    }

    public class ManufacturedCoresQueryHandler
        : IRequestHandler<ManufacturedCoresQuery, QueryResult<ManufacturedResidentialCoreModel>>
    {
        #region Fields

        private readonly ControlPisoMX.I40.IMicroservice i40;

        #endregion

        #region Constructor

        public ManufacturedCoresQueryHandler(
            ControlPisoMX.I40.IMicroservice i40)
        {
            this.i40 = i40;
        }

        #endregion

        #region Methods

        public async Task<QueryResult<ManufacturedResidentialCoreModel>> Handle(
            ManufacturedCoresQuery request,
            CancellationToken cancellationToken)
        {
            I40.QueryResult<I40.Models.ManufacturedCoreModel> manufacturedCores =
                await i40.GetManufacturedCoresAsync(
                    request.Page,
                    request.PageSize,
                    cancellationToken)
                .ConfigureAwait(false);

            System.Collections.Generic.List<ManufacturedResidentialCoreModel> items = manufacturedCores.Data
                .Select(trancoTag => new ManufacturedResidentialCoreModel(
                    trancoTag.Tag,
                    trancoTag.ItemId,
                    trancoTag.Batch,
                    trancoTag.Sequence,
                    (CoreSizes)trancoTag.Size,
                    trancoTag.ScheduledUtcDate))
                .ToList();

            return new QueryResult<ManufacturedResidentialCoreModel>(items, manufacturedCores.Count);
        }

        #endregion
    }
}