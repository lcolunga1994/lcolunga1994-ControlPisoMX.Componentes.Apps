namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System.Threading.Tasks;

    public class MinimumManufactureMinutesQuery : MediatR.IRequest<int?> { }

    public class MinimumManufactureMinutesQueryHandler : MediatR.IRequestHandler<MinimumManufactureMinutesQuery, int?>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public MinimumManufactureMinutesQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<int?> Handle(MinimumManufactureMinutesQuery request, CancellationToken cancellationToken)
        {
            return await service.GetMinimumManufactureMinutesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}
