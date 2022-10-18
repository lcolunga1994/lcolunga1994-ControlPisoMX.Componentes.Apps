namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public class MOSupplyItemTagQuery : MediatR.IRequest<MOSupplyItemTagModel?>
    {
        #region Constructor

        public MOSupplyItemTagQuery(Guid id)
        {
            ManufacturingOrderId = id;
        }

        #endregion

        #region Properties

        public Guid ManufacturingOrderId { get; }

        #endregion
    }

    public class MOSupplyItemTagQueryHandler : MediatR.IRequestHandler<MOSupplyItemTagQuery, MOSupplyItemTagModel?>
    {
        #region Fields

        private readonly ICoresSupplyService service;

        #endregion

        #region Constructor

        public MOSupplyItemTagQueryHandler(ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<MOSupplyItemTagModel?> Handle(MOSupplyItemTagQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetSupplyTagAsync(request.ManufacturingOrderId)
                .ConfigureAwait(false);
        }

        #endregion
    }
}