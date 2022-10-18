namespace ProlecGE.ControlPisoMX.Cores.Storing.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    public class ResidentialCoreSuggestedCodeResultQuery : IRequest<ResidentialCoreSuggestedCodeResultModel?>
    {
        #region Constructor

        public ResidentialCoreSuggestedCodeResultQuery(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class ResidentialCoreSuggestedCodeResultQueryHandler : IRequestHandler<ResidentialCoreSuggestedCodeResultQuery, ResidentialCoreSuggestedCodeResultModel?>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public ResidentialCoreSuggestedCodeResultQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreSuggestedCodeResultModel?> Handle(ResidentialCoreSuggestedCodeResultQuery request, CancellationToken cancellationToken)
            => await service.GetResidentialCoreSuggestedCodeResultAsync(request.TestCode).ConfigureAwait(false);

        #endregion
    }
}
