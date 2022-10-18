namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using ProlecGE.ControlPisoMX.BFWeb.Components;

    public class IndustrialCoreFoilWidthsQuery : IRequest<IEnumerable<double>?>
    {
        #region Constructor

        public IndustrialCoreFoilWidthsQuery(string itemId, int coreSize)
        {
            ItemId = itemId;
            CoreSize = coreSize;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public int CoreSize { get; }

        #endregion
    }

    public class IndustrialCoreFoilWidthQueryHandler : IRequestHandler<IndustrialCoreFoilWidthsQuery, IEnumerable<double>?>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly AppSettings _appSettings;

        #endregion

        #region Constructor

        public IndustrialCoreFoilWidthQueryHandler(ControlPisoMX.Cores.IMicroservice cores, AppSettings _appSettings)
        {
            this.cores = cores;
            this._appSettings = _appSettings;
        }

        #endregion

        #region Methods

        //public async Task<IEnumerable<double>?> Handle(IndustrialCoreFoilWidthsQuery request, CancellationToken cancellationToken)
        //    => await cores.GetCoreFoilWidthsAsync(request.ItemId, request.CoreSize)
        //        .ConfigureAwait(false); //Comentarié Luis Colunga 24/ago/2022
        public async Task<IEnumerable<double>?> Handle(IndustrialCoreFoilWidthsQuery request, CancellationToken cancellationToken)
            => _appSettings.AmbientERP ?
            await cores.GetCoreFoilWidthsAsync(request.ItemId, request.CoreSize).ConfigureAwait(false)
            : await cores.GetCoreFoilWidthsAsync_sqlctp(request.ItemId, request.CoreSize).ConfigureAwait(false);


        #endregion
    }
}