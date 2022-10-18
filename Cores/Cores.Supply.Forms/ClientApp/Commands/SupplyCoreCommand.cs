namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Commands
{
    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public class SupplyCoreCommand : IRequest<SupplyCoreResultModel?>
    {
        #region Constructor

        public SupplyCoreCommand(string itemId, string batch, int serie, bool force)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Force = force;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public bool Force { get; set; }

        #endregion
    }

    public class SupplyCoreCommandHandler : IRequestHandler<SupplyCoreCommand, SupplyCoreResultModel?>
    {
        #region Fields

        private readonly BFWeb.Components.ICoresSupplyService service;

        #endregion

        #region Constructor

        public SupplyCoreCommandHandler(BFWeb.Components.ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<SupplyCoreResultModel?> Handle(SupplyCoreCommand request, CancellationToken cancellation)
        {
            return await service
                  .SupplyCoresAsync(request.ItemId, request.Batch, request.Serie, request.Force, Program.User.UserName)
                  .ConfigureAwait(false);
        }

        #endregion
    }
}
