namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Commands
{
    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public class AddSupplyCoreCommand : IRequest
    {
        #region Constructor

        public AddSupplyCoreCommand(AddSupplyCoreModel supply)
        {
            Supply = supply;
        }

        #endregion

        #region Properties

        public AddSupplyCoreModel Supply { get; set; }

        #endregion
    }

    public class AddSupplyCoreCommandHandler : IRequestHandler<AddSupplyCoreCommand>
    {
        #region Fields

        private readonly BFWeb.Components.IResidentialCoresService service;

        #endregion

        #region Constructor

        public AddSupplyCoreCommandHandler(BFWeb.Components.IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(AddSupplyCoreCommand request, CancellationToken cancellationToken)
        {
            await service
                .AddSupplyCoreAsync(request.Supply, cancellationToken)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}
