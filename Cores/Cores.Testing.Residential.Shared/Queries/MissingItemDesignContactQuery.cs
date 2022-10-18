namespace ProlecGE.ControlPisoMX.Cores.Residential.Queries
{
    using MediatR;

    using Microsoft.Extensions.Logging;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class MissingItemDesignContactQuery
        : IRequest<string>
    {
        #region Constructor

        public MissingItemDesignContactQuery() { }

        #endregion
    }

    public class MissingItemDesignContactQueryHandler : Http.WebApiClient, IRequestHandler<MissingItemDesignContactQuery, string>
    {
        #region Fields

        private readonly ILogger<MissingItemDesignContactQueryHandler> logger;

        #endregion

        #region Constructor

        public MissingItemDesignContactQueryHandler(
           ILogger<MissingItemDesignContactQueryHandler> logger,
           HttpClient httpClient)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<string> Handle(MissingItemDesignContactQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await GetAsync<string>(
                    $"residential/missingitemdesigncontact",
                    CancellationToken.None)
                .ConfigureAwait(false) ?? "Contacte con su supervisor.";
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar el contacto para la falta de información de diseño.'");
                throw new UserException("No se puede consultar el contacto para la falta de información de diseño en este momento.", nameof(MissingItemDesignContactQueryHandler), true);
            }
        }

        #endregion
    }
}