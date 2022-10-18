namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class InProgressManufacturingQuery : MediatR.IRequest<IEnumerable<InsulationManufactureModel>> { }

    public class InProgressManufacturingQueryHandler : MediatR.IRequestHandler<InProgressManufacturingQuery, IEnumerable<InsulationManufactureModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public InProgressManufacturingQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<InsulationManufactureModel>> Handle(InProgressManufacturingQuery request, CancellationToken cancellationToken)
        {
            return await service.GetInsulationManufacturingOrdersInProgressAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}