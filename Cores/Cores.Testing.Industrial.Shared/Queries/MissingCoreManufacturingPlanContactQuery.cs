namespace ProlecGE.ControlPisoMX.Cores.Industrial.Queries
{
    using MediatR;

    using Microsoft.Extensions.Logging;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class MissingCoreManufacturingPlanContactQuery
        : IRequest<string>
    {
        #region Constructor

        public MissingCoreManufacturingPlanContactQuery() { }

        #endregion
    }

    public class MissingCoreManufacturingPlanContactQueryHandler
        : Http.WebApiClient, IRequestHandler<MissingCoreManufacturingPlanContactQuery, string>
    {
        #region Fields

        private readonly ILogger<MissingCoreManufacturingPlanContactQueryHandler> logger;

        #endregion

        #region Constructor

        public MissingCoreManufacturingPlanContactQueryHandler(
           ILogger<MissingCoreManufacturingPlanContactQueryHandler> logger,
           HttpClient httpClient)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<string> Handle(MissingCoreManufacturingPlanContactQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await GetAsync<string>(
                    $"industrial/missingcoremanufacturingplancontact",
                    CancellationToken.None)
                .ConfigureAwait(false) ?? "Contacte con su supervisor con respecto a la orden.";
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar el contacto para la falta de información de la orden.'");
                throw new UserException("No se puede consultar el contacto para la falta de información de la orden en este momento.", nameof(MissingCoreManufacturingPlanContactQueryHandler), true);
            }
        }

        #endregion
    }
}