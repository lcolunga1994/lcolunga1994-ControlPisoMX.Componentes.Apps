namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System.Threading.Tasks;

    public class IsManufacturingAllowedQuery : MediatR.IRequest<bool>
    {
        #region Constructor
     
        public IsManufacturingAllowedQuery(){ }

        #endregion
    }

    public class IsManufacturingAllowedQueryHandler : MediatR.IRequestHandler<IsManufacturingAllowedQuery, bool>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor
        public IsManufacturingAllowedQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        
        }

        #endregion

        #region Handler

        public async Task<bool> Handle(IsManufacturingAllowedQuery request, CancellationToken cancellationToken)
        {
            return await service.IsManufacturingAllowedAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}