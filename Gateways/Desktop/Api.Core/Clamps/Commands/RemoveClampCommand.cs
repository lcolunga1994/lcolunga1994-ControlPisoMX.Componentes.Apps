namespace ProlecGE.ControlPisoMX.BFWeb.Components.Clamps.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class RemoveClampCommand : IRequest
    {
        #region Constructor

        public RemoveClampCommand(string itemId, string batch, int serie, int sequence)
        {
            ItemId = itemId;
            Batch = batch;
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

    public class RemoveClampCommandHandler : IRequestHandler<RemoveClampCommand>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public RemoveClampCommandHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(RemoveClampCommand request, CancellationToken cancellationToken)
        {
            await cores.RemoveClampOrderAsync(request.ItemId, request.Batch, request.Serie, request.Sequence, cancellationToken)
                .ConfigureAwait(false);
            return Unit.Value;
        }

        #endregion
    }
}
