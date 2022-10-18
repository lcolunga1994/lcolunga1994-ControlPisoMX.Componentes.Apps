namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class InsulationManufactureQuery : MediatR.IRequest<IEnumerable<InsulationManufactureModel>> { }

    public class InsulationManufactureHandler : MediatR.IRequestHandler<InsulationManufactureQuery, IEnumerable<InsulationManufactureModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public InsulationManufactureHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<InsulationManufactureModel>> Handle(InsulationManufactureQuery request, CancellationToken cancellationToken)
        {
            return await service.GetInsulationManufacturingOrdersAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}