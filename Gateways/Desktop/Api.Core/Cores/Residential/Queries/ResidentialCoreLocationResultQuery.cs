namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Queries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

    public class ResidentialCoreLocationResultQuery : IRequest<ResidentialCoreLocationResultModel?>
    {

        #region Constructor

        public ResidentialCoreLocationResultQuery(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class ResidentialCoreLocationResultQueryHandler : IRequestHandler<ResidentialCoreLocationResultQuery, ResidentialCoreLocationResultModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly ControlPisoMX.ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public ResidentialCoreLocationResultQueryHandler(ControlPisoMX.Cores.IMicroservice cores, ControlPisoMX.ERP.IMicroservice erp)
        {
            this.cores = cores;
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreLocationResultModel?> Handle(ResidentialCoreLocationResultQuery request, CancellationToken cancellationToken)
        {
            ResidentialCoreLocationResultModel? coreTestResult = null;

            ControlPisoMX.Cores.Models.Residential.ResidentialCoreTestModel? residentialCoreTest = await cores.GetResidentialCoreTestAsync(request.TestCode).ConfigureAwait(false);

            if (residentialCoreTest != null)
            {
                if (residentialCoreTest.ItemId != null)
                {
                    string machineManufacturing = await erp.GetMachineManufacturingAsync(
                        residentialCoreTest.ItemId,
                        residentialCoreTest.Batch,
                        residentialCoreTest.Serie,
                        residentialCoreTest.Sequence,
                        cancellationToken);

                    coreTestResult = new ResidentialCoreLocationResultModel(
                        residentialCoreTest.AssociatedCore,
                        residentialCoreTest.Location,
                        machineManufacturing);
                }
            }

            return coreTestResult;
        }

        #endregion
    }
}