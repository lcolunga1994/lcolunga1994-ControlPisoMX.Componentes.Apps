namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Models;

    public class IndustrialCoreSuggestedCodeResultQuery : IRequest<IndustrialCoreSuggestedCodeResultModel?>
    {
        #region Constructor

        public IndustrialCoreSuggestedCodeResultQuery(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class IndustrialCoreSuggestedCodeResultQueryHandler : IRequestHandler<IndustrialCoreSuggestedCodeResultQuery, IndustrialCoreSuggestedCodeResultModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public IndustrialCoreSuggestedCodeResultQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCoreSuggestedCodeResultModel?> Handle(IndustrialCoreSuggestedCodeResultQuery request, CancellationToken cancellationToken)
        {
            IndustrialCoreSuggestedCodeResultModel? suggestedCode = null;

            ControlPisoMX.Cores.Models.Industrial.IndustrialCoreSuggestedCodeModel? industrialCoreSuggestedCode =
                await cores.GetIndustrialCoreSuggestedCode(request.TestCode).ConfigureAwait(false);
            if (industrialCoreSuggestedCode != null)
            {
                suggestedCode = new IndustrialCoreSuggestedCodeResultModel(
                  industrialCoreSuggestedCode.SuggestedCode,
                  industrialCoreSuggestedCode.Location,
                  CoreLimitColor.None
                  );
            }
            return suggestedCode;
        }

        #endregion
    }
}