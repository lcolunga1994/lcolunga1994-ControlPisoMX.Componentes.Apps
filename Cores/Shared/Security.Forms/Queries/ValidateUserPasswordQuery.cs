namespace ProlecGE.ControlPisoMX.Security.Forms.Queries
{
    using System;

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
}