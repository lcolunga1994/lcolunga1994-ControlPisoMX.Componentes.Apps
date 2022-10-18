namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.Commands
{
    using System;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components;

    public class ReprintCommand : MediatR.IRequest
    {
        #region Constructor

        public ReprintCommand(Guid id)
        {
            ManufacturingOrderId = id;
        }

        #endregion

        #region Properties

        public Guid ManufacturingOrderId { get; }

        #endregion
    }

    public class ReprintCommandHandler : MediatR.IRequestHandler<ReprintCommand>
    {
        #region Fields

        private readonly ICoresSupplyService service;

        #endregion

        #region Constructor

        public ReprintCommandHandler(ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<MediatR.Unit> Handle(ReprintCommand request, CancellationToken cancellationToken)
        {
            await service
                .ReprintAsync(request.ManufacturingOrderId, Program.User.UserName)
                .ConfigureAwait(false);

            return MediatR.Unit.Value;
        }

        #endregion
    }
}