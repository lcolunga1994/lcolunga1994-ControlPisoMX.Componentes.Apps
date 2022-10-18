namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public class MOSuppliesPendingQueryQuery : MediatR.IRequest<IEnumerable<MOSupplyItemModel>> { }

    public class MOSuppliesPendingQueryHandler : MediatR.IRequestHandler<MOSuppliesPendingQueryQuery, IEnumerable<MOSupplyItemModel>>
    {
        #region Fields

        private readonly BFWeb.Components.ICoresSupplyService service;

        #endregion

        #region Constructor

        public MOSuppliesPendingQueryHandler(BFWeb.Components.ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<MOSupplyItemModel>> Handle(MOSuppliesPendingQueryQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetPendingSuppliesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}