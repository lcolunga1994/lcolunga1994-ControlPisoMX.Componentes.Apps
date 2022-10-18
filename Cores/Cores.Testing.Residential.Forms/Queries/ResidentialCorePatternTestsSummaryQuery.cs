namespace ProlecGE.ControlPisoMX.Cores.Testing.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    public class ResidentialCorePatternTestsSummaryQuery
        : IRequest<ResidentialCorePatternTestsSummaryModel?>
    {
        #region Constructor

        public ResidentialCorePatternTestsSummaryQuery() { }

        #endregion
    }

    public class ResidentialCorePatternTestsSummaryQueryHandler
        : IRequestHandler<ResidentialCorePatternTestsSummaryQuery, ResidentialCorePatternTestsSummaryModel?>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public ResidentialCorePatternTestsSummaryQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCorePatternTestsSummaryModel?> Handle(
            ResidentialCorePatternTestsSummaryQuery request,
            CancellationToken cancellationToken)
            => await service
            .GetResidentialCorePatternTestSummaryAsync()
            .ConfigureAwait(false);

        #endregion
    }
}