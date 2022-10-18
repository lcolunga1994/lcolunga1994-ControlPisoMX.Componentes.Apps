namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;

    public class OrdersScheduledToManufactureQuery : MediatR.IRequest<IEnumerable<OrderToManufacturingModel>>
    {
        #region Constructor

        public OrdersScheduledToManufactureQuery(DateTime utcDate,string machine)
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

    public class OrdersScheduledToManufactureQueryHandler : MediatR.IRequestHandler<OrdersScheduledToManufactureQuery, IEnumerable<OrderToManufacturingModel>>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public OrdersScheduledToManufactureQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<OrderToManufacturingModel>> Handle(OrdersScheduledToManufactureQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetOrdersScheduledToManufactureAsync(request.UtcDate,request.Machine, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}