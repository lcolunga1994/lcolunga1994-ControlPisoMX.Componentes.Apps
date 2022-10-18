namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Commands
{
    using System;
    using System.Threading.Tasks;

    using MediatR;

    public class UpdateManufacturingOrderPriorityCommand : IRequest
    {
        #region Constructor

        public UpdateManufacturingOrderPriorityCommand(Guid id, int priority)
        {
            Id = id;
            Priority = priority;
        }

        #endregion

        #region Properties

        public Guid Id { set; get; }

        public int Priority { set; get; }

        #endregion
    }

    public class UpdateManufacturingOrderPriorityCommandHandler : IRequestHandler<UpdateManufacturingOrderPriorityCommand>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public UpdateManufacturingOrderPriorityCommandHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<Unit> Handle(UpdateManufacturingOrderPriorityCommand request, CancellationToken cancellationToken)
        {
            await service
                .UpdateOrderManufacturingPriorityAsync(request.Id, request.Priority, cancellationToken)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}