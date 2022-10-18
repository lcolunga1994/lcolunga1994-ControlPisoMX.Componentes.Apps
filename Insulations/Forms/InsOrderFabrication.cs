namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using System;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models;
    using ProlecGE.ControlPisoMX.Insulations.Forms.Utils;

    public partial class InsOrderFabrication : ThemedForm
    {
        #region Fields

        private int? minimumMinutes = 0;
        private int manufactureMinutes = 5;
        private TimeSpan ts;

        private readonly ILogger<InsOrderFabrication> logger;
        private readonly MediatR.IMediator mediator;
        private readonly HubConnection connection;
        private readonly IProgress<HubConnectionState> connectionProgress;
        private readonly IProgress<bool> ordersAddedProgress;
        private readonly OperationProgress<ManufacturingOrderModel?> orderChangedProgress;

        #endregion

        #region Constructors

        public InsOrderFabrication(
             ILogger<InsOrderFabrication> logger,
             IConfiguration configuration,
             Microsoft.Extensions.Options.IOptionsMonitor<ThemeConfiguration> monitor,
             MediatR.IMediator mediator) : base(new ThemeConfiguration() { UseDarkTheme = true })
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            this.mediator = mediator;

            connection = new HubConnectionBuilder()
                .WithUrl(configuration.GetValue<string>("Urls:SignalR"))
                .WithAutomaticReconnect()
                .Build();

            connectionProgress = new Progress<HubConnectionState>(DisplayConnectionState);
            ordersAddedProgress = new Progress<bool>(StartOrderManufacturing);
            orderChangedProgress = new OperationProgress<ManufacturingOrderModel?>(ChangeOrder);
            OrdersInProgress = Enumerable.Empty<InsulationManufactureModel>();

            InitializeComponent();
            CustomInitializeComponent();
        }

        #endregion

        #region Properties

        internal ManufacturingOrderModel? Order { get; set; }

        internal IEnumerable<InsulationManufactureModel> OrdersInProgress { get; set; }

        internal bool AllowPrintMachine { get; set; }

        #endregion

        #region Controls initialization

        private void CustomInitializeComponent()
        {
            lblUserName.Text = Environment.UserName.Trim();
            lblConnectionMessage.Font = new Font("Arial", 24F);
            lblLodingItems.Font = new Font("Arial", 24F);
            lblNoOrder.Font = new Font("Arial", 24F);
        }

        #endregion

        #region Events

        private async void InsOrderFabrication_Load(object sender, EventArgs e)
        {
            logger.LogTrace("Load started.");

            connection.Reconnecting += OnReconnecting;
            connection.Reconnected += OnReconnected;
            connection.Closed += OnConnectionClosed;

            connection.On<ManufacturingOrderModel>("CurrentManufacturingChanged", (current) => orderChangedProgress.Report(current));
            connection.On("StopManufacturing", () => orderChangedProgress.Report(null));
            connection.On<IEnumerable<ManufacturingOrderAddedModel>>("OrdersAdded", orders => ordersAddedProgress.Report(true));
            connection.On("StartWorks", () => ordersAddedProgress.Report(true));

            lblTimeLapse.Text = "00:00:00";

            ResetOrder();

            StartOrderManufacturing(true);

            await ConnectAsync().ConfigureAwait(false);

            logger.LogTrace("Load finished.");
        }

        private void InsOrderFabrication_Resize(object sender, EventArgs e)
        {
            logger.LogTrace("Resize started.");
            CenterConnectionMessageLabel();
            CenterNoOrderLabel();
            logger.LogTrace("Resize finished.");
        }

        private void BtnFinishWork_Click(object sender, EventArgs e) => FinishOrder();

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime ableTime;
            DateTime limitTime;
            DateTime actualTime;

            if (minimumMinutes == null)
            {
                minimumMinutes = 0;
            }

            if (Order != null)
            {
                ableTime = Order.StartUtcDate.AddMinutes(minimumMinutes.Value);
                limitTime = Order.StartUtcDate.AddMinutes(manufactureMinutes);
                actualTime = DateTime.UtcNow;

                double diffInSeconds = Convert.ToInt32((limitTime - actualTime).TotalSeconds);

                if (diffInSeconds < 0)
                {
                    lblTimeLapse.ForeColor = Color.FromArgb(247, 21, 21);
                    ts = TimeSpan.FromSeconds(diffInSeconds * -1);
                }
                else
                {
                    lblTimeLapse.ForeColor = Color.FromArgb(255, 203, 33);
                    ts = TimeSpan.FromSeconds(diffInSeconds);
                }

                lblTimeLapse.Text = ts.ToString(@"hh\:mm\:ss");

                if (DateTime.UtcNow > ableTime)
                {
                    btnFinishWork.Enabled = true;
                }
                else
                {
                    btnFinishWork.Enabled = false;
                }
            }
        }

        #endregion

        #region Connection events

        private Task OnReconnecting(Exception? arg)
        {
            connectionProgress.Report(connection.State);
            return Task.CompletedTask;
        }

        private async Task OnReconnected(string? arg)
        {
            connectionProgress.Report(connection.State);
            await Task.CompletedTask;
        }

        private async Task OnConnectionClosed(Exception? arg)
        {
            connectionProgress.Report(connection.State);
            await ConnectAsync().ConfigureAwait(false);
        }

        private void DisplayConnectionState(HubConnectionState obj)
        {
            if (obj == HubConnectionState.Connected)
            {
                lblConnectionMessage.Visible = false;
            }
            else
            {
                lblConnectionMessage.Visible = true;
                ResetOrder();
            }

            switch (obj)
            {
                case HubConnectionState.Disconnected:
                    lblConnectionMessage.Text = "Desconectado del servidor.";
                    CenterConnectionMessageLabel();
                    break;
                case HubConnectionState.Connected:
                    lblConnectionMessage.Text = "Conectado";
                    CenterConnectionMessageLabel();
                    break;
                case HubConnectionState.Connecting:
                    lblConnectionMessage.Text = "Conectando con el servidor...";
                    CenterConnectionMessageLabel();
                    break;
                case HubConnectionState.Reconnecting:
                    lblConnectionMessage.Text = "Reconectando...";
                    CenterConnectionMessageLabel();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Queries

        private async void LoadMinimumManfactureTime()
        {
            OperationProgress<bool> operationProgress = new(OnProgressChanged);

            try
            {
                operationProgress.Start();

                minimumMinutes = await mediator
                    .Send(new ClientApp.Queries.MinimumManufactureMinutesQuery())
                    .ConfigureAwait(false);

                operationProgress.Report(true);
            }
            catch (Exception ex)
            {
                operationProgress.Error("Ocurrió un problema al consultar los minutos mínimos configurados para terminar una orden.", ex);
            }
            finally
            {
                operationProgress.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> report)
            {
                if (report.State == OperationState.Error)
                {
                    ShowErrorMessage(report.ErrorMessage ?? "", "Carga de tiempo", report.Exception);
                }
                else if (report.State == OperationState.Finished)
                {
                    if (minimumMinutes == null)
                    {
                        MessageBox.Show("No se encontraron los minutos mínimos configurados para terminar una orden.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private async void LoadManfactureTime()
        {
            OperationProgress<bool> operationProgress = new(OnProgressChanged);

            try
            {
                operationProgress.Start();
                manufactureMinutes = await mediator
                    .Send(new ClientApp.Queries.ManufactureMinutesQuery())
                    .ConfigureAwait(false);

                operationProgress.Report(true);
            }
            catch (Exception ex)
            {
                manufactureMinutes = 5;
                operationProgress.Error("Ocurrió un problema al consultar los minutos configurados para atender las ordenes.", ex);
            }
            finally
            {
                operationProgress.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> report)
            {
                if (report.State == OperationState.Started)
                {
                    btnFinishWork.Enabled = false;
                }
                else if (report.State == OperationState.Error)
                {
                    ShowErrorMessage(report.ErrorMessage ?? "", "Carga de tiempo", report.Exception);
                }
            }
        }

        #endregion

        #region Commands

        private async void StartOrderManufacturing(bool overrride)
        {
            OperationProgress<bool> operationProgress = new(OnProgressChanged);

            try
            {
                operationProgress.Start();

                await mediator
                    .Send(new ClientApp.Commands.StartOrderManufacturingCommand())
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                operationProgress.Error("Ocurrió un problema al iniciar las ordenes pendientes.", ex);
            }
            finally
            {
                operationProgress.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> report)
            {
                if (report.State == OperationState.Started)
                {
                    btnFinishWork.Enabled = false;
                }
                else if (report.State == OperationState.Error)
                {
                    ShowErrorMessage(report.ErrorMessage ?? "", "Iniciar ordenes", report.Exception);
                }
            }
        }

        private async Task<bool> ConnectAsync()
        {
            // Keep trying to until we can start or the token is canceled.
            while (true)
            {
                try
                {
                    connectionProgress.Report(HubConnectionState.Connecting);

                    await Task.Delay(new Random().Next(0, 3) * 1000).ConfigureAwait(false);

                    await connection.StartAsync().ConfigureAwait(false);

                    System.Diagnostics.Debug.Assert(connection.State == HubConnectionState.Connected);
                    connectionProgress.Report(connection.State);

                    return true;
                }
                catch
                {
                    System.Diagnostics.Debug.Assert(connection.State == HubConnectionState.Disconnected);
                    await Task.Delay(3000).ConfigureAwait(false);
                }
            }
        }

        private async void FinishOrder()
        {
            OperationProgress<bool> operationProgress = new(OnProgressChanged);

            try
            {
                operationProgress.Start();

                OrdersInProgress = await mediator
                    .Send(new ClientApp.Queries.InProgressManufacturingQuery())
                    .ConfigureAwait(false);

                if (OrdersInProgress.Any())
                {
                    AllowPrintMachine = await mediator
                        .Send(new ClientApp.Queries.MachineCanPrintQuery(OrdersInProgress.First().Machine))
                        .ConfigureAwait(false);

                    await mediator
                       .Send(new ClientApp.Commands.FinishOrderManufacturingCommand())
                       .ConfigureAwait(false);
                }

                operationProgress.Report(true);
            }
            catch (Exception ex)
            {
                operationProgress.Error("Ocurrió un problema al terminar la orden en ejecucion.", ex);
            }
            finally
            {
                operationProgress.Finish();
            }

            void OnProgressChanged(OperationProgressReport<bool> report)
            {
                if (report.State == OperationState.Started)
                {
                    btnFinishWork.Enabled = false;
                    timer.Enabled = false;
                }
                else if (report.State == OperationState.Error)
                {
                    ShowErrorMessage(report.ErrorMessage ?? "", "Terminar orden", report.Exception);
                    btnFinishWork.Enabled = true;
                }
                else if (report.State == OperationState.Running)
                {
                    if (report.Value)
                    {
                        PrintTag();
                    }
                }
                else if (report.State == OperationState.Finished)
                {
                    timer.Enabled = true;
                }
            }
        }

        #endregion

        #region Theme

        protected override void OnThemeChanged(bool useDarkTheme)
        {
            base.OnThemeChanged(useDarkTheme);

            CustomTheme.Instance.ApplyLabelThemeGreenColor(lblItemValue);
            CustomTheme.Instance.ApplyLabelThemeGreenColor(lblMachineValue);
            CustomTheme.Instance.ApplyLabelThemeGreenColor(lblQuantityValue);
            CustomTheme.Instance.ApplyStandarImages(picBoxEnterpriseLogo, picBoxSubTitleLine);
            CustomTheme.Instance.ApplyUserImage(picBoxUserImage);
        }

        #endregion

        #region Functionality

        private void ChangeOrder(OperationProgressReport<ManufacturingOrderModel?> progressReport)
        {
            logger.LogTrace("Change Order");

            if (progressReport.State == OperationState.Running)
            {
                Order = progressReport.Value;
                DisplayOrder();
                LoadMinimumManfactureTime();
                LoadManfactureTime();
            }
        }

        private void ResetOrder()
        {
            Order = null;
            DisplayOrder();
        }

        private void DisplayOrder()
        {
            lblItemValue.Text = Order == null ? "" : $"{Order.ItemId}-{Order.Batch}";
            lblQuantityValue.Text = Order?.Quantity.ToString();
            lblMachineValue.Text = Order?.Machine;

            if (Order == null)
            {
                lblNoOrder.AutoSize = true;
                lblNoOrder.Text = "No hay unidades por procesar.";
                CenterNoOrderLabel();
                lblNoOrder.Visible = (connection.State == HubConnectionState.Connected);
                pnlControls.Visible = false;
                lblLodingItems.Visible = false;
            }
            else
            {
                pnlControls.Visible = true;
                lblNoOrder.Visible = false;
                lblNoOrder.Visible = false;
            }
        }

        private void CenterConnectionMessageLabel()
        {
            int lblTop = ((ClientSize.Height / 2) - (lblConnectionMessage.Height / 2));
            int lblLeft = ((ClientSize.Width / 2) - (lblConnectionMessage.Width / 2));
            lblConnectionMessage.Location = new Point(lblLeft, lblTop);
        }

        private void CenterNoOrderLabel()
        {
            int lblTop = ((ClientSize.Height / 2) - (lblNoOrder.ClientSize.Height / 2));
            int lblLeft = ((ClientSize.Width / 2) - (lblNoOrder.ClientSize.Width / 2));
            lblNoOrder.Location = new Point(lblLeft, lblTop);
        }

        private void PrintTag()
        {
            if (AllowPrintMachine)
            {
                foreach (InsulationManufactureModel order in OrdersInProgress)
                {
                    new Shared.Commands.PrintOrderService(
                            order.ItemId,
                            order.Batch,
                            order.Serie,
                            order.Sequence,
                            order.Machine,
                            order.Dimensions)
                        .Print();
                }
            }
        }

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
                        401 => null,
                        _ => null,
                    };

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