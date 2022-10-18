namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class CartonShearsQuery : MediatR.IRequest<IEnumerable<CartonShearModel>>
    {
        #region Constructor

        public CartonShearsQuery(string itemId)
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

    public class CartonShearsQueryHandler : MediatR.IRequestHandler<CartonShearsQuery, IEnumerable<CartonShearModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public CartonShearsQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<CartonShearModel>> Handle(CartonShearsQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetItemCartonShearsAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}