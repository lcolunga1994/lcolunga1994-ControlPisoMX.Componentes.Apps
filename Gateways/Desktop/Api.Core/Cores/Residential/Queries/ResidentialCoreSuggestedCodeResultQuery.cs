namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

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

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public ResidentialCoreSuggestedCodeResultQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreSuggestedCodeResultModel?> Handle(ResidentialCoreSuggestedCodeResultQuery request, CancellationToken cancellationToken)
        {
            ResidentialCoreSuggestedCodeResultModel? suggestedCode = null;

            ControlPisoMX.Cores.Models.Residential.ResidentialCoreSuggestedCodeModel? residentialCoreSuggestedCode =
                await cores.GetResidentialCoreSuggestedCode(request.TestCode).ConfigureAwait(false);

            if (residentialCoreSuggestedCode != null)
            {
                suggestedCode = new ResidentialCoreSuggestedCodeResultModel(
                    residentialCoreSuggestedCode.SuggestedCode,
                    residentialCoreSuggestedCode.Location,
                    (CoreLimitColor?)(int?)residentialCoreSuggestedCode.Color);
            }

            return suggestedCode;
        }

        #endregion
    }
}