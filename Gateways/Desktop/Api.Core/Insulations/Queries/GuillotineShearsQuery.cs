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

    public class GuillotineShearsQuery : IRequest<IEnumerable<GuillotineShearModel>>
    {
        #region Constructor

        public GuillotineShearsQuery(
            string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    public class GuillotineShearsQueryHandler : IRequestHandler<GuillotineShearsQuery, IEnumerable<GuillotineShearModel>>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public GuillotineShearsQueryHandler(ControlPisoMX.ERP.IMicroservice erp,
           IConfiguration configuration)
        {
            this.erp = erp;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GuillotineShearModel>> Handle(GuillotineShearsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ControlPisoMX.ERP.Models.GuillotineShearModel> items = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
                await erp.GetItemGuillotineShearsAsync(request.ItemId, cancellationToken).ConfigureAwait(false):
                await erp.GetItemGuillotineShearsAsync_LN(request.ItemId,int.Parse(_configuration.GetSection("Cia").Value.ToString()), cancellationToken).ConfigureAwait(false);
            return items
            .Select(item => new GuillotineShearModel()
            {
                DesignId = item.DesignId,
                Item = item.Item,
                Description = item.Description,
                Quantity = item.Quantity,
                A = item.A,
                B = item.B,
                Y = item.Y,
                T = item.T,
                Dimensions = item.Dimensions,
                Fold = item.Fold,
            })
            .ToList();
        }

        #endregion
    }
}