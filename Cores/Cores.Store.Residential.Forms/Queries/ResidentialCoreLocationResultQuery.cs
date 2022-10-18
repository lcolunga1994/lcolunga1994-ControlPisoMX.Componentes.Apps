namespace ProlecGE.ControlPisoMX.Cores.Storing.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using global::ProlecGE.ControlPisoMX.BFWeb.Components;
    using global::ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

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

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public ResidentialCoreLocationResultQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreLocationResultModel?> Handle(ResidentialCoreLocationResultQuery request, CancellationToken cancellationToken) 
            => await service.GetResidentialCoreLocationResultAsync(request.TestCode).ConfigureAwait(false);

        #endregion
    }
}
