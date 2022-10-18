namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

    public class IndustrialCorePatternDesignQuery
        : IRequest<IndustrialCorePatternModel?>
    {
        #region Constructor

        public IndustrialCorePatternDesignQuery() { }

        #endregion
    }

    public class IndustrialCorePatternDesignQueryHandler
        : IRequestHandler<IndustrialCorePatternDesignQuery, IndustrialCorePatternModel?>
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public IndustrialCorePatternDesignQueryHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<IndustrialCorePatternModel?> Handle(
            IndustrialCorePatternDesignQuery request,
            CancellationToken cancellationToken)
            => await service
            .GetIndustrialCorePatternDesignAsync()
            .ConfigureAwait(false);

        #endregion
    }
}