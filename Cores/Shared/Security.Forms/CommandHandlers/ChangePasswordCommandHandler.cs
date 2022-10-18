namespace ProlecGE.ControlPisoMX.Security.Forms.CommandHandlers
{
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.Security.Forms.Command;

    using System;
    using System.Threading.Tasks;

    public class ChangePasswordCommandHandler : Http.WebApiClient, MediatR.IRequestHandler<ChangePasswordCommand, bool>
    {
        #region Fields

        private readonly ILogger<ChangePasswordCommandHandler> logger;

        #endregion

        #region Constructor

        public ChangePasswordCommandHandler(
           ILogger<ChangePasswordCommandHandler> logger,
           HttpClient httpClient)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await PostAsync<bool>($"Identity/changepassword/{request.UserName}/{request.Password}/{request.NewPassword}/{request.NewPassword}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al intentar cambiar la contraseña del usuario {user}.", $"{request.UserName}");
                throw new UserException($"No se puede cambiar la contraseña del usuario {request.UserName} en este momento.", nameof(ChangePasswordCommandHandler), true);
            }
        }

        #endregion
    }
}