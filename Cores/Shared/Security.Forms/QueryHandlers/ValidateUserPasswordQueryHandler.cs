namespace ProlecGE.ControlPisoMX.Security.Forms.QueryHandlers
{
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.Security.Forms.Queries;

    using System;
    using System.Threading.Tasks;

    public class ValidateUserPasswordQueryHandler : Http.WebApiClient, MediatR.IRequestHandler<ValidateUserPasswordQuery, bool>
    {
        #region Fields

        private readonly ILogger<ValidateUserPasswordQueryHandler> logger;

        #endregion

        #region Constructor

        public ValidateUserPasswordQueryHandler(
           ILogger<ValidateUserPasswordQueryHandler> logger,
           HttpClient httpClient)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(ValidateUserPasswordQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await GetAsync<bool>($"identity/validateUser/{request.UserName}/{request.Password}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al validar las credenciales del usuario {user}.", $"{request.UserName}");
                throw new UserException($"No se pueden validar las credenciales del usuario {request.UserName} en este momento.", nameof(ValidateUserPasswordQueryHandler), true);
            }
        }

        #endregion
    }
}