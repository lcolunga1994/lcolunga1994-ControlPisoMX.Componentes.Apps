namespace ProlecGE.ControlPisoMX.Cores.Storing.Industrial.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;

    public class StoreIndustrialCoreCommand : IRequest<bool>
    {
        #region Constructor

        public StoreIndustrialCoreCommand(
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

    public class StoreIndustrialCoreCommandHandler : IRequestHandler<StoreIndustrialCoreCommand, bool>
    {
        #region Fields

        private readonly IIndustrialCoresService service;

        #endregion

        #region Constructor

        public StoreIndustrialCoreCommandHandler(
            IIndustrialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Handle

        public async Task<bool> Handle(StoreIndustrialCoreCommand request, CancellationToken cancellationToken)
        {
            await service.StoreIndustrialCoreAsync(request.CoreTestId,
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