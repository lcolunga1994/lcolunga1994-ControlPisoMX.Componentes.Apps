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


    internal class ItemLaboratoryQuery : IRequest<IEnumerable<LaboratoryModel>>
    {
        #region Constructor

        public ItemLaboratoryQuery(
            string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    internal class LaboratoryQueryHandler : IRequestHandler<ItemLaboratoryQuery, IEnumerable<LaboratoryModel>>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public LaboratoryQueryHandler(ControlPisoMX.ERP.IMicroservice erp)
        {
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<LaboratoryModel>> Handle(ItemLaboratoryQuery request, CancellationToken cancellationToken)
        {
            ERP.Models.ItemModel? item = await erp.GetItemAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);

            if (item == null)
            {
                return Enumerable.Empty<LaboratoryModel>();
            }

            ERP.Models.ItemLaboratoryModel? itemVoltageDesign = await erp.GetLaboratoryAsync(item.ItemId)
                 .ConfigureAwait(false);

            if (itemVoltageDesign == null)
            {
                return Enumerable.Empty<LaboratoryModel>();
            }

            List<LaboratoryModel> result = new();
          
            result.Add(new LaboratoryModel("KVA", itemVoltageDesign.KVA));
            result.Add(new LaboratoryModel("Clase (kV)", itemVoltageDesign.PrimaryVoltage));

            return result;
        }

        #endregion
    }
}