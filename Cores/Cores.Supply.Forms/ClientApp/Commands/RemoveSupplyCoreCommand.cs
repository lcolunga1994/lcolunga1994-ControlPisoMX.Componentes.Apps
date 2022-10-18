namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Commands
{
    using System;
    using System.Threading.Tasks;
    using MediatR;

    public class RemoveSupplyCoreCommand : IRequest
    {
        #region Constructor

        public RemoveSupplyCoreCommand(Guid id)
        {
            Id = id;
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        #endregion
    }

    public class RemoveSupplyCoreCommandHandler : IRequestHandler<RemoveSupplyCoreCommand>
    {
        #region Fields

        private readonly BFWeb.Components.IResidentialCoresService service;

        #endregion

        #region Constructor

        public RemoveSupplyCoreCommandHandler(BFWeb.Components.IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(RemoveSupplyCoreCommand request, CancellationToken cancellationToken)
        {
            await service
                .RemoveSupplyCoreAsync(request.Id, cancellationToken)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}
