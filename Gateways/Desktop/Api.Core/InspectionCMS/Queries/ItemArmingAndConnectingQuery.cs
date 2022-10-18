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

    internal class ItemArmingAndConnectingQuery : IRequest<IEnumerable<ArmingAndConnectingModel>>
    {
        #region Constructor

        public ItemArmingAndConnectingQuery(string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }
    internal class ItemArmingAndConnectingQueryHandler : IRequestHandler<ItemArmingAndConnectingQuery, IEnumerable<ArmingAndConnectingModel>>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public ItemArmingAndConnectingQueryHandler(ControlPisoMX.ERP.IMicroservice erp)
        {
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<ArmingAndConnectingModel>> Handle(ItemArmingAndConnectingQuery request, CancellationToken cancellationToken)
        {
            ERP.Models.ArmingAndConnectingModel? itemArmingAndConnectionDesign = await erp.GetArmingAndConnectingAsync(request.ItemId)
                 .ConfigureAwait(false);

            if (itemArmingAndConnectionDesign == null)
            {
                return Enumerable.Empty<ArmingAndConnectingModel>();
            }
            List<ArmingAndConnectingModel> result = new();

            result.AddRange(itemArmingAndConnectionDesign.Cables
                .Select(e => new ArmingAndConnectingModel()
                {
                    Description = e.Attribute,
                    L = $"{e.L.FirstOrDefault()?.Value ?? 0d} - Cal. {e.CAL.FirstOrDefault()?.Value ?? 0d}"
                }));

            result.AddRange(itemArmingAndConnectionDesign.Changers
                .Select(e => new ArmingAndConnectingModel()
                {
                    Description = e.Attribute,
                    L = e.String1.FirstOrDefault()?.Value ?? ""
                }));

            result.AddRange(itemArmingAndConnectionDesign.Pads
                .Select(e => new ArmingAndConnectingModel()
                {
                    Description = $"{e.Attribute} ctd. {e.Double1.FirstOrDefault()?.Value ?? 0d} {e.String1.FirstOrDefault()?.Value ?? ""}",
                    L = ""
                }));

            result.AddRange(itemArmingAndConnectionDesign.Fuses
                .Select(e => new ArmingAndConnectingModel()
                {
                    Description = $"{e.Attribute} ctd. {e.Double1.FirstOrDefault()?.Value ?? 0d} {e.String1.FirstOrDefault()?.Value ?? ""}",
                    L = ""
                }));

            return result;
        }
    }

    #endregion
}
