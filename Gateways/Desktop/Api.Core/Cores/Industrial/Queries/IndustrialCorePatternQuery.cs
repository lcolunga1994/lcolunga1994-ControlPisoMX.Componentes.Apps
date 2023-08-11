namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Models;

    public class IndustrialCorePatternQuery : IRequest<IndustrialCorePatternModel>
    {
        #region Constructor

        public IndustrialCorePatternQuery() { }

        #endregion
    }

    public class IndustrialCorePatternQueryHandler : IRequestHandler<IndustrialCorePatternQuery, IndustrialCorePatternModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public IndustrialCorePatternQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCorePatternModel?> Handle(
            IndustrialCorePatternQuery request,
            CancellationToken cancellationToken)
        {
            IndustrialCorePatternModel? corePatternDesign = null;

            ControlPisoMX.Cores.Models.IndustrialCorePatternModel? summary = await cores
                .GetIndustrialCorePatternAsync()
                .ConfigureAwait(false);

            if (summary != null)
            {
                corePatternDesign = new IndustrialCorePatternModel(
                    summary.ItemId,
                    summary.Batch,
                    summary.Serie,
                    summary.KVA,
                    summary.PrimaryVoltage,
                    summary.SecondaryVoltage,
                    summary.TestVoltage,
                    summary.MinLimit,
                    summary.MaxLimit)
                {
                    TotalTests = summary.TotalTests
                };
            }

            return corePatternDesign;
        }

        #endregion
    }
}