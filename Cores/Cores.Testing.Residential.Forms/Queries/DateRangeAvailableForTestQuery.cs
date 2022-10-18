namespace ProlecGE.ControlPisoMX.Cores.Testing.Residential.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;

    internal class DateRangeAvailableForTestQuery : IRequest<IEnumerable<DateRangeAvailableModel>>
    {
        #region Constructor

        /// <summary>
        /// Consulta de fechas disponibles para probar en el plan de fabricación.
        /// </summary>
        public DateRangeAvailableForTestQuery() { }

        #endregion
    }

    internal class DateRangeAvailableForTestQueryHandler : IRequestHandler<DateRangeAvailableForTestQuery, IEnumerable<DateRangeAvailableModel>>
    {
        #region Fields

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public DateRangeAvailableForTestQueryHandler(IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<DateRangeAvailableModel>> Handle(DateRangeAvailableForTestQuery request, CancellationToken cancellationToken)
            => await service.GetDateRangeAvailableForTestQueryAsync()
            .ConfigureAwait(false);

        #endregion
    }
}