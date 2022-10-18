namespace ProlecGE.ControlPisoMX.Security.Forms
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using Microsoft.Extensions.DependencyInjection;

    using ProlecGE.ControlPisoMX.Identity.Models;

    public partial class LoginForm : ThemedForm
    {
        #region Fields

        private readonly MediatR.IMediator mediator;
        private readonly IServiceProvider serviceProvider;
        private readonly string applicationName;
        private readonly string? productLine;

        #endregion

        #region Properties

        public bool IsUserLogin { get; set; } = true;

        public User? User { get; private set; }


        #endregion

        #region Constructor

        public LoginForm(IServiceProvider serviceProvider, string applicationName, string? productLine = null)
        {
            this.serviceProvider = serviceProvider;
            this.applicationName = applicationName;
            this.productLine = productLine;
            mediator = this.serviceProvider.GetRequiredService<MediatR.IMediator>();
            InitializeComponent();
            CustomInitializeComponent();
        }

        #endregion

        #region Constrols initialization

        private void CustomInitializeComponent()
        {
            UseLightTheme();
            ApplyStandarLogo(picBoxEnterpriseLogo);
            ApplyIcons(picBoxUser, picBoxPass);
            lblForgotPass.LinkColor = PurpleColor;
            lblForgotPass.ActiveLinkColor = PurpleColor;
            StartPosition = FormStartPosition.CenterParent;
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

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new(serviceProvider);
            form.ShowDialog();
        }

        private void BtnEnter_Click(object sender, EventArgs e) => Login();

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
                    .Send(new Queries.ValidateUserPasswordQuery(userName, password))
                    .ConfigureAwait(false);

                if (userExists)
                {
                    User? user = await mediator
                        .Send(new Queries.UserQuery(userName, password))
                        .ConfigureAwait(false);

                    if (user != null)
                    {
                        if (IsUserLogin)
                        {
                            User = user;
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
                    lblForgotPass.Enabled = false;
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
                        if (User != null && 
                            (applicationName == "All" || User.Applications.Contains(applicationName)) && 
                            (string.IsNullOrEmpty(productLine) || User.Line == productLine))
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("El usuario no tiene permisos para usar esta aplicación.", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Text = "";
                            txtPassword.Focus();
                        }
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
                    lblForgotPass.Enabled = true;
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