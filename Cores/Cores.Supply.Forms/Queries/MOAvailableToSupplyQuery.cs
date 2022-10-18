namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public class MOAvailableToSupplyQuery : MediatR.IRequest<IEnumerable<MOManufacturingStatusModel>>
    {
        #region Constructor

        public MOAvailableToSupplyQuery(DateTime date, string machine)
        {
            if (string.IsNullOrWhiteSpace(machine))
            {
                throw new ArgumentException($"La maquina no puede ser vacío o contener espacios.", nameof(machine));
            }

            Machine = machine;
            Date = date;
        }

        #endregion

        #region Properties

        public DateTime Date { set; get; }

        public string Machine { get; }

        #endregion
    }

    public class MOAvailableToSupplyQueryHandler : MediatR.IRequestHandler<MOAvailableToSupplyQuery, IEnumerable<MOManufacturingStatusModel>>
    {
        #region Fields

        private readonly BFWeb.Components.ICoresSupplyService service;

        #endregion

        #region Constructor

        public MOAvailableToSupplyQueryHandler(BFWeb.Components.ICoresSupplyService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<IEnumerable<MOManufacturingStatusModel>> Handle(MOAvailableToSupplyQuery request, CancellationToken cancellationToken)
        {
            return await service
                .GetManufacturingOrdersAvailableToSupplyAsync(request.Date, request.Machine, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}