namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Models;

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

        #endregion

        #region Constructor

        public IndustrialCoreVoltageDesignQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<IndustrialItemVoltageDesignModel?> Handle(
            IndustrialCoreVoltageDesignQuery request,
            CancellationToken cancellationToken)
        {
            IndustrialItemVoltageDesignModel? result = null;

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

            return result;            
        }

        #endregion
    }
}