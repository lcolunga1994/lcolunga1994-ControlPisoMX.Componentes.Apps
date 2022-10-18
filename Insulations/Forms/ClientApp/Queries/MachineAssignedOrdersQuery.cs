namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class MachineAssignedOrdersQuery : MediatR.IRequest<IEnumerable<MachineAssignedOrdersModel>> { }

    public class MachineAssignedOrdersQueryHandler : MediatR.IRequestHandler<MachineAssignedOrdersQuery, IEnumerable<MachineAssignedOrdersModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public MachineAssignedOrdersQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<MachineAssignedOrdersModel>> Handle(MachineAssignedOrdersQuery request, CancellationToken cancellationToken)
        {
            return await service.GetMachineAssignedOrdersAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}