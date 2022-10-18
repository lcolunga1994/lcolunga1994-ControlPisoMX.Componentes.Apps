namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;

    using MediatR;

    using Models;

    public class SierraShearsQuery : IRequest<IEnumerable<SierraShearModel>>
    {
        #region Constructor

        public SierraShearsQuery(
            string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    public class SierraShearsQueryHandler : IRequestHandler<SierraShearsQuery, IEnumerable<SierraShearModel>>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;
        private readonly AppSettings _appSettings;
        private readonly LN.ITtxpcf925Repository ln;

        #endregion

        #region Constructor

        public SierraShearsQueryHandler(ControlPisoMX.ERP.IMicroservice erp, AppSettings _appSettings, LN.ITtxpcf925Repository ln)
        {
            this.erp = erp;
            this._appSettings = _appSettings;
            this.ln = ln;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<SierraShearModel>> Handle(SierraShearsQuery request, CancellationToken cancellationToken)
        {
            if (_appSettings.AmbientERP)
            {
                IEnumerable<ControlPisoMX.ERP.Models.SierraShearModel> items = await erp.GetItemSierraShearsAsync(request.ItemId, cancellationToken)
                 .ConfigureAwait(false);

                return items
                .Select(item => new SierraShearModel()
                {
                    DesignId = item.DesignId,
                    Item = item.Item,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    L = item.L,
                    A = item.A,
                    B = item.B,
                    Y = item.Y,
                    T = item.T,
                    Dimensions = item.Dimensions,
                    Fold = item.Fold,
                })
                .ToList();
            }
            else
            {
                IEnumerable<ProlecGE.ControlPisoMX.BFWeb.Components.Services.LN.Models.SierraShearModel> items =
                    await ln.GetItemSierraShearsAsync(_appSettings.cia, request.ItemId, cancellationToken)
                 .ConfigureAwait(false);

                return items
                .Select(item => new SierraShearModel()
                {
                    DesignId = item.DesignId,
                    Item = item.Item,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    L = item.L,
                    A = item.A,
                    B = item.B,
                    Y = item.Y,
                    T = item.T,
                    Dimensions = item.Dimensions,
                    Fold = item.Fold,
                })
                .ToList();
            }
        }

        #endregion
    }
}