namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Queries
{
    using MediatR;

    using Models;

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ProlecGE.ControlPisoMX.BFWeb.Components;

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
        private readonly AppSettings _appSettings;
        private readonly LN.ITtxpcf925Repository ln;

        #endregion

        #region Constructor

        public AluminiumCutsQueryHandler(ControlPisoMX.ERP.IMicroservice erp, AppSettings _appSettings, LN.ITtxpcf925Repository ln)
        {
            this.erp = erp;
            this._appSettings = _appSettings;
            this.ln = ln;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<AluminiumCutModel>> Handle(AluminiumCutsQuery request, CancellationToken cancellationToken)
        {
            if (_appSettings.AmbientERP)
            {
                IEnumerable<ControlPisoMX.ERP.Models.AluminiumCutModel> items =
                await erp.GetItemAluminiumCutsAsync(request.ItemId, cancellationToken).ConfigureAwait(false);

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
            else
            {
                IEnumerable<ProlecGE.ControlPisoMX.BFWeb.Components.Services.LN.Models.AluminiumCutModel> items =
                await ln.GetItemAluminiumCutsAsync(_appSettings.cia, request.ItemId, cancellationToken).ConfigureAwait(false);

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
        }

        #endregion
    }
}