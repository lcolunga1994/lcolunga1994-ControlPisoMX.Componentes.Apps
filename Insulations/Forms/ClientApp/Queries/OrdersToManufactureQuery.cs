namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class OrdersToManufactureQuery : MediatR.IRequest<IEnumerable<OrderToManufacturingModel>>
    {
        #region Constructor

        public OrdersToManufactureQuery(DateTime utcDate, string machine)
        {
            if (string.IsNullOrWhiteSpace(machine))
            {
                throw new ArgumentException($"La maquina no puede ser vacío o contener espacios.", nameof(machine));
            }

            Machine = machine;
            UtcDate = utcDate;
        }

        #endregion

        #region Properties

        public DateTime UtcDate { set; get; }

        public string Machine { get; }

        #endregion
    }

    public class OrdersToManufactureQueryHandler : MediatR.IRequestHandler<OrdersToManufactureQuery, IEnumerable<OrderToManufacturingModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public OrdersToManufactureQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<OrderToManufacturingModel>> Handle(OrdersToManufactureQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetOrdersToManufactureAsync(request.UtcDate, request.Machine, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}