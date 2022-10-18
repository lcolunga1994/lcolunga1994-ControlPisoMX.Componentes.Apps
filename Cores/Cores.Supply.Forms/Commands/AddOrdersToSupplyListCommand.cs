namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Commands
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public class AddOrdersToSupplyListCommand : IRequest
    {
        #region Constructor

        public AddOrdersToSupplyListCommand(List<OrderParameterModel> orders)
        {
            Orders = orders;
        }

        #endregion

        #region Properties

        public List<OrderParameterModel> Orders { get; set; }

        #endregion
    }

    public class AddOrderToSupplyListCommandHandler : IRequestHandler<AddOrdersToSupplyListCommand>
    {
        #region Fields

        private readonly BFWeb.Components.ICoresSupplyService service;

        #endregion

        #region Constructor

        public AddOrderToSupplyListCommandHandler(BFWeb.Components.ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(AddOrdersToSupplyListCommand request, CancellationToken cancellationToken)
        {
            await service
                .AddOrdersToSupplyListAsync(request.Orders, cancellationToken)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}