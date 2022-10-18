namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System.Threading.Tasks;

    public class ManufactureMinutesQuery : MediatR.IRequest<int> { }

    public class ManufactureMinutesQueryHandler : MediatR.IRequestHandler<ManufactureMinutesQuery, int>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public ManufactureMinutesQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<int> Handle(ManufactureMinutesQuery request, CancellationToken cancellationToken)
        {
            return await service.GetManufacturingMinutesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}