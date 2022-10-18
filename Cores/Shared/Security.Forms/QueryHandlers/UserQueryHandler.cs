namespace ProlecGE.ControlPisoMX.Security.Forms.QueryHandlers
{
    using MediatR;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.Identity.Models;
    using ProlecGE.ControlPisoMX.Security.Forms.Queries;

    using System;
    using System.Threading.Tasks;

    public class UserQueryHandler : Http.WebApiClient, IRequestHandler<UserQuery, User?>
    {
        #region Fields

        private readonly ILogger<UserQueryHandler> logger;

        #endregion

        #region Constructor

        public UserQueryHandler(
           ILogger<UserQueryHandler> logger,
           HttpClient httpClient)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<User?> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await GetAsync<User>($"identity/login/{request.UserName}/{request.Password}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar la información del usuario {user}.", $"{request.UserName}");
                throw new UserException($"No se puede consultar la información del usuario {request.UserName} en este momento.", nameof(UserQueryHandler), true);
            }
        }

        #endregion
    }
}