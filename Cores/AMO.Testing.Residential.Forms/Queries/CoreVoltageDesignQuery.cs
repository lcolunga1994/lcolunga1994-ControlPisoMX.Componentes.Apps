namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;

    public class CoreVoltageDesignQuery : IRequest<CoreVoltageDesignModel?>
    {
        #region Constructor

        public CoreVoltageDesignQuery(string code, CoreSizes size)
        {
            Code = code;
            Size = size;
        }

        #endregion

        #region Properties

        public string Code { get; internal set; }

        public CoreSizes Size { get; internal set; }

        #endregion
    }

    public class CoreVoltageDesignQueryHandler
        : IRequestHandler<CoreVoltageDesignQuery, CoreVoltageDesignModel?>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public CoreVoltageDesignQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<CoreVoltageDesignModel?> Handle(
            CoreVoltageDesignQuery request,
            CancellationToken cancellationToken)
        {
            return await service
                 .GetResidentialCoreVoltageDesignAsync(
                    request.Code,
                    (int)request.Size,
                    cancellationToken)
                 .ConfigureAwait(false);
        }

        #endregion
    }
}