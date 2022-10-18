namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Commands
{
    using System.Threading.Tasks;

    using MediatR;

    public class AddRepairOrderToManufacturingCommand : IRequest
    {
        #region Constructor

        public AddRepairOrderToManufacturingCommand(string itemId, string batch, int quantity, int priority)
        {
            ItemId = itemId;
            Batch = batch;
            Quantity = quantity;
            Priority = priority;
        }

        #endregion

        #region Properties

        public string ItemId { set; get; }

        public string Batch { set; get; }

        public int Quantity { set; get; }

        public int Priority { set; get; }

        #endregion
    }

    public class AddRepairOrderToManufacturingCommandHandler : IRequestHandler<AddRepairOrderToManufacturingCommand>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public AddRepairOrderToManufacturingCommandHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(AddRepairOrderToManufacturingCommand request, CancellationToken cancellationToken)
        {
            await service
                .AddRepairOrderAsync(request.ItemId, request.Batch, request.Quantity, request.Priority, cancellationToken)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}