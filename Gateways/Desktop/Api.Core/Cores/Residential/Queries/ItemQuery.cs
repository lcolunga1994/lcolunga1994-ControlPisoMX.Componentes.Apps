namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.Extensions.Configuration;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;

    public class ItemQuery : IRequest<ItemModel?>
    {
        #region Constructor

        public ItemQuery(string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        #endregion
    }

    public class ItemQueryHandler : IRequestHandler<ItemQuery, ItemModel?>
    {
        #region Fields

        private readonly ERP.IMicroservice erp;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public ItemQueryHandler(ERP.IMicroservice erp, IConfiguration configuration)
        {
            this.erp = erp;
            _configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<ItemModel?> Handle(ItemQuery request, CancellationToken cancellationToken)
        {
            ERP.Models.ItemModel? item = (bool.Parse(_configuration.GetSection("UseBaan").Value.ToString())) ?
                await erp
                .GetItemAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false)
                : await erp
                .GetItemAsync_discpiso(request.ItemId, cancellationToken)
                .ConfigureAwait(false);


            return item != null
                ? new ItemModel(
                    item.ItemId,
                    item.DesignId,
                    item.Phases,
                    (ProductLine)item.ProductLine)
                {
                    CTyp = item.CTyp,
                    Citg = item.Citg
                }
                : null;
        }

        #endregion
    }
}