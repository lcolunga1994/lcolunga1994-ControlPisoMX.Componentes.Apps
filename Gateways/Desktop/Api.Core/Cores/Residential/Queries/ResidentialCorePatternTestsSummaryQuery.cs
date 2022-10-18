namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

    public class ResidentialCorePatternTestsSummaryQuery : IRequest<ResidentialCorePatternTestsSummaryModel>
    {
        #region Constructor

        public ResidentialCorePatternTestsSummaryQuery() { }

        #endregion
    }

    public class ResidentialCorePatternTestsSummaryQueryHandler : IRequestHandler<ResidentialCorePatternTestsSummaryQuery, ResidentialCorePatternTestsSummaryModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public ResidentialCorePatternTestsSummaryQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCorePatternTestsSummaryModel?> Handle(
            ResidentialCorePatternTestsSummaryQuery request,
            CancellationToken cancellationToken)
        {
            ResidentialCorePatternTestsSummaryModel? testsSummary = null;

            ControlPisoMX.Cores.Models.ResidentialCorePatternModel? summary = await cores
                .GetResidentialCorePatternAsync()
                .ConfigureAwait(false);

            if (summary != null)
            {
                testsSummary = new ResidentialCorePatternTestsSummaryModel(
                    summary.ItemId,
                    summary.Batch,
                    summary.Serie,
                    summary.KVA,
                    summary.PrimaryVoltage,
                    summary.SecondaryVoltage,
                    summary.TestVoltage,
                    summary.TotalTests,
                    summary.Limits
                        .Select(l => new ResidentialCorePatternVoltageLimitModel((CoreLimitColor)(int)l.Color, l.Min, l.Max))
                        .ToList());
            }

            return testsSummary;
        }

        #endregion
    }
}