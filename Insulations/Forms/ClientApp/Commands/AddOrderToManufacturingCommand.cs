namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Commands
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class AddOrderToManufacturingCommand : IRequest
    {
        #region Constructor

        public AddOrderToManufacturingCommand(List<OrderToManufactureModel> orders)
        {
            Orders = orders;
        }

        #endregion

        #region Properties

        public List<OrderToManufactureModel> Orders { get; set; }

        #endregion
    }

    public class AddOrderToManufacturingCommandHandler : IRequestHandler<AddOrderToManufacturingCommand>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public AddOrderToManufacturingCommandHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(AddOrderToManufacturingCommand request, CancellationToken cancellationToken)
        {
            await service
                .AddOrdersToManufacturingAsync(request.Orders)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}