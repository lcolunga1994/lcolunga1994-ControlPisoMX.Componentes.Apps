namespace ProlecGE.ControlPisoMX.CoreSupply.Forms
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.CoreSupply.Forms.Services;

    public partial class PrintInsulationTagForm : ThemedForm
    {
        #region Fields

        private readonly ILogger<PrintInsulationTagForm> logger;
        private readonly IInsulationsService service;

        #endregion

        #region  Constructor

        public PrintInsulationTagForm(
            ILogger<PrintInsulationTagForm> logger,
            IConfiguration configuration,
            IInsulationsService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            this.service = service;

            Password = configuration.GetValue<string>("Reprint:Password");

            if (string.IsNullOrWhiteSpace(Password))
            {
                Password = "adrian";
            }

            InitializeComponent();
            CustomInitializeComponent();
        }

        #endregion

        #region Properties

        public string Password { set; get; }

        public InsulationManufactureModel? Order { set; get; }

        #endregion

        #region Controls initialization

        private void CustomInitializeComponent()
        {
            UseLightTheme();
            ApplyStandarImages(picBoxEnterpriseLogo, picBoxTitleLine);
            ApplyUserImage(picBoxUserImage);
            ApplySecondaryButtonTheme(btnClose);
            lblUserName.Text = Program.User.Name;
        }

        #endregion

        #region Events

        private void BtnExit_Click(object sender, EventArgs e) => Close();

        private void BtnAccept_Click(object sender, EventArgs e) => PrintOrder();

        private void TxtBatch_Leave(object sender, EventArgs e) => txtBatch.Text = txtBatch.Text.PadLeft(2, '0');

        #endregion

        #region Commands

        private async void PrintOrder()
        {
            if (string.IsNullOrWhiteSpace(txtOrder.Text) || string.IsNullOrWhiteSpace(txtBatch.Text) || string.IsNullOrWhiteSpace(txtSerie.Text))
            {
                MessageBox.Show("Capture todos los datos de la orden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string password = txtPassword.Text;

                if (password != Password)
                {
                    MessageBox.Show("¡La contraseña para autorizar reimpresiones es incorrecta!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string itemId = txtOrder.Text;
                    string batch = txtBatch.Text;
                    int serie = int.Parse(txtSerie.Text);

                    OperationProgress<bool> operation = new(OnProgressChanged);

                    try
                    {
                        operation.Start();

                        Order = await service
                            .GetManufacturingOrderAsync(itemId, batch, serie, CancellationToken.None)
                            .ConfigureAwait(false);

                        if (Order == null)
                        {
                            throw new UserException($"La orden {itemId}-{batch}-{serie} no existe.");
                        }

                        if (Order.Status < 3)
                        {
                            throw new UserException($"La etiqueta de la orden todavía no ha sido impresa por primera vez.");
                        }

                        operation.Report(true);
                    }
                    catch (Exception ex)
                    {
                        operation.Error("Ocurrió un error al cargar la información de la orden.", ex);
                    }
                    finally
                    {
                        operation.Finish();
                    }

                    void OnProgressChanged(OperationProgressReport<bool> progressReport)
                    {
                        if (progressReport.State == OperationState.Started)
                        {
                            btnClose.Enabled = false;
                            btnAccept.Enabled = false;
                        }
                        else if (progressReport.State == OperationState.Running)
                        {
                            if (progressReport.Value)
                            {
                                if (Order != null)
                                {
                                    try
                                    {
                                        Insulations.Forms.Shared.Commands.PrintOrderService service = new(
                                            Order.ItemId,
                                            Order.Batch,
                                            Order.Serie,
                                            Order.Sequence,
                                            Order.Machine,
                                            Order.Dimensions);

                                        service.Print();
                                    }
                                    catch (Exception ex)
                                    {
                                        ShowErrorMessage("Ocurrió un error al imprimir la información de la orden.", Text, ex);
                                    }
                                    finally
                                    {
                                        btnClose.Enabled = true;
                                        btnAccept.Enabled = true;
                                    }
                                }
                            }
                        }
                        else if (progressReport.State == OperationState.Error)
                        {
                            ShowErrorMessage(progressReport.ErrorMessage ?? "", Text, progressReport.Exception);
                        }
                        else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                        {
                            if (!progressReport.Value)
                            {
                                btnClose.Enabled = true;
                                btnAccept.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Functionality

        private void ShowErrorMessage(
          string errorMessage,
          string messageTitle,
          Exception? exception)
        {
            if (exception != null)
            {
                logger.LogError(exception, errorMessage);
            }

            string userMessage = errorMessage;

            if (exception != null)
            {
                if (exception is UserException userException)
                {
                    string? customMessage = userException.SystemErrorCode switch
                    {
                        (int)SystemErrorCode.GeneralError => null,
                        _ => null,
                    };

                    System.Text.StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(userException.Message);

                    if (!string.IsNullOrEmpty(customMessage))
                    {
                        stringBuilder.Append(customMessage);

                        if (userException.SystemErrorCode is (int)SystemErrorCode.InternalServerError)
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

            MessageBox.Show(
                this,
                userMessage,
                messageTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        #endregion
    }
}