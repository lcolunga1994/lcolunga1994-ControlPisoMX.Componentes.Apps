namespace ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models;

    internal class ClampQuery : IRequest<ClampModel?>
    {
        #region Constructor

        public ClampQuery(string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    internal class ClampsQueryHandler : IRequestHandler<ClampQuery, ClampModel?>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public ClampsQueryHandler(ControlPisoMX.ERP.IMicroservice erp)
        {
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<ClampModel?> Handle(ClampQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ERP.Models.ItemClampModel>? itemClamp = await erp.GetItemClampsAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);

            return itemClamp.Where(e => e.Place == "Top").Select(clamp => new ClampModel()
            {
                DrawId = clamp.DrawId,
            }).FirstOrDefault();
        }
        #endregion
    }
}
