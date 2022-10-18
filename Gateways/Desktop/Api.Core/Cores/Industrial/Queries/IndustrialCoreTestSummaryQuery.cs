namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Models;

    public class IndustrialCoreTestSummaryQuery : IRequest<IndustrialCoreTestSummaryModel?>
    {
        #region Constructor

        public IndustrialCoreTestSummaryQuery(
            string itemId,
            string batch,
            int serie)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public string Batch { get; }

        public int Serie { get; }

        #endregion
    }

    public class IndustrialCoreTestSummaryQueryHandler
       : IRequestHandler<IndustrialCoreTestSummaryQuery, IndustrialCoreTestSummaryModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public IndustrialCoreTestSummaryQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCoreTestSummaryModel?> Handle(
            IndustrialCoreTestSummaryQuery request,
            CancellationToken cancellationToken)
        {
            IndustrialCoreTestSummaryModel? coreTestSummary = null;

            ControlPisoMX.Cores.Models.IndustrialCoreTestSummaryModel? summary = await cores
                .GetIndustrialCoreTestSummaryAsync(request.ItemId, request.Batch, request.Serie)
                .ConfigureAwait(false);

            if (summary != null)
            {
                coreTestSummary = new IndustrialCoreTestSummaryModel(
                    summary.ItemId,
                    summary.Batch,
                    summary.Serie)
                {
                    TotalCores = summary.TotalCores,
                    TestCode = summary.TestCode,
                    TestedCores = summary.TestedCores
                };
            }

            return coreTestSummary;
        }

        #endregion
    }
}