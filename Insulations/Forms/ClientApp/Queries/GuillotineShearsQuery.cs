namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class GuillotineShearsQuery : MediatR.IRequest<IEnumerable<GuillotineShearModel>>
    {
        #region Constructor

        public GuillotineShearsQuery(string itemId)
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

    public class GuillotineShearsQueryHandler : MediatR.IRequestHandler<GuillotineShearsQuery, IEnumerable<GuillotineShearModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public GuillotineShearsQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<GuillotineShearModel>> Handle(GuillotineShearsQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetItemGuillotineShearsAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}