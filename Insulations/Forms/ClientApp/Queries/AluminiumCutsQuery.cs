namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class AluminiumCutsQuery : MediatR.IRequest<IEnumerable<AluminiumCutModel>>
    {
        #region Constructor

        public AluminiumCutsQuery(string itemId)
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

    public class AluminiumCutsQueryHandler : MediatR.IRequestHandler<AluminiumCutsQuery, IEnumerable<AluminiumCutModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public AluminiumCutsQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<AluminiumCutModel>> Handle(AluminiumCutsQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetItemAluminiumCutsAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}