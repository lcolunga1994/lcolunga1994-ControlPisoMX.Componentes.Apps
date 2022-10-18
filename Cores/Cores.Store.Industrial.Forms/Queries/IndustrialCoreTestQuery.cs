namespace ProlecGE.ControlPisoMX.Cores.Storing.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

    public class IndustrialCoreTestQuery : IRequest<IndustrialCoreTestModel?>
    {
        #region Constructor

        public IndustrialCoreTestQuery(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class IndustrialCoreTestQueryHandler : IRequestHandler<IndustrialCoreTestQuery, IndustrialCoreTestModel?>
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public IndustrialCoreTestQueryHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IndustrialCoreTestModel?> Handle(IndustrialCoreTestQuery request, CancellationToken cancellationToken)
            => await service.GetIndustrialCoreTestAsync(request.TestCode).ConfigureAwait(false);

        #endregion
    }
}