namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System;
    using System.Threading.Tasks;

    public class ValidateUserPasswordQuery : MediatR.IRequest<bool>
    {
        #region Constructor

        public ValidateUserPasswordQuery(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"El artículo no puede ser vacío o contener espacios.", nameof(username));
            }

            UserName = username;
            Password = password;
        }

        #endregion

        #region Properties

        public string UserName { get; }

        public string Password { get; }

        #endregion
    }

    public class ValidateUserPasswordHandler : MediatR.IRequestHandler<ValidateUserPasswordQuery, bool>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public ValidateUserPasswordHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler

        public async Task<bool> Handle(ValidateUserPasswordQuery request, CancellationToken cancellationToken)
        {
            return await service.ValidateUserPasswordAsync(request.UserName, request.Password, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}