namespace ProlecGE.ControlPisoMX.Security.Forms.Command
{

    using System;

    public class ChangePasswordCommand : MediatR.IRequest<bool>
    {
        #region Constructor

        public ChangePasswordCommand(string username, string password, string newpassword)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"El usuario no se puede enviar vacio.", nameof(username));
            }

            UserName = username;
            Password = password;
            NewPassword = newpassword;
        }

        #endregion

        #region Properties

        public string UserName { get; }

        public string Password { get; }

        public string NewPassword { get; }

        #endregion
    }
}
