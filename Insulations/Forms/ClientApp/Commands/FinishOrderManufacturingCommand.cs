namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Commands
{
    using System.Threading.Tasks;

    using MediatR;

    public class FinishOrderManufacturingCommand : IRequest
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public FinishOrderManufacturingCommand() { }

        #endregion

        #region Properties
        public string ItemId { set; get; } = null!;

        public string Batch { set; get; } = null!;

        public int Serie { set; get; }

        public int Sequence { set; get; }

        public string Machine { get; set; } = null!;

        public int Quantity { get; set; }

        public int Priority { get; set; }

        #endregion
    }

    public class FinishOrderManufacturingCommandHandler : IRequestHandler<FinishOrderManufacturingCommand>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public FinishOrderManufacturingCommandHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(FinishOrderManufacturingCommand request, CancellationToken cancellationToken)
        {
            await service
                .FinishOrderManufacturingAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}