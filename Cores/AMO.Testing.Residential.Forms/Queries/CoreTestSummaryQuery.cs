namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    public class CoreTestSummaryQuery : IRequest<ResidentialCoreTestSummaryModel?>
    {
        #region Constructor

        public CoreTestSummaryQuery(
            string itemId,
            string batch,
            int serie,
            int sequence)
        {
            ItemId = itemId.Trim();
            Batch = batch.Trim();
            Serie = serie;
            Sequence = sequence;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public string Batch { get; }

        public int Serie { get; }

        public int Sequence { get; }

        #endregion
    }

    public class CoreTestSummaryQueryHandler : IRequestHandler<CoreTestSummaryQuery, ResidentialCoreTestSummaryModel?>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public CoreTestSummaryQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestSummaryModel?> Handle(
            CoreTestSummaryQuery request,
            CancellationToken cancellationToken)
            => await service.GetResidentialCoreTestSummaryAsync(request.ItemId, request.Batch, request.Serie, request.Sequence, cancellationToken).ConfigureAwait(false);

        #endregion
    }
}