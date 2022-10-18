namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.Queries
{
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    internal class MOSupplySummaryQuery : IRequest<MOSupplySummaryModel?>
    {
        #region Constructor

        public MOSupplySummaryQuery(string itemId, string batch)
        {
            itemId.ValidItemIdString();
            batch.ValidItemIdString();

            ItemId = itemId;
            Batch = batch;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        #endregion
    }

    internal class MOSupplySummaryQueryHandler : IRequestHandler<MOSupplySummaryQuery, MOSupplySummaryModel?>
    {
        #region Fields

        private readonly ICoresSupplyService service;

        #endregion

        #region Constructor

        public MOSupplySummaryQueryHandler(ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<MOSupplySummaryModel?> Handle(MOSupplySummaryQuery query, CancellationToken cancellationToken)
        {
            return await service
                .GetManufacturingOrderSupplySummary(query.ItemId, query.Batch)
                .ConfigureAwait(false);
        }

        #endregion
    }
}