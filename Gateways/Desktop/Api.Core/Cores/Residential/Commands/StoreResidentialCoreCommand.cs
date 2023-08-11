using MediatR;

namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Configuration;

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

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public StoreResidentialCoreCommandHandler(ControlPisoMX.Cores.IMicroservice cores, IConfiguration configuration)
        {
            this.cores = cores;
            _configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(StoreResidentialCoreCommand request, CancellationToken cancellationToken)
        {
            if(bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()))
                await cores.StoreResidentialCoreAsync(request.CoreTestId, request.Location, request.AssociatedCode, request.Force)
                    .ConfigureAwait(false);
            else 
                await cores.StoreResidentialCoreAsync_sqlctp(request.CoreTestId, request.Location, request.AssociatedCode, request.Force)
                    .ConfigureAwait(false);

            return true;
        }

        #endregion
    }
}
