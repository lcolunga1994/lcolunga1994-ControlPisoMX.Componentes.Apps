namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Commands
{
    using System.Threading.Tasks;

    using MediatR;

    public class ChangeAllowManufacturingCommand : IRequest
    {
        #region Constructor

        public ChangeAllowManufacturingCommand(bool allow)
        {
            Allow = allow;
        }

        #endregion

        #region Properties

        public bool Allow { get; set; }

        #endregion
    }

    public class ChangesAllowManufacturingCommandHandler : IRequestHandler<ChangeAllowManufacturingCommand>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public ChangesAllowManufacturingCommandHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(ChangeAllowManufacturingCommand request, CancellationToken cancellationToken)
        {
            await service
                .ChangeAllowManufacturingAsync(request.Allow, CancellationToken.None)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}