namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.Queries
{

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    internal class MOSuppliesToReprintSupplyQuery : IRequest<IEnumerable<MOSupplyItemModel>> { }

    internal class MOSuppliesToReprintSupplyQueryHandler : IRequestHandler<MOSuppliesToReprintSupplyQuery, IEnumerable<MOSupplyItemModel>>
    {
        #region Fields

        private readonly ICoresSupplyService service;

        #endregion

        #region Constructor

        public MOSuppliesToReprintSupplyQueryHandler(ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<MOSupplyItemModel>> Handle(MOSuppliesToReprintSupplyQuery query, CancellationToken cancellationToken)
        {
            return await service
                .GetSuppliesToReprintAsync()
                .ConfigureAwait(false);
        }

        #endregion
    }
}