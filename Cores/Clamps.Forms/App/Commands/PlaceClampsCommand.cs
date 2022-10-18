namespace ProlecGE.ControlPisoMX.Clamps.Forms.App.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using ProlecGE.ControlPisoMX.BFWeb.Components;

    public class PlaceClampsCommand : IRequest
    {
        #region Constructor

        public PlaceClampsCommand(string itemId, string batch, int serie, int sequence)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(batch))
            {
                throw new UserException("El lote no puede ser vacío o espacios en blanco.");
            }

            ItemId = itemId.Trim();
            Batch = batch.Trim();
            Serie = serie;
            Sequence = sequence;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public string Batch { get; }

        public int Serie { get; }

        public int Sequence { get; }

        #endregion
    }

    public class PlaceClampsCommandHandler : IRequestHandler<PlaceClampsCommand>
    {
        #region Fields

        private readonly IClampsService clampsService;

        #endregion

        #region Constructor

        public PlaceClampsCommandHandler(IClampsService clampsService)
        {
            this.clampsService = clampsService;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(PlaceClampsCommand request, CancellationToken cancellationToken)
        {
            await clampsService.RemoveClampAsync(request.ItemId, request.Batch, request.Serie, request.Sequence)
                .ConfigureAwait(false);
            return Unit.Value;
        }

        #endregion
    }
}