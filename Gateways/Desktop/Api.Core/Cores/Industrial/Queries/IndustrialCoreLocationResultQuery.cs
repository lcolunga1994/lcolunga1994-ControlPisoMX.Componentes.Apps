namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Models;

    public class IndustrialCoreLocationResultQuery : IRequest<IndustrialCoreLocationResultModel?>
    {
        #region Constructor

        public IndustrialCoreLocationResultQuery(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class IndustrialCoreLocationResultQueryHandler : IRequestHandler<IndustrialCoreLocationResultQuery, IndustrialCoreLocationResultModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public IndustrialCoreLocationResultQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods
        
        public async Task<IndustrialCoreLocationResultModel?> Handle(IndustrialCoreLocationResultQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(100);

            return new IndustrialCoreLocationResultModel("C0940044", "RACK 881", "Tranco1446");
        }

        #endregion
    }
}
