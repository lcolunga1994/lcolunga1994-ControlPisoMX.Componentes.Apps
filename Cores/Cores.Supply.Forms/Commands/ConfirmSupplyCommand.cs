namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.Commands
{
    using MediatR;

    public class ConfirmSupplyCommand : IRequest
    {
        #region Constructor

        public ConfirmSupplyCommand(string itemId, string batch, int serie)
        {
            itemId.ValidItemIdString();
            batch.ValidItemIdString();

            ItemId = itemId;
            Batch = batch;
            Serie = serie;
        }

        #endregion

        #region Properties

        public string ItemId { get; internal set; }

        public string Batch { get; internal set; }

        public int Serie { get; internal set; }

        #endregion
    }

    public class ConfirmSupplyCommandHandler : IRequestHandler<ConfirmSupplyCommand>
    {
        #region Fields

        private readonly BFWeb.Components.ICoresSupplyService service;

        #endregion

        #region Constructor

        public ConfirmSupplyCommandHandler(BFWeb.Components.ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(ConfirmSupplyCommand request, CancellationToken cancellationToken)
        {
            await service
                .ConfirmSupplyAsync(request.ItemId, request.Batch, request.Serie)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}