namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Queries
{
    using System.Threading.Tasks;
    using MediatR;
    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;

    public class ItemQuery : IRequest<ItemModel?>
    {
        #region Constructor

        public ItemQuery(string itemId)
        {
            ItemId = itemId.Trim();
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    internal class ItemQueryHandler : IRequestHandler<ItemQuery, ItemModel?>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public ItemQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<ItemModel?> Handle(ItemQuery request, CancellationToken cancellationToken)
            => await service.GetItemAsync(request.ItemId)
            .ConfigureAwait(false);

        #endregion
    }
}
