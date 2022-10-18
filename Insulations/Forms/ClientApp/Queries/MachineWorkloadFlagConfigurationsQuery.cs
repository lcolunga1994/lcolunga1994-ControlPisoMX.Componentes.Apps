namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class MachineWorkloadFlagConfigurationsQuery : MediatR.IRequest<MachineWorkloadFlagConfigurationModel> { }

    public class MachineWorkloadFlagConfigurationsQueryHandler : MediatR.IRequestHandler<MachineWorkloadFlagConfigurationsQuery, MachineWorkloadFlagConfigurationModel>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public MachineWorkloadFlagConfigurationsQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<MachineWorkloadFlagConfigurationModel> Handle(MachineWorkloadFlagConfigurationsQuery request, CancellationToken cancellationToken)
        {
            return await service.GetMachineWorkloadSemaphoreAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}