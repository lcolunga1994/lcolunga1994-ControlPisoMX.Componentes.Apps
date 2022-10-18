namespace ProlecGE.ControlPisoMX.Insulations.Forms.Shared.ClientApp.Queries
{
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class ManufacturingOrderQuery : MediatR.IRequest<InsulationManufactureModel?>
    {
        #region Fields
        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        #endregion

        #region Constructor

        public ManufacturingOrderQuery(string itemId, string batch, int serie)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
        }

        #endregion
    }

    public class ManufacturingOrderQueryHandler : MediatR.IRequestHandler<ManufacturingOrderQuery, InsulationManufactureModel?>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public ManufacturingOrderQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods
        
        public async Task<InsulationManufactureModel?> Handle(ManufacturingOrderQuery request, CancellationToken cancellationToken)
        {
            return await service.GetManufacturingOrderAsync(request.ItemId, request.Batch, request.Serie, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}