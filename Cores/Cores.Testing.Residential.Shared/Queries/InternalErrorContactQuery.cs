namespace ProlecGE.ControlPisoMX.Cores.Residential.Queries
{
    using MediatR;

    using Microsoft.Extensions.Logging;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class InternalErrorContactQuery
        : IRequest<string>
    {
        #region Constructor

        public InternalErrorContactQuery() { }

        #endregion
    }

    public class InternalErrorContactQueryHandler : Http.WebApiClient, IRequestHandler<InternalErrorContactQuery, string>
    {
        #region Fields

        private readonly ILogger<InternalErrorContactQueryHandler> logger;

        #endregion

        #region Constructor

        public InternalErrorContactQueryHandler(
           ILogger<InternalErrorContactQueryHandler> logger,
           HttpClient httpClient)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<string> Handle(InternalErrorContactQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await GetAsync<string>(
                   $"residential/internalerrorcontact",
                   CancellationToken.None)
               .ConfigureAwait(false) ?? "Contacte con su supervisor referente al error interno.";
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