namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Models;

    public class IndustrialCoreTestQuery : IRequest<IndustrialCoreTestModel?>
    {
        #region Constructor

        public IndustrialCoreTestQuery(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class ResidentialCoreTestQueryHandler : IRequestHandler<IndustrialCoreTestQuery, IndustrialCoreTestModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public ResidentialCoreTestQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCoreTestModel?> Handle(IndustrialCoreTestQuery request, CancellationToken cancellationToken)
        {
            IndustrialCoreTestModel? coreTestResult = null;

            ControlPisoMX.Cores.Models.IndustrialCoreTestModel? IndustrialCoreTest = await cores.GetIndustrialCoreTestAsync(request.TestCode).ConfigureAwait(false);

            if (IndustrialCoreTest != null)
            {
                coreTestResult = new IndustrialCoreTestModel(
                    IndustrialCoreTest.ItemId,
                    IndustrialCoreTest.Batch,
                    IndustrialCoreTest.Serie,
                    IndustrialCoreTest.TestCode,
                    (CoreTestResult)(int)IndustrialCoreTest.Result,
                    IndustrialCoreTest.CorrectedWatts,
                    IndustrialCoreTest.CurrentPercentage,
                    IndustrialCoreTest.TotalCores,
                    IndustrialCoreTest.TestedCores,
                    IndustrialCoreTest.TotalTests,
                    (CoreSizes?)(int?)IndustrialCoreTest.CoreSizes,
                    IndustrialCoreTest.Location,
                    IndustrialCoreTest.AssociatedCore,
                    IndustrialCoreTest.Id
                    );
            }

            return coreTestResult;
        }

        #endregion
    }
}