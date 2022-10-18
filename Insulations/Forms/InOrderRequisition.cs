namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using System;
    using System.Windows.Forms;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.Insulations.Forms.Utils;

    public partial class InOrderRequisition : ThemedForm
    {
        #region Fields

        private readonly MediatR.IMediator mediator;
        private readonly ILogger<InOrderRequisition> logger;

        #endregion

        #region Constructors

        public InOrderRequisition(ILogger<InOrderRequisition> logger,
            Microsoft.Extensions.Options.IOptionsMonitor<ThemeConfiguration> monitor,
            MediatR.IMediator mediator) : base(new ThemeConfiguration() { UseDarkTheme = false })
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mediator = mediator;

            InitializeComponent();
            CustomInitializeComponent();
        }

        #endregion

        #region Controls initialization

        private void CustomInitializeComponent() => lblUserName.Text = Program.UserDisplayName;

        #endregion

        #region Events

        private void InOrderRequisition_Load(object sender, EventArgs e) => LoadMachine();
        
        private void BtnClean_Click(object sender, EventArgs e) => Clean();

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void TxtBatch_Leave(object sender, EventArgs e) => txtBatch.Text = txtBatch.Text.PadLeft(2, '0');

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("¿Esta seguro que los datos estan correctos?",
                                     "Confirmación",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                AddOrdersToManufacturing();
            }
        }

        #endregion

        #region Commands

        public async void AddOrdersToManufacturing()
        {
            OperationProgress<bool> operation = new(OnProgressChanged);

            bool canNum = false;
            string item = txtOrder.Text.Trim().ToUpper();
            string batch = txtBatch.Text;
            string? machine = "REP";

            if (cmbMachine != null && cmbMachine.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbMachine.SelectedItem.ToString()))
            {
                machine = cmbMachine.SelectedItem.ToString();
            }
            canNum = int.TryParse(txtQuantity.Text, out int quantity);
            if (!canNum)
            {
                MessageBox.Show("La cantidad debe ser un valor númerico.", "Requerimiento de fabricación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            canNum = int.TryParse(txtPriority.Text, out int priority);
            if (!canNum)
            {
                MessageBox.Show("La prioridad debe ser un valor númerico", "Requerimiento de fabricación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantity < 0 || quantity > 2)
            {
                MessageBox.Show("La cantidad de la orden solamente puede ser 1 o 2", "Requerimiento de fabricación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (priority < 1 || priority > 999)
            {
                MessageBox.Show("La prioridad  de la orden solamente puede ser entre 1 y 999", "Requerimiento de fabricación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (machine != null)
                {
                    operation.Start();
                    await mediator
                        .Send(new ClientApp.Commands.AddRepairOrderToManufacturingCommand(item, batch, quantity, priority))
                        .ConfigureAwait(false);

                    operation.Report(true);
                }
            }
            catch (Exception ex)
            {
                operation.Error($"Ocurrió un error al agregar la orden a la lista de fabricación.", ex);
            }
            finally
            {
                operation.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> progressReport)
            {
                if (progressReport.State == OperationState.Started)
                {
                    SetBusy(true);
                }
                else if (progressReport.State == OperationState.Running)
                {
                    if (progressReport.Value)
                    {
                        MessageBox.Show("La orden fue agregada", "Requerimiento de fabricación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clean();
                    }
                }
                else if (progressReport.State == OperationState.Error)
                {
                    ShowErrorMessage(progressReport.ErrorMessage ?? "", "Agregar orden", progressReport.Exception);
                }
                else if (progressReport.State == OperationState.Canceled || progressReport.State == OperationState.Finished)
                {
                    SetBusy(false);
                }
            }
        }

        #endregion

        #region Theme

        protected override void OnThemeChanged(bool useDarkTheme)
        {
            base.OnThemeChanged(useDarkTheme);
            CustomTheme.Instance.ApplySecondaryButtonTheme(btnClose);
            CustomTheme.Instance.ApplyStandarImages(picBoxEnterpriseLogo, picBoxSubTitleLine);
            CustomTheme.Instance.ApplyUserImage(picBoxUserImage);
        }

        #endregion

        #region Functionality        

        private void Clean()
        {
            txtOrder.Text = "";
            txtBatch.Text = "";
            txtQuantity.Text = "";
        }

        private void LoadMachine()
        {
            cmbMachine.Items.Clear();
            cmbMachine.Items.Add("REP");
            cmbMachine.SelectedIndex = 0;
            cmbMachine.SelectedItem = 0;
        }

        private void SetBusy(bool formIsBusy)
        {
            if (formIsBusy)
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                Cursor.Current = Cursors.Default;
            }

            btnAccept.Enabled = !formIsBusy;
            btnClean.Enabled = !formIsBusy;
            btnClose.Enabled = !formIsBusy;
        }


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
