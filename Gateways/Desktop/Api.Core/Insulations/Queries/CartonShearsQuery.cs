namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;

    using MediatR;
    using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public CartonsShearsQueryHandler(ERP.IMicroservice erp, IConfiguration configuration)
        {
            this.erp = erp;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<CartonShearModel>> Handle(CartonShearsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ERP.Models.CartonShearModel> items = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
            await erp.GetItemCartonShearsAsync(request.ItemId, cancellationToken).ConfigureAwait(false) :
            await erp.GetItemCartonShearsAsync_LN(request.ItemId,int.Parse(_configuration.GetSection("Cia").Value.ToString()), cancellationToken).ConfigureAwait(false);

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

        #endregion
    }
}