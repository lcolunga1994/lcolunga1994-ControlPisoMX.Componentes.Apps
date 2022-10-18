namespace ProlecGE.ControlPisoMX.Cores.Storing.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    public class ResidentialCoreTestQuery : IRequest<ResidentialCoreTestModel?>
    {
        #region Constructor

        public ResidentialCoreTestQuery(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class ResidentialCoreTestQueryHandler : IRequestHandler<ResidentialCoreTestQuery, ResidentialCoreTestModel?>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public ResidentialCoreTestQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestModel?> Handle(
            ResidentialCoreTestQuery request,
            CancellationToken cancellationToken)
            => await service.GetResidentialCoreTestAsync(request.TestCode).ConfigureAwait(false);

        #endregion
    }
}