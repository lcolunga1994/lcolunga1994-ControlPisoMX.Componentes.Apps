namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

    public class IndustrialCoreTestSummaryQuery : IRequest<IndustrialCoreTestSummaryModel?>
    {
        #region Constructor

        public IndustrialCoreTestSummaryQuery(string itemId, string batch, int serie)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }


        #endregion
    }

    public class IndustrialCoreTestSummaryQueryHandler : IRequestHandler<IndustrialCoreTestSummaryQuery, IndustrialCoreTestSummaryModel?>
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public IndustrialCoreTestSummaryQueryHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCoreTestSummaryModel?> Handle(
            IndustrialCoreTestSummaryQuery request,
            CancellationToken cancellationToken)
            => await service.GetIndustrialCoreTestSummaryAsync(request.ItemId, request.Batch, request.Serie, cancellationToken).ConfigureAwait(false);

        #endregion
    }
}