namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;

    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Models;

    public class ItemAluminumTipsQuery : IRequest<AluminumTipPuntasModel?>
    {
        #region Constructor

        public ItemAluminumTipsQuery(
            string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    public class ItemAluminumTipsQueryHandler : IRequestHandler<ItemAluminumTipsQuery, AluminumTipPuntasModel?>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public ItemAluminumTipsQueryHandler(ControlPisoMX.ERP.IMicroservice erp, IConfiguration configuration)
        {
            this.erp = erp;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<AluminumTipPuntasModel?> Handle(ItemAluminumTipsQuery request, CancellationToken cancellationToken)
        {
            ControlPisoMX.ERP.Models.AluminumTipPuntasModel? material = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
            await erp.GetItemAluminumTipsAsync(request.ItemId, cancellationToken).ConfigureAwait(false):
            await erp.GetItemAluminumTipsAsync_LN(request.ItemId,int.Parse(_configuration.GetSection("Cia").Value.ToString()), cancellationToken).ConfigureAwait(false);
            if (material == null)
            {
                return null;
            }
            else
            {
                return new AluminumTipPuntasModel()
                {
                    Materials = material.Materials.Select(e => new AluminumShearModel()
                    {
                        DesignId = e.DesignId,
                        Item = e.Item,
                        Description = e.Description,
                        Quantity = e.Quantity,
                        L = e.L,
                        A = e.A,
                        T = e.T,
                        Dimensions = e.Dimensions
                    }),
                    PuntasIni = new AluminumTipModel() { BTE = material.PuntasIni.BTE, BTI = material.PuntasIni.BTI },
                    PuntasFin = new AluminumTipModel() { BTE = material.PuntasFin.BTE, BTI = material.PuntasFin.BTI },
                };
            }           
        }

        #endregion
    }
}