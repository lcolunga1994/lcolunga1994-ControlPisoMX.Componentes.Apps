namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;

    using MediatR;

    using Models;

    public class CartonShearsQuery : IRequest<IEnumerable<CartonShearModel>>
    {
        #region Constructor

        public CartonShearsQuery(
            string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    public class CartonsShearsQueryHandler : IRequestHandler<CartonShearsQuery, IEnumerable<CartonShearModel>>
    {
        #region Fields

        private readonly ERP.IMicroservice erp;
        private readonly AppSettings _appSettings;
        private readonly LN.ITtxpcf925Repository ln;

        #endregion

        #region Constructor

        public CartonsShearsQueryHandler(ERP.IMicroservice erp, AppSettings _appSettings, LN.ITtxpcf925Repository ln)
        {
            this.erp = erp;
            this._appSettings = _appSettings;
            this.ln = ln;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<CartonShearModel>> Handle(CartonShearsQuery request, CancellationToken cancellationToken)
        {
            if (_appSettings.AmbientERP)
            {
                IEnumerable<ERP.Models.CartonShearModel> items =
                await erp.GetItemCartonShearsAsync(request.ItemId, cancellationToken).ConfigureAwait(false);

                return items
                    .Select(item => new CartonShearModel()
                    {
                        DesignId = item.DesignId,
                        Item = item.Item,
                        Description = item.Description,
                        Quantity = item.Quantity,
                        L = item.L,
                        A = item.A,
                        B = item.B,
                        D = item.D,
                        T = item.T,
                        Dimensions = item.Dimensions,
                        Cradle = item.Cradle,
                    })
                    .ToList();
            }
            else
            {
                IEnumerable<ProlecGE.ControlPisoMX.BFWeb.Components.Services.LN.Models.CartonShearModel> items =
                await ln.GetItemCartonShearsAsync(_appSettings.cia, request.ItemId, cancellationToken).ConfigureAwait(false);

                return items
                    .Select(item => new CartonShearModel()
                    {
                        DesignId = item.DesignId,
                        Item = item.Item,
                        Description = item.Description,
                        Quantity = item.Quantity,
                        L = item.L,
                        A = item.A,
                        B = item.B,
                        D = item.D,
                        T = item.T,
                        Dimensions = item.Dimensions,
                        Cradle = item.Cradle,
                    })
                    .ToList();
            }
        }

        #endregion
    }
}