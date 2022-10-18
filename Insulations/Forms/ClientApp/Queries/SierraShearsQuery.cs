namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System;
    using System.Collections.Generic;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class SierraShearsQuery : MediatR.IRequest<IEnumerable<SierraShearModel>>
    {
        #region Constructor

        public SierraShearsQuery(string itemId)
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

    public class SierraShearsQueryHandler : MediatR.IRequestHandler<SierraShearsQuery, IEnumerable<SierraShearModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public SierraShearsQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<SierraShearModel>> Handle(SierraShearsQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetItemSierraShearsAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}