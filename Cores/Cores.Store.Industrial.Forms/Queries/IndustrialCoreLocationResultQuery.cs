namespace ProlecGE.ControlPisoMX.Cores.Storing.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

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

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public IndustrialCoreLocationResultQueryHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handle

        public async Task<IndustrialCoreLocationResultModel?> Handle(IndustrialCoreLocationResultQuery request, CancellationToken cancellationToken)
            => await service.GetIndustrialCoreLocationResultAsync(request.TestCode).ConfigureAwait(false);

        #endregion
    }
}