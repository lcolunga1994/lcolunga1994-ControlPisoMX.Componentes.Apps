namespace ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models;

    internal class ItemLVConnectingQuery : IRequest<LVConnetingModel>
    {
        #region Constructor

        public ItemLVConnectingQuery(string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    internal class ItemLVConnectingQueryHandler : IRequestHandler<ItemLVConnectingQuery, LVConnetingModel?>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public ItemLVConnectingQueryHandler(ControlPisoMX.ERP.IMicroservice erp)
        {
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<LVConnetingModel?> Handle(ItemLVConnectingQuery request, CancellationToken cancellationToken)
        {
            LVConnetingModel itemLVConneting = new();

            ERP.Models.ItemModel? itemPolarity = await erp.GetItemGeneralDataAsync(request.ItemId, cancellationToken).ConfigureAwait(false);

            IEnumerable<ERP.Models.PositionModel>? itemPosition = await erp.GetPositionsAsync(request.ItemId, cancellationToken).ConfigureAwait(false);

            if (itemPolarity == null || itemPosition == null)
            {
                return null;
            }

            itemLVConneting.Polarity = itemPolarity?.Polarity ?? "";

            foreach (ERP.Models.PositionModel position in itemPosition)
            {
                itemLVConneting.Position.Add(new PositionModel()
                {
                   PositionName = position.Position,
                   Voltage = position.Voltage,
                   Nominal = position.Nominal,
                   Min = position.Min,
                   Max = position.Max,
                });
            }

            return itemLVConneting;
        }

        #endregion
    }
}
