namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Queries
{
    using MediatR;

    using Models;

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using Microsoft.Extensions.Configuration;

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
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public AluminiumCutsQueryHandler(ControlPisoMX.ERP.IMicroservice erp, IConfiguration configuration)
        {
            this.erp = erp;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<AluminiumCutModel>> Handle(AluminiumCutsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ERP.Models.AluminiumCutModel> items = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
            await erp.GetItemAluminiumCutsAsync(request.ItemId, cancellationToken).ConfigureAwait(false) :
            await erp.GetItemAluminiumCutsAsync_LN(request.ItemId,int.Parse(_configuration.GetSection("Cia").Value.ToString()), cancellationToken).ConfigureAwait(false);

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