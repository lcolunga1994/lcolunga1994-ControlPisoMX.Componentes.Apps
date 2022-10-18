namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.Commands
{
    using System.Threading.Tasks;

    using MediatR;

    public class AuthorizeReprintCommand : IRequest
    {
        #region Constructor

        public AuthorizeReprintCommand(string itemId, string batch, int serie)
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

    public class AuthorizeReprintCommandHandler : IRequestHandler<AuthorizeReprintCommand>
    {
        #region Fields

        private readonly BFWeb.Components.ICoresSupplyService service;

        #endregion

        #region Constructor

        public AuthorizeReprintCommandHandler(BFWeb.Components.ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(AuthorizeReprintCommand request, CancellationToken cancellationToken)
        {
            await service
                .AuthorizeReprintAsync(request.ItemId, request.Batch, request.Serie)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}