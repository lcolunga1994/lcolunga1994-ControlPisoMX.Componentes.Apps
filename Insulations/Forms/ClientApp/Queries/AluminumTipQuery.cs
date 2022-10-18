namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class AluminumTipQuery : MediatR.IRequest<AluminumTipPuntasModel?>
    {
        #region Constructor

        public AluminumTipQuery(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new ArgumentException($"El artículo no puede ser vacío o contener espacios.", nameof(itemId));
            }

            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    public class AluminumTipQueryHandler : MediatR.IRequestHandler<AluminumTipQuery, AluminumTipPuntasModel?>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public AluminumTipQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<AluminumTipPuntasModel?> Handle(AluminumTipQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetItemAluminumTipsAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}