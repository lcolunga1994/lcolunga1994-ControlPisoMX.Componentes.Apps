namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System;
    using System.Threading.Tasks;

    public class UserQuery : MediatR.IRequest<string>
    {
        #region Constructor

        public UserQuery(string username,string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"El usuario no se puede enviar vacio.", nameof(username));
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

    public class UserQueryHandler : MediatR.IRequestHandler<UserQuery, string>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;

        #endregion

        #region Constructor

        public UserQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;
        }

        #endregion

        #region Handler
        
        public async Task<string> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            return await service.GetUserAsync(request.UserName, request.Password, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}