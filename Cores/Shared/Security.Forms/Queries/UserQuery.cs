namespace ProlecGE.ControlPisoMX.Security.Forms.Queries
{
    using MediatR;

    using ProlecGE.ControlPisoMX.Identity.Models;

    using System;

    public class UserQuery : IRequest<User?>
    {
        #region Constructor

        public UserQuery(string username, string password)
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
}