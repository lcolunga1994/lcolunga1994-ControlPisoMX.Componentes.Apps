namespace ProlecGE.ControlPisoMX.Security.Forms
{
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class ChangePasswordForm : ThemedForm
    {
        #region Fields

        private readonly MediatR.IMediator mediator;
        private readonly IServiceProvider serviceProvider;

        #endregion

        #region Properties

        public bool IsUserLogin { get; set; } = true;

        public string UserDisplayName { get; private set; }

        #endregion

        #region Constructor

        public ChangePasswordForm(IServiceProvider serviceProvider)
        {
            UserDisplayName = "";
            this.serviceProvider = serviceProvider;
            mediator = this.serviceProvider.GetRequiredService<MediatR.IMediator>();
            InitializeComponent();
            CustomInitializeComponent();
        }

        #endregion

        #region Constrols initialization

        private void CustomInitializeComponent()
        {
            UseLightTheme();
            ApplyStandarImages(picBoxEnterpriseLogo, picBoxTitleLine);
            ApplySecondaryButtonTheme(btnClose);
            StartPosition = FormStartPosition.CenterParent;   
        }

        #endregion

        #region Events

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void BtnAccept_Click(object sender, EventArgs e) => ChangePassword();

        #endregion

        #region Commands

        private async void ChangePassword()
        {
            Regex rgx = new("^[a-zA-Z0-9]*$");

            if (!rgx.IsMatch(txtUserName.Text))
            {
                MessageBox.Show("Solo se admiten letras y números.", "Validación de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Ingrese el nombre de usuario", "Validación de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese la contraseña del usuario.", "Validación de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Ingrese la nueva contraseña del usuario.", "Validación de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Ingrese la confimación de la contraseña del usuario.", "Validación de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coiciden. ¡Intentalo de nuevo!", "Validación de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OperationProgress<string> operation = new(OnProgressChanged);

            try
            {
                operation.Start();

                string userName = txtUserName.Text;
                string password = txtPassword.Text;
                string newPassword = txtNewPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;

                bool userExists = await mediator
                    .Send(new Queries.ValidateUserPasswordQuery(userName, password))
                    .ConfigureAwait(false);

                if (userExists)
                {
                    bool usrChangePwd = await mediator
                        .Send(new Command.ChangePasswordCommand(userName, password, newPassword))
                        .ConfigureAwait(false);

                    if (usrChangePwd)
                    {
                        operation.Report("UserIsValid");
                    }
                    else
                    {
                        operation.Report("UserNotRegistered");
                    }
                }
                else
                {
                    operation.Report("UserNotExists");
                }
            }
            catch (Exception ex)
            {
                operation.Error("Ocurrió un error al validar credenciales.", ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgressReport<string> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                    txtUserName.Enabled = false;
                    txtPassword.Enabled = false;
                    txtNewPassword.Enabled = false;
                    txtConfirmPassword.Enabled = false;
                }
                else if (progressReport.State == OperationState.Running)
                {
                    if (progressReport.Value == "UserNotExists")
                    {
                        MessageBox.Show("¡Usuario o contraseña incorrecta!", "Validar credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Text = "";
                        txtPassword.Focus();
                    }
                    else if (progressReport.Value == "UserNotRegistered")
                    {
                        MessageBox.Show("¡Usuario no registrado!", "Validar credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Text = "";
                        txtPassword.Focus();
                    }
                    else if (progressReport.Value == "UserIsValid")
                    {
                        if (IsUserLogin)
                        {
                            MessageBox.Show("La contraseña se actualizó correctamente.", "Validación de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        DialogResult = DialogResult.OK;
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Validando usuario", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    txtUserName.Enabled = true;
                    txtPassword.Enabled = true;
                    txtNewPassword.Enabled = true;
                    txtConfirmPassword.Enabled = true;
                }
            }
        }

        #endregion

        #region Functionality

        private void ShowErrorMessage(
           string errorMessage,
           string messageTitle,
           Exception? ex = null)
        {
            if (ex is AggregateException aggregateException)
            {
                if (aggregateException.InnerException != null)
                {
                    ex = aggregateException.InnerException;
                }
            }

            ShowMessage(
                (MessageBoxIcon.Error,
                errorMessage,
                messageTitle,
                ex));
        }

        private void ShowMessage((
        MessageBoxIcon MessageBoxIcon,
        string ErrorMessage,
        string MessageTitle,
        Exception? Exception) messageParameters)
        {
            if (messageParameters.Exception != null)
            {
                System.Diagnostics.Debug.WriteLine(messageParameters.Exception);
            }

            string userMessage = messageParameters.ErrorMessage;

            if (messageParameters.Exception != null)
            {
                //if (messageParameters.Exception is UserException userException)
                //{
                //    string? customMessage = null;

                //    System.Text.StringBuilder stringBuilder = new();
                //    stringBuilder.AppendLine(userException.Message);

                //    if (!string.IsNullOrEmpty(customMessage))
                //    {
                //        stringBuilder.Append(customMessage);
                //    }

                //    userMessage = stringBuilder.ToString();
                //}
                //else
                //{
                System.Text.StringBuilder stringBuilder = new();
                stringBuilder.AppendLine(userMessage);
                stringBuilder.AppendLine("Contactar al administrador del sistema.");
                userMessage = stringBuilder.ToString();
                //}
            }

            if (messageParameters.MessageBoxIcon == MessageBoxIcon.Warning)
            {
                MessageBox.Show(
                    this,
                    userMessage,
                    messageParameters.MessageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (messageParameters.MessageBoxIcon == MessageBoxIcon.Error)
            {
                MessageBox.Show(
                    this,
                    userMessage,
                    messageParameters.MessageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(
                    this,
                    userMessage,
                    messageParameters.MessageTitle,
                    MessageBoxButtons.OK);
            }
        }

        #endregion
    }
}