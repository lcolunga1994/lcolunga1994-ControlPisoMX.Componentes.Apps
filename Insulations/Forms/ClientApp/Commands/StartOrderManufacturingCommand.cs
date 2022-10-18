namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Commands
{
    using System.Threading.Tasks;

    using MediatR;

    public class StartOrderManufacturingCommand : IRequest { }

    public class StartOrderManufacturingCommandHandler : IRequestHandler<StartOrderManufacturingCommand>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public StartOrderManufacturingCommandHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(StartOrderManufacturingCommand request, CancellationToken cancellationToken)
        {
            await service
                .StartOrderManufacturingAsync(CancellationToken.None)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}