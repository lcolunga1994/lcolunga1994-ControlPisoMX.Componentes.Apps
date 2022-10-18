namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using Microsoft.Extensions.DependencyInjection;

    using Utils;

    public partial class frmLogin : ThemedForm
    {
        #region Fields

        private readonly MediatR.IMediator mediator;
        private readonly IServiceProvider serviceProvider;

        #endregion

        #region Properties

        public bool IsUserLogin { get; set; } = true;

        #endregion

        #region  Constructor

        public frmLogin(IServiceProvider serviceProvider) : base(new ThemeConfiguration() { UseDarkTheme = true })
        {
            this.serviceProvider = serviceProvider;
            mediator = this.serviceProvider.GetRequiredService<MediatR.IMediator>();
            InitializeComponent();
        }

        #endregion

        #region Events

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }

        private void BtnEnter_Click(object sender, EventArgs e) => Login();

        private void BtnExit_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Commands

        private async void Login()
        {
            Regex rgx = new("^[a-zA-Z0-9]*$");

            if (!rgx.IsMatch(txtUserName.Text))
            {
                MessageBox.Show("Solo se admiten letras y números.", "Validación de Usuario", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Ingrese el nombre de usuario", "Validación de Usuario", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese la contraseña del usuario.", "Validación de Usuario", MessageBoxButtons.OK);
                return;
            }

            OperationProgress<string> operation = new(OnProgressChanged);

            try
            {
                operation.Start();

                string userName = txtUserName.Text;
                string password = txtPassword.Text;

                bool userExists = await mediator
                    .Send(new ClientApp.Queries.ValidateUserPasswordQuery(userName, password))
                    .ConfigureAwait(false);

                if (userExists)
                {
                    string usrName = await mediator
                        .Send(new ClientApp.Queries.UserQuery(userName, password))
                        .ConfigureAwait(false);

                    if (!string.IsNullOrEmpty(usrName))
                    {
                        if (IsUserLogin)
                        {
                            Program.UserDisplayName = usrName;
                        }
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
                    btnEnter.Enabled = false;
                    btnExit.Enabled = false;
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
                    btnEnter.Enabled = true;
                    btnExit.Enabled = true;
                }
            }
        }

        #endregion

        #region  Funcionality
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
                if (messageParameters.Exception is UserException userException)
                {
                    string? customMessage = null;

                    System.Text.StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(userException.Message);

                    if (!string.IsNullOrEmpty(customMessage))
                    {
                        stringBuilder.Append(customMessage);

                        if (userException.SystemErrorCode == 500)
                        {
                            stringBuilder.Append($" ({userException.ErrorCode})");
                        }
                    }

                    userMessage = stringBuilder.ToString();
                }
                else
                {
                    System.Text.StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(userMessage);
                    stringBuilder.AppendLine("Contactar al administrador del sistema.");
                    userMessage = stringBuilder.ToString();
                }
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