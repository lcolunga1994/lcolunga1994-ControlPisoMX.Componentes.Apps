using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

    public class ResidentialCoreTestQuery_discpiso : IRequest<ResidentialCoreTestModel?>
    {
        #region Constructor

        public ResidentialCoreTestQuery_discpiso(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class ResidentialCoreTestQueryHandler_discpiso : IRequestHandler<ResidentialCoreTestQuery_discpiso, ResidentialCoreTestModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public ResidentialCoreTestQueryHandler_discpiso(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestModel?> Handle(
            ResidentialCoreTestQuery_discpiso request,
            CancellationToken cancellationToken)
        {
            ResidentialCoreTestModel? coreTestResult = null;

            ControlPisoMX.Cores.Models.Residential.ResidentialCoreTestModel? residentialCoreTest = await cores.GetResidentialCoreTestAsync_discpiso(request.TestCode).ConfigureAwait(false);

            if (residentialCoreTest != null)
            {
                coreTestResult = new ResidentialCoreTestModel(
                    residentialCoreTest.ItemId,
                    residentialCoreTest.Batch,
                    residentialCoreTest.Serie,
                    residentialCoreTest.Sequence,
                    residentialCoreTest.Tag,
                    residentialCoreTest.TestCode,
                    (CoreTestResult)(int)residentialCoreTest.Status,
                    residentialCoreTest.CorrectedWatts,
                    residentialCoreTest.NewWatts,
                    residentialCoreTest.Current,
                    residentialCoreTest.CurrentPercentage,
                    (CoreLimitColor)(int)residentialCoreTest.Color,
                    residentialCoreTest.TotalCores,
                    residentialCoreTest.TestedCores,
                    residentialCoreTest.TotalTests,
                    (CoreSizes?)(int?)residentialCoreTest.CoreSizes,
                    residentialCoreTest.Location,
                    residentialCoreTest.AssociatedCore,
                    residentialCoreTest.Id);
            }

            return coreTestResult;
        }

        #endregion
    }
}
