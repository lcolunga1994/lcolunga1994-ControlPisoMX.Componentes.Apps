namespace ProlecGE.ControlPisoMX.Cores.Storing.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

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

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public IndustrialCoreSuggestedCodeResultQueryHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handle

        public async Task<IndustrialCoreSuggestedCodeResultModel?> Handle(IndustrialCoreSuggestedCodeResultQuery request, CancellationToken cancellationToken)
            => await service.GetIndustrialCoreSuggestedCodeResultAsync(request.TestCode).ConfigureAwait(false);

        #endregion
    }
}