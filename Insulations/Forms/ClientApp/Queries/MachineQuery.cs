namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class MachineQuery : MediatR.IRequest<IEnumerable<InsulationMachineModel>> { }

    public class MachinesQueryHandler : MediatR.IRequestHandler<MachineQuery, IEnumerable<InsulationMachineModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public MachinesQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<InsulationMachineModel>> Handle(MachineQuery request, CancellationToken cancellationToken)
        {
            return await service.GetInsulationMachinesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}