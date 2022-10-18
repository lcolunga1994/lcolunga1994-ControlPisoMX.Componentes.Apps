namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components;

    public class IndustrialCoreVoltageDesignQuery : IRequest<IndustrialItemVoltageDesignModel?>
    {
        #region Constructor

        public IndustrialCoreVoltageDesignQuery(string itemId, int coreSize, double foilWidth)
        {
            ItemId = itemId;
            CoreSize = coreSize;
            FoilWidth = foilWidth;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public int CoreSize { get; }

        public double FoilWidth { get; }

        #endregion
    }

    public class IndustrialCoreVoltageDesignQueryHandler : IRequestHandler<IndustrialCoreVoltageDesignQuery, IndustrialItemVoltageDesignModel?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores; 
        private readonly AppSettings _appSettings;

        #endregion

        #region Constructor

        public IndustrialCoreVoltageDesignQueryHandler(ControlPisoMX.Cores.IMicroservice cores, AppSettings _appSettings)
        {
            this.cores = cores;
            this._appSettings = _appSettings;
        }

        #endregion

        #region Methods

        public async Task<IndustrialItemVoltageDesignModel?> Handle(
            IndustrialCoreVoltageDesignQuery request,
            CancellationToken cancellationToken)
        {
            IndustrialItemVoltageDesignModel? result = null;

            if (_appSettings.AmbientERP)
            {
                ControlPisoMX.Cores.Models.IndustrialItemVoltageDesignModel? itemVoltage = await cores
                .GetIndustrialCoreVoltageDesignAsync(request.ItemId, request.CoreSize, request.FoilWidth)
                .ConfigureAwait(false);

                if (itemVoltage != null)
                {
                    result = new IndustrialItemVoltageDesignModel(
                        itemVoltage.ItemId,
                        (CoreSizes)itemVoltage.CoreSize,
                        itemVoltage.FoilWidth,
                        itemVoltage.KVA,
                        itemVoltage.PrimaryVoltage,
                        itemVoltage.SecondaryVoltage,
                        itemVoltage.TestVoltage,
                        itemVoltage.MinWattsLimit,
                        itemVoltage.MaxWattsLimit);
                }
            }
            else
            {
                ControlPisoMX.Cores.Models.IndustrialItemVoltageDesignModel? itemVoltage = await cores
                .GetIndustrialCoreVoltageDesignAsync_sqlctp(request.ItemId, request.CoreSize, request.FoilWidth)
                .ConfigureAwait(false);

                if (itemVoltage != null)
                {
                    result = new IndustrialItemVoltageDesignModel(
                        itemVoltage.ItemId,
                        (CoreSizes)itemVoltage.CoreSize,
                        itemVoltage.FoilWidth,
                        itemVoltage.KVA,
                        itemVoltage.PrimaryVoltage,
                        itemVoltage.SecondaryVoltage,
                        itemVoltage.TestVoltage,
                        itemVoltage.MinWattsLimit,
                        itemVoltage.MaxWattsLimit);
                }
            }

            return result;            
        }

        #endregion
    }
}