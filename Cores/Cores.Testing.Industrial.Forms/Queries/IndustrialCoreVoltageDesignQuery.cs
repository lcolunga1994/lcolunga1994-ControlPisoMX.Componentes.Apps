namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

    public class IndustrialCoreVoltageDesignQuery : IRequest<IndustrialItemVoltageDesignModel?>
    {
        #region Constructor

        public IndustrialCoreVoltageDesignQuery(string itemId, CoreSizes size, double foilWidth)
        {
            FoilWidth = foilWidth;
            ItemId = itemId;
            Size = size;
        }

        #endregion

        #region Properties

        public double FoilWidth { get; internal set; }

        public string ItemId { get; internal set; }

        public CoreSizes Size { get; internal set; }

        #endregion
    }

    public class CoreVoltageDesignQueryHandler
        : IRequestHandler<IndustrialCoreVoltageDesignQuery, IndustrialItemVoltageDesignModel?>
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public CoreVoltageDesignQueryHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<IndustrialItemVoltageDesignModel?> Handle(
            IndustrialCoreVoltageDesignQuery request,
            CancellationToken cancellationToken)
        {
            return await service
                 .GetIndustrialCoreVoltageDesignAsync(
                    request.ItemId,
                    (int)request.Size,
                    request.FoilWidth)
                 .ConfigureAwait(false);
        }

        #endregion
    }
}