namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

    public class IndustrialCoreTestResultQuery : IRequest<IndustrialCoreTestResultModel?>
    {
        #region Constructor

        public IndustrialCoreTestResultQuery(string testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string TestCode { get; internal set; }

        #endregion
    }

    public class IndustrialCoreTestResultQueryHandler : IRequestHandler<IndustrialCoreTestResultQuery, IndustrialCoreTestResultModel?>
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public IndustrialCoreTestResultQueryHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handle

        public async Task<IndustrialCoreTestResultModel?> Handle(IndustrialCoreTestResultQuery request, CancellationToken cancellationToken)
            => await service.GetIndustrialCoreTestResultAsync(request.TestCode).ConfigureAwait(false);

        #endregion
    }
}