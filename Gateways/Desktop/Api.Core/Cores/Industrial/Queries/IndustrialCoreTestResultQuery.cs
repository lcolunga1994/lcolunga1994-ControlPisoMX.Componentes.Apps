namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Models;

    public class IndustrialCoreTestResultQuery : IRequest<IndustrialCoreTestResultModel?>
    {
        #region Constructor

        public IndustrialCoreTestResultQuery(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class ResidentialCoreTestResultQueryHandler : IRequestHandler<IndustrialCoreTestResultQuery, IndustrialCoreTestResultModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public ResidentialCoreTestResultQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCoreTestResultModel?> Handle(IndustrialCoreTestResultQuery request, CancellationToken cancellationToken)
        {
            IndustrialCoreTestResultModel? coreTestResult = null;

            ControlPisoMX.Cores.Models.IndustrialCoreTestResultModel? industrialCoreTestResult = await cores.GetIndustrialCoreTestResultAsync(request.TestCode).ConfigureAwait(false);

            if (industrialCoreTestResult != null)
            {
                coreTestResult = new IndustrialCoreTestResultModel(
                    industrialCoreTestResult.ItemId,
                    industrialCoreTestResult.Batch,
                    industrialCoreTestResult.Serie,
                    industrialCoreTestResult.TestCode,
                    (CoreTestResult)(int)industrialCoreTestResult.Result,
                    industrialCoreTestResult.CorrectedWatts,
                    industrialCoreTestResult.CurrentPercentage,
                    industrialCoreTestResult.Warnings.Select(warning => (CoreTestWarning)(int)warning).ToArray(),
                    industrialCoreTestResult.TotalCores,
                    industrialCoreTestResult.TestedCores,
                    industrialCoreTestResult.TotalTests,
                    (CoreSizes)(int)industrialCoreTestResult.CoreSize
                    );
            }

            return coreTestResult;
        }

        #endregion
    }
}