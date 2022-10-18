namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

    public class MachinesQuery : MediatR.IRequest<IEnumerable<InsulationMachineModel>> { }

    public class MachinesQueryHandler : MediatR.IRequestHandler<MachinesQuery, IEnumerable<InsulationMachineModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IResidentialCoresService service;

        #endregion

        #region Constructor

        public MachinesQueryHandler(BFWeb.Components.IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<InsulationMachineModel>> Handle(MachinesQuery request, CancellationToken cancellationToken)
        {
            return await service.GetWindingMachinesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}