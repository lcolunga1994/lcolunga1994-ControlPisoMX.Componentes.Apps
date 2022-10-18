namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

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

        private readonly ControlPisoMX.Cores.IMicroservice cores;

        #endregion

        #region Constructor

        public StoreIndustrialCoreCommandHandler(ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(StoreIndustrialCoreCommand request, CancellationToken cancellationToken)
        {
            await cores.StoreIndustrialCoreAsync(request.CoreTestId, request.Location, request.AssociatedCode, request.Force)
                .ConfigureAwait(false);

            return true;
        }

        #endregion
    }
}
