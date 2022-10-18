namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Queries
{
    using MediatR;

    using Models;

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AluminiumCutsQuery : IRequest<IEnumerable<AluminiumCutModel>>
    {
        #region Constructor

        public AluminiumCutsQuery(
            string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    public class AluminiumCutsQueryHandler : IRequestHandler<AluminiumCutsQuery, IEnumerable<AluminiumCutModel>>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;
        
        #endregion

        #region Constructor

        public AluminiumCutsQueryHandler(ControlPisoMX.ERP.IMicroservice erp)
        {
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<AluminiumCutModel>> Handle(AluminiumCutsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ControlPisoMX.ERP.Models.AluminiumCutModel> items = await erp.GetItemAluminiumCutsAsync(request.ItemId, cancellationToken)
                 .ConfigureAwait(false);

            return items
                .Select(item => new AluminiumCutModel()
                {
                    DesignId = item.DesignId,
                    Item = item.Item,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    L = item.L,
                    A = item.A,
                    B = item.B,
                    T = item.T,
                    Dimensions = item.Dimensions
                })
                .ToList();
        }

        #endregion
    }
}