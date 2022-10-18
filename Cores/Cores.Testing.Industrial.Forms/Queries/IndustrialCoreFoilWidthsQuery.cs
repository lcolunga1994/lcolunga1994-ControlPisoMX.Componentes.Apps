namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    public class IndustrialCoreFoilWidthsQuery : IRequest<IEnumerable<double>?>
    {
        #region
        public IndustrialCoreFoilWidthsQuery(string itemId, CoreSizes size)
        {
            ItemId = itemId;
            Size = size;
        }

        #endregion

        #region Properties

        public string ItemId { get; internal set; }

        public CoreSizes Size { get; internal set; }

        #endregion
    }

    public class IndustrialCoreFoilWidthsQueryHandler
    : IRequestHandler<IndustrialCoreFoilWidthsQuery, IEnumerable<double>?>
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public IndustrialCoreFoilWidthsQueryHandler(IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handle

        public async Task<IEnumerable<double>?> Handle(
            IndustrialCoreFoilWidthsQuery request,
            CancellationToken cancellationToken)
        {
            return await service
                 .GetIndustrialCoreFoilWidthsAsync(
                    request.ItemId,
                    (int)request.Size)
                 .ConfigureAwait(false);
        }

        #endregion
    }
}