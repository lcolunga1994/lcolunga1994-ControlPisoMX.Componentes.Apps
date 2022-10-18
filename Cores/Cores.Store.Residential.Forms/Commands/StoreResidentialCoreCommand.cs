namespace ProlecGE.ControlPisoMX.Cores.Storing.Residential.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;

    public class StoreResidentialCoreCommand : IRequest<bool>
    {
        #region Constructor

        public StoreResidentialCoreCommand(
            Guid coreTestId,
            string location,
            string? associatedCode,
            bool force)
        {
            CoreTestId = coreTestId;
            Location = location;
            AssociatedCode = associatedCode;
            Force = force;
        }

        #endregion

        #region Properties

        public Guid CoreTestId { get; }

        public string Location { get; }

        public string? AssociatedCode { get; }

        public bool Force { get; }

        #endregion
    }

    public class StoreResidentialCoreCommandHandler : IRequestHandler<StoreResidentialCoreCommand, bool>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public StoreResidentialCoreCommandHandler(
            IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(StoreResidentialCoreCommand request, CancellationToken cancellationToken)
        {
            await service.StoreResidentialCoreAsync(request.CoreTestId,
                    request.Location,
                    request.AssociatedCode,
                    request.Force,
                    cancellationToken)
                .ConfigureAwait(false);

            return true;
        }

        #endregion
    }
}